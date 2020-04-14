using System;
using System.Linq;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using AntlrGen;

namespace core_compile
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "../../../testfile.alang";
            var AbsolutePath = Path.GetFullPath(filePath);
            if (ReadFromFile(AbsolutePath, out var text)) return;

            try
            {
                var tokenStream = LexInputFile(text);
                var concreteSyntaxTree = ParseTokens(tokenStream);
                var ast = new AstBuildVisitor().VisitStart(concreteSyntaxTree);
                var dia = new SemanticVisitor().Visit((StartNode) ast);
                List<string> errors = (List<string>) dia;
                Console.ForegroundColor = ConsoleColor.Red;
                errors.ForEach(Console.WriteLine);
                Console.ResetColor();

                if (!errors.Any())
                {
                    var smh = new PrettyPrintAstVisitor().Visit((StartNode)ast);
                    GenerateCode(concreteSyntaxTree);
                    CompileCCode("test.c");
                    RunCode();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);

            }
            
        }

        private static void CompileCCode(string filePath)
        {

            // TODO kig på om useren har gcc
            Process gccProcress = new Process
            {
                StartInfo =
                {
                    FileName = @"/usr/bin/gcc",
                    Arguments = filePath,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };
            gccProcress.Start();
            var output = gccProcress.StandardOutput.ReadToEnd(); //The output result
            gccProcress.WaitForExit();
        }
        
        private static void RunCode()
        {
            Process gccProcress = new Process
            {
                StartInfo =
                {
                    FileName = @"a.out",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };
            gccProcress.Start();
            var output = gccProcress.StandardOutput.ReadToEnd(); //The output result
            Console.WriteLine(output);
            gccProcress.WaitForExit();
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

        private static void GenerateCode(ALangParser.StartContext concreteSyntaxTree)
        {
            CodeGenVisitor codeGenVisitor = new CodeGenVisitor();
            codeGenVisitor.Visit(concreteSyntaxTree);
        }

        private static ALangParser.StartContext ParseTokens(CommonTokenStream tokenStream)
        {
            ALangParser aLangParser = new ALangParser(tokenStream);
            ALangParser.StartContext startContext = aLangParser.start();
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
}
