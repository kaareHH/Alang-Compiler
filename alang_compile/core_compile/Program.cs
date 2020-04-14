using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace core_compile
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable gordon = new Hashtable();

            Symbol asd = new Symbol("berit", "int", 5);
            Symbol hej = new Symbol();

            gordon.Add(asd.name, asd);

            Console.WriteLine(((Symbol)gordon[asd.name]).name);
        }

    }
}
