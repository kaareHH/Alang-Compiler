using System;
using System.Linq;
using System.Runtime.Serialization;
using core_compile.AbstractSyntaxTree;

namespace core_compile.Visitors
{
    public class PrettyPrintAstVisitor : IVisitor
    {

        public int IndentLevel { get; set; }
        public string Indent => new String(' ', IndentLevel * 2);

        public void Visit(CompilationNode node)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("CompilationNode:");
            Console.ResetColor();
            IndentLevel++;
            var child = node.GetChildren();
            while (child != null)
            {
                child.Accept(this);
                child = child.RightSibling;
            }
            IndentLevel--;

        }
        public void Visit(DeclarationNode node)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(Indent + "DeclarationNode: " + node.Type + " " + node.Identifier + " ");
            node.PrimaryExpression.Accept(this);
            Console.Write("\n");
            Console.ResetColor();
        }

        public void Visit(AssignmentNode node)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(Indent + "AssignmentNode: " + node.Identifier + " ");
            Console.Write("\n");
            IndentLevel++;
            node.Expression.Accept(this);
            IndentLevel--;
            Console.Write("\n");
            Console.ResetColor();
        }

        public void Visit(ExpressionNode node)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(Indent + "ExpressionNode: ");
            node.Left.Accept(this);
            System.Console.Write(node.Operator.ToString());
            node.Right.Accept(this);
            Console.ResetColor();
        }

        public void Visit(FunctionCallNode node)
        {

        }

        public void Visit(FunctionNode node)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Indent + "FunctionNode: " + node.Identifier);
            IndentLevel++;
            var child = node.GetChildren();
            while (child != null)
            {
                child.Accept(this);
                child = child.RightSibling;
            }
            IndentLevel--;
        }

        public void Visit(IdentfierNode node)
        {
            System.Console.WriteLine(node.Symbol);
        }

        public void Visit(IfNode node)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(Indent + "IfStatementNode: ");
            Visit(node.Condition);
            Console.Write("Then\n");
            IndentLevel++;
            var child = node.Consequent;
            while (child != null)
            {
                child.Accept(this);
                child = child.RightSibling;
            }
            if (node.Alternate != null)
            {
                Console.Write("\nelse");
                child = node.Alternate;
                while (child != null)
                {
                    child.Accept(this);
                    child = child.RightSibling;
                }
            }
            IndentLevel--;
            Console.ResetColor();
        }

        public void Visit(ImportNode node)
        {

        }

        public void Visit(IntNode node)
        {
            //emit(node.Value.ToString());
        }

        public void Visit(Location node)
        {

        }

        public void Visit(NullNode node)
        {

        }

        public void Visit(OutputNode node)
        {
            // Console.ForegroundColor = ConsoleColor.DarkRed;
            // Console.Write(Indent + "OutputStatementNode: " + node.Id + " " + node.Toggle);
            // Console.Write("\n");
            // Console.ResetColor();
            // return null;
        }

        public void Visit(ParameterNode node)
        {

        }

        public void Visit(PinNode node)
        {

        }

        public void Visit(TimeNode node)
        {

        }

        public void Visit(ValueNode node)
        {

        }

        public void Visit(WhileNode node)
        {

        }

        public void Visit(AstNode node)
        {
            return;
        }
    }
}