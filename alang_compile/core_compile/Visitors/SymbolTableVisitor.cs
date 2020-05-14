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
            node.AcceptChildren(this);
            node.SymbolTable = CurrentSymbolTable.currentTable;
            CurrentSymbolTable.CloseScope();
        }

        public void Visit(DeclarationNode node)
        {
            CurrentSymbolTable.Insert(node.Identifier, node);
        }

        public void Visit(AssignmentNode node)
        {
            CurrentSymbolTable.currentTable.CheckIfExists(node.Identifier);
            node.Expression.Accept(this);
        }

        public void Visit(ExpressionNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
        }

        public void Visit(FunctionCallNode node)
        {
            CurrentSymbolTable.currentTable.CheckIfExists(node.Name);
            node.AcceptChildren(this);
        }

        public void Visit(FunctionNode node)
        {
            CurrentSymbolTable.Insert(node.Identifier, node);

            CurrentSymbolTable.OpenScope();
            node.AcceptChildrenFrom(node.Params, this);
            node.AcceptChildren(this);
            node.SymbolTable = CurrentSymbolTable.currentTable;
            CurrentSymbolTable.CloseScope();
        }

        public void Visit(IdentfierNode node)
        {
            CurrentSymbolTable.currentTable.CheckIfExists(node.Symbol);
        }

        public void Visit(IfNode node)
        {
            node.Condition.Accept(this);

            node.AcceptChildren(this);

            if (node.Alternate != null)
            {
                node.AcceptChildrenFrom(node.Alternate, this);
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
            CurrentSymbolTable.currentTable.CheckIfExists(node.Identifier);
        }

        public void Visit(ParameterNode node)
        {
            CurrentSymbolTable.Insert(node.Identifier, node);
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
            node.Condition.Accept(this);
            node.AcceptChildren(this);
        }

        public void Visit(AstNode node)
        {
            return;
        }
    }
}