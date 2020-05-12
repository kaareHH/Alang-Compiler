using System;
using System.Collections.Generic;
using System.Text;

namespace core_compile
{
    public class Symbol
    {        
        public string name;
        public string type;

        public Symbol(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public Symbol()
        {

        }
    }
}
