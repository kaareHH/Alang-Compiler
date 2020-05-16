using AntlrGen;
using core_compile.AbstractSyntaxTree;
using System;
using System.Linq;
using System.Threading;
using Antlr4.Runtime.Tree;
using Type = core_compile.AbstractSyntaxTree.Type;

namespace core_compile.Visitors
{
    public class AstBuilderVisitor : ALangBaseVisitor<AstNode>
    {
        public override AstNode VisitStart(ALangParser.StartContext context)
        {
            var astRoot = new CompilationNode(context);
            astRoot.AdoptChildren(context.commands().Accept(this));
            return astRoot;
        }

        public override AstNode VisitCommands(ALangParser.CommandsContext context)
        {

            AstNode node = ExtractCommandTypeNode(context);
            if (context.commands() != null)
                node.MakeSiblings(context.commands().Accept(this));

            return node;
        }

        private AstNode ExtractCommandTypeNode(ALangParser.CommandsContext context)
        {
            if (context.dcl() != null)
                return context.dcl().Accept(this);
            if (context.imports() != null)
                return context.imports().Accept(this);
            if (context.function() != null)
                return context.function().Accept(this);
            return null;
        }

        public override AstNode VisitDcl(ALangParser.DclContext context)
        {
            var node = new DeclarationNode(context);
            node.RightHandSide = context.primaryExpression().Accept(this);
            node.Identifier = context.ID().GetText();
            node.Type = Type.GetType(context);
             
            return node;
        }


        public override AstNode VisitFunction(ALangParser.FunctionContext context)
        {
            var functionNode = new FunctionNode();
            functionNode.Identifier = context.ID().GetText();
            if (context.@params() != null)
                functionNode.Params = context.@params().Accept(this);
            functionNode.Type = Type.GetType(context);
            functionNode.AdoptChildren(context.stmts().Accept(this));

            return functionNode;
        }

        public override AstNode VisitImports(ALangParser.ImportsContext context)
        {
            var node = new ImportNode(context);
            node.Path = context.ALANGFILENAME().GetText();
            return node;
        }

        public override AstNode VisitStmts(ALangParser.StmtsContext context)
        {
            var node = ExtractStmtTypeNode(context);

            var stmt = context.stmts();
            if (context.stmts() != null)
                if (context.stmts().children != null)
                    node.MakeSiblings(context.stmts().Accept(this));
            return node;
        }


        public override AstNode VisitParams(ALangParser.ParamsContext context)
        {
            AstNode node;
            if (context.param() != null)
            {
                node = context.param().Accept(this);
                if (context.@params() != null)
                    node.MakeSiblings(context.@params().Accept(this));
            }
            else
                node = null;

            return node;
        }

        public override AstNode VisitParam(ALangParser.ParamContext context)
        {
            return new ParameterNode(context)
            {
                Identifier = context.ID().GetText(),
                Type = Type.GetType(context)
            };
        }

        private AstNode ExtractStmtTypeNode(ALangParser.StmtsContext context)
        {
            if (context.dcl() != null)
                return context.dcl().Accept(this);
            if (context.ifstmt() != null)
                return context.ifstmt().Accept(this);
            if (context.functioncall() != null)
                return context.functioncall().Accept(this);
            if (context.outputstmt() != null)
                return context.outputstmt().Accept(this);
            if (context.repeatstmt() != null)
                return context.repeatstmt().Accept(this);
            if (context.assignstmt() != null)
                return context.assignstmt().Accept(this);
            return new NullNode(context);
        }

        public override AstNode VisitOutputstmt(ALangParser.OutputstmtContext context)
        {
            OutputNode node = new OutputNode(context);

            node.Identifier = context.ID().GetText();
            if (context.ON() != null)
                node.State = true;
            else
                node.State = false;
            return node;
        }

        public override AstNode VisitReturnstmt(ALangParser.ReturnstmtContext context)
        {
            return base.VisitReturnstmt(context);
        }

        public override AstNode VisitIfstmt(ALangParser.IfstmtContext context)
        {
            var node = new IfNode(context);
            if (context.primaryExpression() != null)
                node.Condition = context.primaryExpression().Accept(this);
            if (context.stmts(0) != null)
                node.AdoptChildren(context.stmts(0).Accept(this));
            if (context.stmts(1) != null)
                node.Alternate = context.stmts(1).Accept(this);
            return node;
        }

        public override AstNode VisitInputparams(ALangParser.InputparamsContext context)
        {
            ValueNode node = new ValueNode(context);
            node.Value = context.value().Accept(this);
            if (context.inputparams() != null)
                node.MakeSiblings(context.inputparams().Accept(this));

            return node;
        }

        public override AstNode VisitFunctioncall(ALangParser.FunctioncallContext context)
        {
            FunctionCallNode node = new FunctionCallNode(context);
            node.Name = context.ID().GetText();
            if (context.inputparams() != null)
                node.AdoptChildren(context.inputparams().Accept(this));
            return node;
        }

