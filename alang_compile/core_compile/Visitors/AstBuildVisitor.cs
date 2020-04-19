using System;
using System.Collections.Generic;
using AntlrGen;

namespace core_compile
{
    public class AstBuildVisitor : ALangBaseVisitor<Node>
    {
        public override Node VisitStart(ALangParser.StartContext context)
        {
            return new StartNode
            {
                MultipleDeclarationNode = (MultipleDeclarationsNode)Visit(context.dcls()),
                MultipleStatementsNode = (MultipleStatementsNode)Visit(context.stmts())
            };
        }

        public override Node VisitStmts(ALangParser.StmtsContext context)
        {
            List<StatementNode> statementNodeList = new List<StatementNode>();
            foreach (var child in context.stmt())
            {
                statementNodeList.Add((StatementNode)Visit(child));
            }
            
            return new MultipleStatementsNode
            {
                StatementNodes = statementNodeList
            };
        }

        public override Node VisitDcls(ALangParser.DclsContext context)
        {
            List<DeclarationNode> declarationNodeList = new List<DeclarationNode>();
            foreach (var child in context.dcl())
            {
                declarationNodeList.Add((DeclarationNode)Visit(child));
            }
            
            return new MultipleDeclarationsNode()
            {
                DeclarationNodes = declarationNodeList
            };
        }

        public override Node VisitDcl(ALangParser.DclContext context)
        {
            return new DeclarationNode
            {
                DeclarationType = context.TYPE().ToString() == "int" ? DeclarationType.Integer : DeclarationType.Pin,
                Id = context.ID().ToString(),
                Value = (ValueNode) Visit(context.value())
            };
        }

        public override Node VisitAssignstmt(ALangParser.AssignstmtContext context)
        {
            return new AssignStatementNode
            {
                Id = context.ID().ToString(),
                Value = (ValueNode) Visit(context.value()),
                Expression = (ExpressionNode) Visit(context.expr())
            };
        }

        public override Node VisitIfstmt(ALangParser.IfstmtContext context)
        {
            return new IfStatementNode
            {
                Value = (ValueNode) Visit(context.value()),
                Expression = (ExpressionNode) Visit(context.expr()),
                MultipleStatementsNode = (MultipleStatementsNode) Visit(context.stmts())
            };

        }

        public override Node VisitRepeatstmt(ALangParser.RepeatstmtContext context)
        {
            return new RepeatStatementNode
            {
                Value = (ValueNode) Visit(context.value()),
                MultipleStatementsNode = (MultipleStatementsNode) Visit(context.stmts())
            };
        }

        public override Node VisitOutputstmt(ALangParser.OutputstmtContext context)
        {
            return new OutputStatementNode
            {
                Toggle = (Toggle) Enum.Parse(typeof(Toggle), context.TOGGLE().ToString(), true),
                Id = context.ID().ToString()
            };
        }

        public override Node VisitExpr(ALangParser.ExprContext context)
        {
            List<Operator> operatorList = new List<Operator>();
            List<ValueNode> valueList = new List<ValueNode>();
            
            foreach (var child in context.OPERATOR())
            {
                Operator expressionOperator = Operator.Addition;
                
                switch (child.GetText())
                {
                    case "+":
                        expressionOperator = Operator.Addition;
                        break;
                    case "-":
                        expressionOperator = Operator.Subtraction;
                        break;
                    case "*":
                        expressionOperator = Operator.Multiplication;
                        break;
                    case "/":
                        expressionOperator = Operator.Division;
                        break;
                }
                
                operatorList.Add(expressionOperator);
            }
            
            foreach (var child in context.value())
            {
                valueList.Add((ValueNode)Visit(child));
            }

            return new ExpressionNode
            {
                ExpressionOperators = operatorList,
                Values = valueList
            };

        }

        public override Node VisitValue(ALangParser.ValueContext context)
        {
            if (context.INTEGERS() != null)
            {
                return new ValueNode
                {
                    ValueKind = ValueKind.Integer,
                    Value = int.Parse(context.INTEGERS().ToString())
                };
            } else if (context.PIN() != null)
            {
                return new ValueNode
                {
                    ValueKind = ValueKind.Pin,
                    Value = int.Parse(context.PIN().ToString())
                };
            }
            else
            {
                return new ValueNode
                {
                    ValueKind = ValueKind.Id,
                    Value = context.ID().ToString()
                };
            }
        }
    }
}