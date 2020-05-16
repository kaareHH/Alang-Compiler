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
            // System.Console.WriteLine("Visiting compilationNode" + node.SymbolTable);
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
            var type = CurrentSymbolTable.Get(node.Identifier, CurrentSymbolTable);
            if (type != node.Expression.Accept(this))
                throw new Exception("Cannot assign type of " + node.Expression.Accept(this) + " to variable of type " + type);
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
            // System.Console.WriteLine("gedgedged" + node.Name);
            // System.Console.WriteLine("ostostost" + node.LeftMostChild);

            // node.AcceptChildren(this);
            // System.Console.WriteLine(node.AcceptChildren(this));
            // System.Console.WriteLine("gedgedged" + node.NumberOfChildren);

            System.Console.WriteLine("Function call node: ");
            foreach (DictionaryEntry item in CurrentSymbolTable.Table)
            {
                System.Console.WriteLine(item.Key + ": " + item.Value);
            }


            node.AcceptChildren(this);
            return LanguageType.Null;
        }

        public LanguageType Visit(FunctionNode node)
        {
            CurrentSymbolTable = node.SymbolTable;
            node.AcceptChildrenFrom(node.Params, this);
            node.AcceptChildren(this);
            foreach (DictionaryEntry item in CurrentSymbolTable.Table)
            {
                System.Console.WriteLine(item.Key + ": " + item.Value);
            }
            CurrentSymbolTable = node.SymbolTable.parent;

            return LanguageType.Null;
        }

        public LanguageType Visit(IdentfierNode node)
        {
            var type = CurrentSymbolTable.Get(node.Symbol, CurrentSymbolTable);
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
            // Lav tjek her
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
            // verificer at der er tale om en pin
        
            return LanguageType.Null;
        }

        public LanguageType Visit(ParameterNode node)
        {
            System.Console.WriteLine("param: " + node.Identifier);
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
         //   Console.WriteLine("fadervor: " + ((FunctionCallNode)node.Parent).Name);

            if (node.Value.GetType() == typeof(TimeNode))
                return LanguageType.Time;
            if (node.Value.GetType() == typeof(IntNode))
                return LanguageType.Int;
            if (node.Value.GetType() == typeof(PinNode))
                return LanguageType.Pin;
            return LanguageType.Null;
        }

        public LanguageType Visit(WhileNode node)
        {
            // lav tjek her
            return LanguageType.Null;
        }

        public LanguageType Visit(AstNode node)
        {
            return LanguageType.Null;
        }
    }
}