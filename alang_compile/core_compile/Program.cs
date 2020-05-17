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
            //Console.WriteLine(Path.GetFullPath(s));
            
            Console.ResetColor();
            Console.WriteLine("done");

            var filePath = args[0];
            var AbsolutePath = Path.GetFullPath(filePath);
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

                var program = codeGenVisitor.program;
                Console.WriteLine(program);
            }
            catch (AntlrException ex)
            {
                // Antlr writes their own errors
            }
            catch (AlangExeption ex)
            {
                Console.WriteLine($"line {ex.Node.Start} {ex.Message}");
            }
        }

        // private static void CompileCCode(string filePath)
        // {
        //
        //     // TODO kig på om useren har gcc
        //     Process gccProcress = new Process
        //     {
        //         StartInfo =
        //         {
        //             FileName = @"/usr/bin/gcc",
        //             Arguments = filePath,
        //             UseShellExecute = false,
        //             RedirectStandardOutput = true,
        //             WindowStyle = ProcessWindowStyle.Hidden,
        //             CreateNoWindow = true
        //         }
        //     };
        //     gccProcress.Start();
        //     var output = gccProcress.StandardOutput.ReadToEnd(); //The output result
        //     gccProcress.WaitForExit();
        // }
        //
        // private static void RunCode()
        // {
        //     Process gccProcress = new Process
        //     {
        //         StartInfo =
        //         {
        //             FileName = @"a.out",
        //             UseShellExecute = false,
        //             RedirectStandardOutput = true,
        //             WindowStyle = ProcessWindowStyle.Hidden,
        //             CreateNoWindow = true
        //         }
        //     };
        //     gccProcress.Start();
        //     var output = gccProcress.StandardOutput.ReadToEnd(); //The output result
        //     Console.WriteLine(output);
        //     gccProcress.WaitForExit();
        // }
        //
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
