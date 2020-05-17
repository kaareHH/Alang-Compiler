using System;
using core_compile.AbstractSyntaxTree;

namespace core_compile.Exceptions
{
    public class TypeDoNotMatchConditionException : Exception
    {
        public LanguageType InvalidType { get; }

        public TypeDoNotMatchConditionException(LanguageType InvalidType)
        {
            this.InvalidType = InvalidType;
        }
    }
}