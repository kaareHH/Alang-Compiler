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
            CurrentSymbolTable.Insert("TIME", LanguageType.Time, new TimeNode());
            node.AcceptChildren(this);
            node.SymbolTable = CurrentSymbolTable.currentTable;
            CurrentSymbolTable.CloseScope();
        }

        public void Visit(DeclarationNode node)
        {
            CurrentSymbolTable.Insert(node.Identifier, node.Type, node);
        }

        public void Visit(AssignmentNode node)
        {
            node.Expression.Accept(this);
        }

        public void Visit(ExpressionNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
        }

        public void Visit(FunctionCallNode node)
        {
            node.AcceptChildren(this);
        }

        public void Visit(FunctionNode node)
        {
            CurrentSymbolTable.Insert(node.Identifier, node.Type, node);

            CurrentSymbolTable.OpenScope();
            node.AcceptSiblings(node.Params, this);
            node.AcceptChildren(this);
            node.SymbolTable = CurrentSymbolTable.currentTable;
            CurrentSymbolTable.CloseScope();
        }

        public void Visit(IdentfierNode node)
        {
        }

        public void Visit(IfNode node)
        {
            node.Condition.Accept(this);

            node.AcceptChildren(this);

            if (node.Alternate != null)
            {
                node.AcceptSiblings(node.Alternate, this);
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
            return;
        }

        public void Visit(ParameterNode node)
        {
            CurrentSymbolTable.Insert(node.Identifier, node.Type, node);
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

        public void Visit(ReturnNode node)
        {
            return;
        }

        public void Visit(AstNode node)
        {
            return;
        }
    }
}