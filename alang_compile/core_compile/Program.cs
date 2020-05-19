using System;
using System.Linq;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using AntlrGen;
using core_compile.AbstractSyntaxTree;
using core_compile.Visitors;

namespace core_compile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Path: ");
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.ResetColor();
            Console.WriteLine("done");

            var fileName = args[0];
            var AbsolutePath = Path.GetFullPath(fileName);
            if (ReadFromFile(AbsolutePath, out var text)) return;

            try
            {
                var tokenStream = LexInputFile(text);
                var concreteSyntaxTree = ParseTokens(tokenStream);

                var ast = concreteSyntaxTree.Accept(new AstBuilderVisitor());
                ast.Accept(new SymbolTableVisitor());
                ast.Accept(new TypeCheckerVisitor());
                var codeGenVisitor = new CodeGenVisitor();
                ast.Accept(codeGenVisitor);

                var program = codeGenVisitor.Program;
                WriteProgramToFile(program, fileName);
            }
            catch (AntlrException ex)
            {
                // Antlr writes their own errors
            }
            catch (AlangExeption ex)
            {
                Console.WriteLine($"[{ex.Node.Start}]: {ex.Message}. Ends at [{ex.Node.Stop}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void WriteProgramToFile(string program, string fileName)
        {
            var newfileRaw = fileName.TrimEnd("alang".ToCharArray());
            var newFileFullPath = newfileRaw + "ino";
            using var file = new StreamWriter(newFileFullPath);
            file.Write(program);
        }
        
        private static bool ReadFromFile(string fileName, out string text)
        {
            text = "";
            
            Regex alangfile = new Regex(@".*\.alang?$");
        
            if (string.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("Please specify a filename as a parameter.");
                return false;
            }
        
            if (!alangfile.IsMatch(fileName))
            {
                Console.WriteLine("Please specify a .alang file");
                return false;
            }
        
            text = File.ReadAllText(fileName);
            return false;
        }

        private static ALangParser.StartContext ParseTokens(CommonTokenStream tokenStream)
        {
            ALangParser aLangParser = new ALangParser(tokenStream);
            ALangParser.StartContext startContext = aLangParser.start();
            if (aLangParser.NumberOfSyntaxErrors > 0)
                throw new AntlrException();
            return startContext;
        }
        
        private static CommonTokenStream LexInputFile(string text)
        {
            AntlrInputStream inputStream = new AntlrInputStream(text);
            ALangLexer aLangLexer = new ALangLexer(inputStream);
            CommonTokenStream aLangTokenStream = new CommonTokenStream(aLangLexer);
            return aLangTokenStream;
        }
    }

    public class AlangExeption : Exception 
    {
        public AstNode Node;

        public AlangExeption(AstNode node, string message) : base(message)
        {
            Node = node;
        }
    }

    internal class AntlrException : Exception
    {
    }
}