        public override AstNode VisitRepeatstmt(ALangParser.RepeatstmtContext context)
        {
            var repeatNode = new WhileNode(context);
            if (context.primaryExpression() != null)
                repeatNode.Condition = context.primaryExpression().Accept(this);
            if (context.stmts().children != null)
                repeatNode.AdoptChildren(context.stmts().Accept(this));
            return repeatNode;
        }

        public override AstNode VisitPrimaryExpression(ALangParser.PrimaryExpressionContext context)
        {
            ExpressionNode node;
            if (context.BOOLOP().Length > 0)
            {
                node = new ExpressionNode(context);
                for(int n = 0; n < context.BOOLOP().Length; n++)
                {
                    node.Operator = GetOperatorKind(context.BOOLOP(n).GetText());
                    node.Left = context.predicateExpression(n).Accept(this);
                    node.Right = context.predicateExpression(n + 1).Accept(this);
                }
            }
            else
                return context.predicateExpression(0).Accept(this);
        
            return node;
        }

        public override AstNode VisitPredicateExpression(ALangParser.PredicateExpressionContext context)
        {
            ExpressionNode node;
            if (context.PREDOP().Length > 0)
            {
                node = new ExpressionNode(context);
                for(int n = 0; n < context.PREDOP().Length; n++)
                {
                    node.Operator = GetOperatorKind(context.PREDOP(n).GetText());
                    node.Left = context.additiveExpression(n).Accept(this);
                    node.Right = context.additiveExpression(n + 1).Accept(this);
                }
            }
            else
                return context.additiveExpression(0).Accept(this);
        
            return node;
        }

        public override AstNode VisitAdditiveExpression(ALangParser.AdditiveExpressionContext context)
        {
            ExpressionNode node;
            if (context.ADDOP().Length > 0)
            {
                node = new ExpressionNode(context);
                for(int n = 0; n < context.ADDOP().Length; n++)
                {
                    node.Operator = GetOperatorKind(context.ADDOP(n).GetText());
                    node.Left = context.multiExpression(n).Accept(this);
                    node.Right = context.multiExpression(n + 1).Accept(this);
                }
            }
            else
                return context.multiExpression(0).Accept(this);
        
            return node;
        }

        public override AstNode VisitMultiExpression(ALangParser.MultiExpressionContext context)
        {
            ExpressionNode node;
            if (context.MULOP().Length > 0)
            {
                node = new ExpressionNode(context);
                for(int n = 0; n < context.MULOP().Length; n++)
                {
                    node.Operator = GetOperatorKind(context.MULOP(n).GetText());
                    node.Left = context.primary(n).Accept(this);
                    node.Right = context.primary(n + 1).Accept(this);
                }
            }
            else
                return context.primary(0).Accept(this);
        
            return node;
        }
        
        public override AstNode VisitPrimary(ALangParser.PrimaryContext context)
        {
            AstNode node = new NullNode(context);
            if (context.value() != null)
                node = context.value().Accept(this);
            else if (context.LPAREN() != null)
            {
                node = context.primaryExpression().Accept(this);
                if (node is ExpressionNode expnode)
                    expnode.Parenthesized = true;
            }
        
            return node;
        }

        public override AstNode VisitValue(ALangParser.ValueContext context)
        {
            AstNode visitValue;
            if (context.ID() != null)
                visitValue = new IdentfierNode(context) { Symbol = context.ID().GetText() };
            else if (context.INTEGERS() != null)
            {
                var node = new IntNode(context);
                node.Value = Int32.Parse(context.INTEGERS().GetText());
                visitValue = node;
            }
            else if (context.PIN() != null)
            {
                var node = new PinNode(context);
                node.Value = Int32.Parse(context.PIN().GetText().TrimStart('P'));
                visitValue = node;
            }
            else if (context.TIME() != null)
            {
                var node = new TimeNode(context);
                node.Value = Time.TimeFromString(context.TIME().GetText());
                visitValue = node;
            }
            else
                visitValue = new NullNode(context);

            return visitValue;
        }

        private Operator GetOperatorKind(string op)
        {
            switch (op)
            {
                case "+":
                    return Operator.Addition;
                case "-":
                    return Operator.Subtraction;
                case "*":
                    return Operator.Multiplication;
                case "/":
                    return Operator.Division;
                case "%":
                    return Operator.Modulo;
                case ">":
                    return Operator.Greater;
                case "<":
                    return Operator.Less;
                case ">=":
                    return Operator.GreaterEqual;
                case "<=":
                    return Operator.LessEqual;
                case "==":
                    return Operator.EqualEqual;
                case "||":
                    return Operator.OR;
                case "&&":
                    return Operator.AND;
                default:
                    return Operator.InvalidOperator;
            }
        }

        public override AstNode VisitAssignstmt(ALangParser.AssignstmtContext context)
        {
            var assignNode = new AssignmentNode(context);
            assignNode.Identifier = context.ID().GetText();
            if (context.primaryExpression() != null)
                assignNode.Expression = context.primaryExpression().Accept(this);
            return assignNode;
        }
    }


}