using System;
using System.Collections.Generic;
using System.Text;
using core_compile.AbstractSyntaxTree;

namespace core_compile.SymbolTableClasses
{
    public class Symbol
    {
        public string Name;
        public LanguageType Type;

        public Symbol(string name, LanguageType type)
        {
            this.Name = name;
            this.Type = type;
        }

        public Symbol()
        {

        }
    }
}