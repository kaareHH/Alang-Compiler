using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace core_compile
{
    class SymbolTable
    {
        public SymbolTable parent;
        public SymbolTable child;

        Hashtable hashTable = new Hashtable();

        public SymbolTable(Node astRoot)
        {
            ProcessNode(astRoot);
        }

        public SymbolTable()
        {

        }

        private void ProcessNode(Node node)
        {
            Symbol symbol;

            switch (node.type)
            {
                case "block":
                    
                    child = new SymbolTable();
                    break;

                case "Dcl":
                    this.Insert(node.name, node.type);
                    break;

                case "Ref":
                    symbol = this.LookUp(node.name);
                    if (symbol == null)
                    {
                        Console.WriteLine("Undeclared symbol: " + node.name);
                        throw new Exception();
                    }

                    break;

                default:
                    break;
            }

            foreach (var child in node.children)
            {
                ProcessNode(child);
            }

            if (node.type == block)
            {
                table = table.parent;
            }

        }


        public Symbol LookUp(string name)
        {
            Symbol sym = new Symbol();
            sym = (Symbol)hashTable[name];

            if (sym.name == name)
                return sym;

            else
            {
                sym = SearchParent(name, parent);

                if (sym == null)
                    throw new Exception("Undeclared variable: " + name);
                
                return sym;
            }
        }

        private Symbol SearchParent(string name, SymbolTable table)
        {
            Symbol sym = new Symbol();
            sym = (Symbol)table.hashTable[name];

            if (sym.name == null)
            {
                if (table.parent == null)
                    return null;
                    
                else
                    return SearchParent(name, table.parent);
            }

            else
                return sym;
        }

        public void Insert(string name, string type)
        {
            Symbol oldSym = new Symbol();
            Symbol newSym = new Symbol(name, type);

            oldSym = LookUp(name);

            if (oldSym != null)
                throw new Exception("Symbol already exists: " + name);
            
            if (oldSym == null)
                hashTable.Add(newSym.name, newSym);
        }
    }
}
