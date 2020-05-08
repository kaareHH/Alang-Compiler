using Antlr4.Runtime;
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
            var astRoot = new CompilationUnit(context);
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
            return new NullNode();
        }

        public override AstNode VisitDcl(ALangParser.DclContext context)
        {
            var node = new DeclarationNode(context);
            node.PrimaryExpression = context.primaryExpression().Accept(this) as ExpressionNode;
            node.Identifier = context.ID().GetText();
            node.Type = Type.GetType(context);

            return node;
        }


        public override AstNode VisitFunction(ALangParser.FunctionContext context)
        {
            var node = new FunctionNode();
            node.Identifier = context.ID().GetText();
            node.Type = Type.GetType(context);
            node.AdoptChildren(context.stmts().Accept(this));

            return node;
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
            if (context.stmts().children != null)
                node.MakeSiblings(context.stmts().Accept(this));
            return node;
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
            return new NullNode();
        }

        public override AstNode VisitOutputstmt(ALangParser.OutputstmtContext context)
        {
            return new OutputNode(context);
        }

        public override AstNode VisitIfstmt(ALangParser.IfstmtContext context)
        {
            var node = new IfNode(context);
            if (context.primaryExpression() != null)
                node.Condition = context.primaryExpression().Accept(this) as ExpressionNode;
            if (context.stmts(0) != null)
                node.Consequent = context.stmts(0).Accept(this);
            if (context.stmts(1) != null)
                node.Alternate = context.stmts(1).Accept(this);
            return node;
        }

        public override AstNode VisitFunctioncall(ALangParser.FunctioncallContext context)
        {
            return new FunctionCallNode(context);
        }

        public override AstNode VisitRepeatstmt(ALangParser.RepeatstmtContext context)
        {
            var repeatNode = new RepeatNode(context);
            if (context.primaryExpression() != null)
                repeatNode.LoopExpression = context.primaryExpression().Accept(this) as ExpressionNode;
            if (context.stmts().children != null)
                repeatNode.AdoptChildren(context.stmts().Accept(this));
            return repeatNode;
        }

        public override AstNode VisitPrimaryExpression(ALangParser.PrimaryExpressionContext context)
        {
            ExpressionNode node = new ExpressionNode(context);
            if (context.OPALL() != null)
                node.Operator = GetOperatorKind(context.OPALL().GetText());
            if (context.expression() != null)
                node.Left = context.expression().Accept(this) as ExpressionNode;
            if (context.primaryExpression() != null)
                node.Right = context.primaryExpression().Accept(this) as ExpressionNode;

            return node;
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
                default:
                    return Operator.InvalidOperator;
            }
        }

        public override AstNode VisitAssignstmt(ALangParser.AssignstmtContext context)
        {
            var assignNode = new AssignmentNode(context);
            assignNode.Identifier = context.ID().GetText();
            if (context.primaryExpression() != null)
                assignNode.Expression = context.primaryExpression().Accept(this) as ExpressionNode;
            return assignNode;
        }
    }
}