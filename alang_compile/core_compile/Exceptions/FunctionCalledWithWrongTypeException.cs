using System;
using core_compile.AbstractSyntaxTree;

namespace core_compile.Exceptions
{
    public class FunctionCalledWithWrongTypeException : Exception
    {
        public LanguageType ShouldBeType { get; }
        public LanguageType Actualtype { get; }

        public FunctionCalledWithWrongTypeException(LanguageType shouldBeType, LanguageType actualtype)
        {
            ShouldBeType = shouldBeType;
            Actualtype = actualtype;
        }
    }
}