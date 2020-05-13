using System.Reflection.Metadata;
using System.Net.Mail;
using System.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using core_compile.AbstractSyntaxTree;

namespace core_compile
{
    public class SymbolTable
    {
        public SymbolTable currentTable;
        private Hashtable Table;
        private SymbolTable parent;

        public SymbolTable (SymbolTable newsym)
        {

            Table = new Hashtable();
            parent = newsym;
        }
        
        public AstNode Get(string name)
        {
            for (SymbolTable symbolTable = currentTable; symbolTable != null ; symbolTable = symbolTable.parent)
            {
                if (Contains(name))
                    return symbolTable.Table[name] as AstNode;
            }

            throw new SymbolDoNotExistException(name);
        }

        public void Insert(string name, AstNode node)
        {         
            if(Contains(name))
                throw new SymbelExistException();
            currentTable.Table.Add(name, node);
        }
        
        public void OpenScope()
        {
            currentTable = new SymbolTable(currentTable);
        }
        
        public void CloseScope()
        {
            currentTable = currentTable.parent;
        }

        private bool Contains(string name)
        {
            return currentTable.Table.Contains(name);
        }

        
    }

    public class SymbelExistException : Exception
    {
    }
    
    public class SymbolDoNotExistException : Exception
    {
        public SymbolDoNotExistException(string newSymbol)
        {
            throw new NotImplementedException();
        }
    }
}
