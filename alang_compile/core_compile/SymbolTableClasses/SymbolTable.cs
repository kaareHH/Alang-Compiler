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

        public LanguageType GetOld(string name)
        {
            System.Console.WriteLine("ged");
            for (SymbolTable symbolTable = currentTable; symbolTable != null; symbolTable = symbolTable.parent)
            {
                System.Console.WriteLine("peter");
                if (Contains(name))
                {
                    System.Console.WriteLine(symbolTable.Table[name]);
                    // return LanguageType.Null;

                    return (LanguageType)symbolTable.Table[name];
                }
                else
                    return LanguageType.Null;
            }

            throw new SymbolDoNotExistException();
        }


        public LanguageType Get(string name, SymbolTable symbolTable)
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

        public void Insert(string name, LanguageType type)
        {
            Console.WriteLine("Insert: " + name);
            if (currentTable.Contains(name))
                throw new SymbolExistException();
            currentTable.Table.Add(name, type);
            Console.WriteLine("Inserting: " + type + " " + currentTable.Table.Count);
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