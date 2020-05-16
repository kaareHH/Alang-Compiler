using System;
using core_compile.AbstractSyntaxTree;

namespace core_compile.Exceptions
{
    public class TooFewArgumentsException : Exception
    {
        public AstNode ExpectedParam { get; }

        public TooFewArgumentsException(AstNode expectedParam)
        {
            ExpectedParam = expectedParam;
        }
    }
}