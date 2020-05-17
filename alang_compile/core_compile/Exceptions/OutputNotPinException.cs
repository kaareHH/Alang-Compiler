using System;
using core_compile.AbstractSyntaxTree;

namespace core_compile.Exceptions
{
    public class OutputNotPinException : Exception
    {
        public AstNode InvalidNode { get; }

        public OutputNotPinException(AstNode invalidNode)
        {
            InvalidNode = invalidNode;
        }
    }
}