using System;
using core_compile.AbstractSyntaxTree;

namespace core_compile.Exceptions
{
    public class InvalidExpressionException : Exception
    {
        public Operator NodeOperator { get; }
        public LanguageType Left { get; }
        public LanguageType Right { get; }

        public InvalidExpressionException(Operator nodeOperator, LanguageType left, LanguageType right)
        {
            NodeOperator = nodeOperator;
            Left = left;
            Right = right;
        }
    }
}