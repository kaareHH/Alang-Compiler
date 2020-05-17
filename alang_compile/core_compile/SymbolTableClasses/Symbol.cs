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
        public AstNode Node;

        public Symbol(string name, LanguageType type, AstNode node)
        {
            this.Name = name;
            this.Type = type;
            Node = node;
        }

        public Symbol()
        {

        }
    }
}