using System;
using core_compile.AbstractSyntaxTree;

namespace core_compile.Exceptions
{
    public class TooManyArgumentsException : Exception
    {
        public AstNode Param { get; }

        public TooManyArgumentsException(AstNode param)
        {
            Param = param;
        }
    }
}