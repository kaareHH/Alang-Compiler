using System.Reflection.Metadata;
using System.Net.Mail;
using System.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using core_compile.AbstractSyntaxTree;

namespace core_compile.SymbolTableClasses
{
    public class SymbolTable
    {
        public SymbolTable currentTable;
        public Hashtable Table;
        public SymbolTable parent;

        public SymbolTable(SymbolTable newsym)
        {

            Table = new Hashtable();
            parent = newsym;
        }

        public Symbol Get(string name, SymbolTable symbolTable)
        {
            // for (SymbolTable symbolTable = currentTable; symbolTable != null; symbolTable = symbolTable.parent)
            // {
            //     if (symbolTable.Contains(name))
            //         return symbolTable.Table[name] as Symbol;
            // }
            while (symbolTable != null)
            {
                if (symbolTable.Contains(name))
                {
                    return symbolTable.Table[name] as Symbol;
                }
                symbolTable = symbolTable.parent;
            }

            throw new SymbolDoNotExistException();
        }


        public LanguageType asGet(string name, SymbolTable symbolTable)
        {
            while (symbolTable != null)
            {
                if (symbolTable.Contains(name))
                {
                    System.Console.WriteLine(symbolTable.Table[name]);
                    return (LanguageType)symbolTable.Table[name];
                }
                symbolTable = symbolTable.parent;
            }
            throw new SymbolDoNotExistException();
        }

        public bool Lookup(string name)
        {
            SymbolTable symbolTable = this;
            while (symbolTable != null)
            {
                if (symbolTable.Contains(name))
                {
                    return true;
                }
                symbolTable = symbolTable.parent;
            }

            return false;
        }

        public void CheckIfExists(string name)
        {
            // if (!CurrentSymbolTable.currentTable.Lookup(node.FunctionToBeCalled))
            //     throw new SymbolDoNotExistException();
            SymbolTable symbolTable = this;    
            while (symbolTable != null)
            {
                if (symbolTable.Contains(name))
                {
                    return;
                }
                symbolTable = symbolTable.parent;
            }

            throw new SymbolDoNotExistException();
        }

        public void Insert(string name, LanguageType type, AstNode node)
        {
            if (currentTable.Contains(name))
                throw new SymbolExistException();
            
            var newsymbol = new Symbol(name, type, node);
            currentTable.Table.Add(name, newsymbol);
        }

        public void OpenScope()
        {
            Console.WriteLine("Opening scope");
            currentTable = new SymbolTable(currentTable);
        }

        public void CloseScope()
        {
            Console.WriteLine("Closing Scope");
            currentTable = currentTable.parent;
        }

        private bool Contains(string name)
        {
            System.Console.WriteLine("Checking for " + name + " in symboltable with: " + Table?.Count + " entries" + ". Parent count: " + parent?.Table.Count);
            return Table.Contains(name);
        }

    }

    public class SymbolExistException : Exception
    {
    }

    public class SymbolDoNotExistException : Exception
    {

    }
}