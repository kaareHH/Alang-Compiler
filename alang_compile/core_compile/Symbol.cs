using System;
using System.Collections.Generic;
using System.Text;

namespace core_compile
{
    public class Symbol
    {        
        public string name;
        public string type;
        public int scopeLevel;

        public Symbol(string name, string type, int scopeLevel)
        {
            this.name = name;
            this.type = type;
            this.scopeLevel = scopeLevel;
        }
        public Symbol()
        {

        }
    }
}
