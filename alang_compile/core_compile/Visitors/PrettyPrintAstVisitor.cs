using System;
using System.Xml.Serialization;

namespace core_compile
{
    public class PrettyPrintAstVisitor : Visitor<object>
    {
        public int IndentLevel { get; set; }
        public string Indent => new String(' ', IndentLevel * 2);
 
        public override object Visit(StartNode node)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("StartNode:");
            Console.ResetColor();
            IndentLevel++;
            Visit(node.MultipleDeclarationNode);
            Visit(node.MultipleStatementsNode);
            IndentLevel--;
            return null;
        }

        public override object Visit(MultipleDeclarationsNode node)
        {
            foreach (var dcl in node.DeclarationNodes)
            {
                Visit((dynamic)dcl);
            }
            return null;
        }

        public override object Visit(MultipleStatementsNode node)
        {
            foreach (var stmt in node.StatementNodes)
            {
                Visit((dynamic)stmt);
            }
            return null;
        }

        public override object Visit(DeclarationNode node)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(Indent + "DeclarationNode: " + node.DeclarationType + " " + node.Id + " ");
            Visit(node.Value);
            Console.Write("\n");
            Console.ResetColor();
            return null;
        }

        public override object Visit(AssignStatementNode node)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(Indent + "AssignmentNode: " + node.Id + " ");
            Visit(node.Value);
            Console.Write("\n");
            IndentLevel++;
            Visit(node.Expression);
            IndentLevel--;
            Console.Write("\n");
            Console.ResetColor();
            return null;
        }

        public override object Visit(IfStatementNode node)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(Indent + "IfStatementNode: ");
            Visit(node.Value);
            Console.Write("\n");
            IndentLevel++;
            Visit(node.Expression);
            Console.Write("\n");
            IndentLevel++;
            Visit(node.MultipleStatementsNode);
            IndentLevel--;
            IndentLevel--;
            Console.ResetColor();
            return null;
        }

        public override object Visit(RepeatStatementNode node)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(Indent + "RepeatStatementNode: ");
            Visit(node.Value);
            Console.Write("\n");
            Console.ResetColor();
            IndentLevel++;
            Visit(node.MultipleStatementsNode);
            IndentLevel--;
            return null;
        }

        public override object Visit(OutputStatementNode node)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(Indent + "OutputStatementNode: " + node.Id + " " + node.Toggle);
            Console.Write("\n");
            Console.ResetColor();
            return null;
        }

        public override object Visit(ExpressionNode node)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(Indent + "ExpressionNode: ");
            foreach (var op in node.ExpressionOperators)
            {
                Console.Write(" " + op + " ");
            }

            foreach (var value in node.Values)
            {
                Visit(value);
            }
            Console.ResetColor();
            return null;
        }

        public override object Visit(ValueNode node)
        {
            Console.Write(node.Value + " (" + node.ValueKind + ")");
            Console.ResetColor();
            return null;
        }

    }
}