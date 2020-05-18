using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using core_compile.AbstractSyntaxTree;
using core_compile.Exceptions;
using core_compile.SymbolTableClasses;
using InvalidExpressionException = core_compile.Exceptions.InvalidExpressionException;

namespace core_compile.Visitors
{
    // TODO: Add reserved keywords to symboltable
    public class TypeCheckerVisitor : ITypeCheckerVisitor
    {
        public SymbolTable CurrentSymbolTable { get; set; }

        public LanguageType Visit(CompilationNode node)
        {
            // System.Console.WriteLine("Visiting compilationNode" + node.SymbolTable);
            CurrentSymbolTable = node.SymbolTable;
            node.AcceptChildren(this);
            return LanguageType.Void;
        }

        public LanguageType Visit(DeclarationNode node)
        {
            // System.Console.WriteLine("Visiting dclNode");
            var exprType = node.RightHandSide.Accept(this);
            if (exprType != node.Type)
            {
                throw new AlangExeption(node, "declareType " + node.Type + " cannot be used with type" + exprType);
            }

            return exprType;
        }

        public LanguageType Visit(AssignmentNode node) 
        {
            var symbol = CurrentSymbolTable.Get(node.Identifier, CurrentSymbolTable);
            var type = symbol.Type;
            if (type != node.Expression.Accept(this))
                throw new AlangExeption(node, "cannot assign type of " + node.Expression.Accept(this) + " to variable of type " + type);
            return LanguageType.Null;
        }

        public LanguageType Visit(ExpressionNode node)
        {
            var leftType = node.Left.Accept(this);
            var rightType = node.Right.Accept(this);
            
            if (leftType == rightType)
                return leftType;
            throw new InvalidExpressionException(node.Operator,leftType, rightType);
        }

        public LanguageType Visit(FunctionCallNode node)
        {
            var functionNode = CurrentSymbolTable.Get(node.Name, CurrentSymbolTable).Node as FunctionNode;
            var child = functionNode.Params;
            var paramchildren = node.GetChildren();
            while (child != null)
            {
                if (paramchildren == null)
                    throw new TooFewArgumentsException(child);
                var ShouldBeType = child.Accept(this);
                var actualtype = paramchildren.Accept(this);

                if (ShouldBeType != actualtype)
                    throw new FunctionCalledWithWrongTypeException(ShouldBeType, actualtype);
                
                child = child.RightSibling;
                paramchildren = paramchildren.RightSibling;
            }

            if (paramchildren != null)
                throw new TooManyArgumentsException(paramchildren);
            return LanguageType.Null;
        }

        public LanguageType Visit(FunctionNode node)
        {
            CurrentSymbolTable = node.SymbolTable;
            node.AcceptSiblings(node.Params, this);
            node.AcceptChildren(this);
            CurrentSymbolTable = node.SymbolTable.parent;

            return LanguageType.Null;
        }

        public LanguageType Visit(IdentfierNode node)
        {
            var symbol = CurrentSymbolTable.Get(node.Symbol, CurrentSymbolTable);
            var type = symbol.Type;
            if (type == LanguageType.Int)
                return LanguageType.Int;
            if (type == LanguageType.Time)
                return LanguageType.Time;
            if (type == LanguageType.Pin)
                return LanguageType.Pin;
            return LanguageType.Null;
        }

        public LanguageType Visit(IfNode node)
        {
            var condtype = node.Condition.Accept(this);
            if (condtype != LanguageType.Int && condtype != LanguageType.Time)
                throw new TypeDoNotMatchConditionException(condtype);
            node.AcceptChildren(this);
            node.AcceptSiblings(node.Alternate, this);
            return LanguageType.Null;
        }

        public LanguageType Visit(ImportNode node)
        {
            return LanguageType.Null;
        }

        public LanguageType Visit(IntNode node)
        {
            return LanguageType.Int;
        }

        public LanguageType Visit(NullNode node)
        {
            return LanguageType.Null;
        }

        public LanguageType Visit(OutputNode node)
        {
            var idNode = CurrentSymbolTable.Get(node.Identifier, CurrentSymbolTable);
            if (idNode.Type != LanguageType.Pin)
                throw new OutputNotPinException(node);
            return LanguageType.Null;
        }

        public LanguageType Visit(ParameterNode node)
        {
            return node.Type;
        }

        public LanguageType Visit(PinNode node)
        {
            return LanguageType.Pin;
        }

        public LanguageType Visit(TimeNode node)
        {
            return LanguageType.Time;
        }

        public LanguageType Visit(ValueNode node)
        {
            return node.Value.Accept(this);
        }

        public LanguageType Visit(WhileNode node)
        {
            var condtype = node.Condition.Accept(this);
            if (condtype != LanguageType.Int && condtype != LanguageType.Time)
                throw new TypeDoNotMatchConditionException(condtype);
            node.AcceptChildren( this);
            return LanguageType.Null;
        }

        public LanguageType Visit(ReturnNode node)
        {
            var iterator = node.Parent;
            while (iterator != null)
            {
                if (iterator is FunctionNode func)
                {
                    if (func.Type != node.Value.Accept(this))
                        throw new AlangExeption(node, "Not equal types");
                    else
                        return LanguageType.Null;
                }
                iterator = iterator.Parent;
            }
            throw new Exception("Return not in function");
        }

        public LanguageType Visit(AstNode node)
        {
            return LanguageType.Null;
        }
    }
}