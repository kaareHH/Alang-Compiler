using System.Reflection.Metadata;
using System.Net.Mail;
using System.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace core_compile
{
    class SymbolTable
    {
        private SymbolTable parent;
        private SymbolTable currentTable = new SymbolTable();
    
        private Hashtable hashtable = new Hashtable();

        public Hashtable Table {get => currentTable.hashtable;}

        private SymbolTable (SymbolTable parent)
        {
            this.parent = parent;
        }

        private SymbolTable() { }


        public static SymbolTable BuildFromAstRoot(Node AstRoot)
        {
            var currentTable = new SymbolTable();
            currentTable.ProcessNode(AstRoot);

            return currentTable;

        }

        private void ProcessNode(Node node)
        {
            Symbol newSymbol = ConvertNodeToSymbol(node);
            switch (node.type)
            {
                case "Block":
                    OpenScope();
                    break;

                case "Dcl":
                    Insert(newSymbol);
                    break;

                case "Ref":
                    if (!LookUp(newSymbol))
                        throw new SymbolDoNotExistException(newSymbol);
                    break;

                default:
                    break;
            }

            foreach (var child in node.children)
            {
                ProcessNode(child);
            }

            if (node.type == "Block")
            {
                CloseScope();
            }
        }


        private Symbol ConvertNodeToSymbol(Node node)
        {
            return new Symbol(node.name, node.type);
        }

        public bool LookUp(Symbol symbol)
        {
            for (SymbolTable currentTable = this.currentTable; currentTable != null ; currentTable = currentTable.parent)
            {
                if (ContainsSymbol(symbol))
                    return true;
            }

            return false;
        }

        
        public Symbol Get(string name)
        {
            for (SymbolTable currentTable = this; currentTable != null ; currentTable = currentTable.parent)
            {
                if (ContainsSymbolByName(name))
                    return GetSymbolFromHashTable(name);
            }

            throw new SymbolDoNotExistException();
        }

        public void Insert(Symbol newsymbol)
        {         
            if(ContainsSymbol(newsymbol))
                throw new SymbelExistException();
            
            AddSymbolToTable(newsymbol);    
        }

        private void AddSymbolToTable(Symbol symbol)
        {
            Table.Add(symbol.name, symbol.type);
        }

        public SymbolTable MakeChildFromThis()
        {
            return new SymbolTable(this);
        }    

        public void OpenScope()
        {
            currentTable = MakeChildFromThis();
        }
        
        public void CloseScope()
        {
            currentTable = parent;
        }

        private bool ContainsSymbol(Symbol symbol)
        {
            return Table.Contains(symbol.name);
        }

        private bool ContainsSymbolByName(string name)
        {
            return Table.Contains(name);
        }

        private Symbol GetSymbolFromHashTable(string name)
        {
            return (Symbol)Table[name];
        }

    }
}
