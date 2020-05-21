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
            CurrentSymbolTable = node.SymbolTable;
            node.AcceptChildren(this);
            return LanguageType.Void;
        }

        public LanguageType Visit(DeclarationNode node)
        {
            if (node.RightHandSide != null)
            {
                var exprType = node.RightHandSide.Accept(this);
                if (exprType != node.Type)
                {
                    throw new AlangExeption(node, $"declared type {node.Type.ToLower()} cannot be used with type {exprType.ToLower()}");
                }
            }
                

            return node.Type;
        }

        public LanguageType Visit(AssignmentNode node) 
        {
            var symbol = CurrentSymbolTable.Get(node.Identifier, CurrentSymbolTable);
            var type = symbol.Type;
            if (type == LanguageType.Pin)
                throw new AlangExeption(node, "Pins in alang are constants, and cannot be reassign at runtime");
            if (type != node.Expression.Accept(this))
                throw new AlangExeption(node,
                    $"cannot assign type of {node.Expression.Accept(this).ToLower()} to type {type.ToLower()} on declared variable {node.Identifier}");
            return LanguageType.Null;
        }

        public LanguageType Visit(ExpressionNode node)
        {
            var leftType = node.Left.Accept(this);
            var rightType = node.Right.Accept(this);
            if (leftType == rightType)
                return leftType;
            throw new AlangExeption(node, $"cannot apply expression on type {leftType.ToLower()} and {rightType.ToLower()}");
        }

        public LanguageType Visit(FunctionCallNode node)
        {
            var functionNode = CurrentSymbolTable.Get(node.Name, CurrentSymbolTable).Node as FunctionNode;
            var child = functionNode.Params;
            var paramchildren = node.GetChildren();
            while (child != null)
            {
                if (paramchildren == null)
                    throw new AlangExeption(node, $"Too few arguments, in {functionNode.Identifier}. Should have been {functionNode.Params.NumberOfSiblings} number of argument, but was {node.NumberOfChildren}");
                var ShouldBeType = child.Accept(this);
                var actualtype = paramchildren.Accept(this);

                if (ShouldBeType != actualtype)
                    throw new AlangExeption(node, $"Argument at {paramchildren.Start} is type {actualtype.ToLower()}, but should be {ShouldBeType.ToLower()}");
                
                child = child.RightSibling;
                paramchildren = paramchildren.RightSibling;
            }

            if (paramchildren != null)
                throw new AlangExeption(node, $"Too many arguments, in {functionNode.Identifier}. Should have been {functionNode.Params.NumberOfSiblings} number of argument, but was {node.NumberOfChildren}");
            return functionNode.Type;
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
                throw new AlangExeption(node, $"Condition in if statement is {condtype.ToLower()}, and should be either int or time");
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
                throw new AlangExeption(node, $"{idNode.Type.ToLower()} is used in output statement, but should be pin");
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
                throw new AlangExeption(node, $"Condition in while statement is {condtype.ToLower()}, and should be either int or time");

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
                    var languageType = node.Value.Accept(this);
                    if (func.Type != languageType)
                        throw new AlangExeption(node, $"Type {languageType.ToLower()} do not match function type, {func.Identifier}'s return type is {func.Type.ToLower()}");
                    else
                        return LanguageType.Null;
                }
                iterator = iterator.Parent;
            }

            return LanguageType.Null;
        }

        public LanguageType Visit(AstNode node)
        {
            return LanguageType.Null;
        }
    }
}