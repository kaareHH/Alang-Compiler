using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace core_compile
{
    class SymbolTable
    {        
        int currentScopeLevel;

        Hashtable hashTable = new Hashtable();

        // HØRER TIL I VISITOR???
        /* 
        public SymbolTable(Node astRoot)
        {
            ProcessNode(astRoot);
        }

        public void ProcessNode(node)
        {
            string symbol;

            switch (node.type)
            {
                case "block":
                    OpenScope();
                    break;

                case "Dcl":
                    EnterSymbol(node.name, node.type);
                    break;

                case "Ref":
                    symbol = RetriveSymbol(node.name);
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
                CloseScope();
            }

        }
        */

        private Symbol LookUp(string name)
        {
            Symbol sym = new Symbol();

            sym = (Symbol)hashTable[name];

            if (sym.name == name)
                return sym;

            else
                throw new Exception("Undeclared variable: " + name);
        }

        private void Insert(string name, string type)
        {
            Symbol oldSym = new Symbol();
            Symbol newSym = new Symbol(name, type, currentScopeLevel);

            oldSym = LookUp(name);

            if (oldSym != null && oldSym.scopeLevel == currentScopeLevel)
                throw new Exception("Symbol already exists: " + name);
            
            if (oldSym == null)
                hashTable.Add(newSym.name, newSym);
        }

        private void OpenScope()
        {
            throw new NotImplementedException();
        }

        private void CloseScope()
        {
            throw new NotImplementedException();
        }
    }
}
