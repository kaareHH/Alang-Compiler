using System;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;
using core_compile.AbstractSyntaxTree;
using core_compile.SymbolTableClasses;

namespace core_compile.Visitors
{
    // TODO: Add reserved keywords to symboltable
    public class TypeCheckerVisitor : ITypeCheckerVisitor
    {
        public SymbolTable CurrentSymbolTable { get; set; }

        public LanguageType Visit(CompilationNode node)
        {
            // System.Console.WriteLine("Visiting compilationNode");
            CurrentSymbolTable = node.SymbolTable;
            return node.AcceptChildren(this);
        }

        public LanguageType Visit(DeclarationNode node)
        {
            // System.Console.WriteLine("Visiting dclNode");
            var exprType = node.PrimaryExpression.Accept(this);

            if (exprType != node.Type)
            {
                throw new Exception("DeclareType " + node.Type + " cannot be used with type" + exprType);
            }

            return exprType;
        }

        public LanguageType Visit(AssignmentNode node)
        {
            // var type = CurrentSymbolTable.Get(node.Identifier);
            //
            // if (LanguageType.Int != node.Expression.Accept(this))
            //     throw new Exception("Ont wrong");
            return LanguageType.Null;
        }

        public LanguageType Visit(ExpressionNode node)
        {
            var leftType = node.Left.Accept(this);
            var rightType = node.Right.Accept(this);
            
            

            if (leftType == rightType)
                return leftType;
            throw new Exception("Operator: " + node.Operator + " cannot be used with " + leftType + " and " + rightType);
        }

        public LanguageType Visit(FunctionCallNode node)
        {
            return LanguageType.Null;
        }

        public LanguageType Visit(FunctionNode node)
        {
            // CurrentSymbolTable = node.SymbolTable;
            // // Code here
            // CurrentSymbolTable = node.SymbolTable.parent;
            return LanguageType.Null;
        }

        public LanguageType Visit(IdentfierNode node)
        {
            var type = CurrentSymbolTable.Get(node.Symbol);
            if (type is IntNode)
                return LanguageType.Int;
            if (type is TimeNode)
                return LanguageType.Time;
            if (type is PinNode)
                return LanguageType.Pin;
            return LanguageType.Null;
        }

        public LanguageType Visit(IfNode node)
        {
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
            return LanguageType.Null;
        }

        public LanguageType Visit(ParameterNode node)
        {
            return LanguageType.Null;
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
            return LanguageType.Null;
        }

        public LanguageType Visit(WhileNode node)
        {
            return LanguageType.Null;
        }

        public LanguageType Visit(AstNode node)
        {
            return LanguageType.Null;
        }
    }
}