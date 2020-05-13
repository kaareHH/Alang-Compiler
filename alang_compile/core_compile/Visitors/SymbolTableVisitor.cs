using System;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;
using core_compile.AbstractSyntaxTree;
using core_compile.SymbolTableClasses;

namespace core_compile.Visitors
{
    // TODO: Add reserved keywords to symboltable
    public class SymbolTableVisitor : IVisitor
    {
        public SymbolTable CurrentSymbolTable { get; set; } = new SymbolTable(null);

        public void Visit(CompilationNode node)
        {
            CurrentSymbolTable.OpenScope();
            var child = node.GetChildren();
            while (child != null)
            {
                child.Accept(this);
                child = child.RightSibling;
            }
            CurrentSymbolTable.CloseScope();
        }

        public void Visit(DeclarationNode node)
        {
            CurrentSymbolTable.Insert(node.Identifier, node);
        }

        public void Visit(AssignmentNode node)
        {
            if (!CurrentSymbolTable.currentTable.Lookup(node.Identifier))
                throw new SymbolDoNotExistException();

        }

        public void Visit(ExpressionNode node)
        {
            // node.Left.Accept(this);
            // node.Right.Accept(this);
        }

        public void Visit(FunctionCallNode node)
        {

        }

        public void Visit(FunctionNode node)
        {
            CurrentSymbolTable.Insert(node.Identifier, node);
            CurrentSymbolTable.OpenScope();

            var child = node.GetChildren();
            while (child != null)
            {
                child.Accept(this);
                child = child.RightSibling;
            }

            CurrentSymbolTable.CloseScope();
        }

        public void Visit(IdentfierNode node)
        {

        }

        public void Visit(IfNode node)
        {
            node.Condition.Accept(this);

            var child = node.Consequent;
            while (child != null)
            {
                child.Accept(this);
                child = child.RightSibling;
            }

            if (node.Alternate != null)
            {
                child = node.Alternate;
                while (child != null)
                {
                    child.Accept(this);
                    child = child.RightSibling;
                }
            }
        }

        public void Visit(ImportNode node)
        {
            return;
        }

        public void Visit(IntNode node)
        {
            return;
        }

        public void Visit(Location node)
        {
            return;
        }

        public void Visit(NullNode node)
        {
            return;
        }

        public void Visit(OutputNode node)
        {
            // if (!CurrentSymbolTable.ContainsSymbolByName(node.Identifier))
            //     throw new Exception("Variable used before its declared...");
        }

        public void Visit(ParameterNode node)
        {
            // if (!CurrentSymbolTable.ContainsSymbolByName(node.Identifier))
            //     throw new Exception("Variable used before its declared...");
        }

        public void Visit(PinNode node)
        {
            return;
        }

        public void Visit(TimeNode node)
        {
            return;
        }

        public void Visit(ValueNode node)
        {
            node.Value.Accept(this);
        }

        public void Visit(WhileNode node)
        {
            node.LoopExpression.Accept(this);

            CurrentSymbolTable.OpenScope();
            var child = node.GetChildren();
            while (child != null)
            {
                child.Accept(this);
                child = child.RightSibling;
            }

            CurrentSymbolTable.CloseScope();
        }

        public void Visit(AstNode node)
        {

            //node.Accept(this);
        }
    }

}