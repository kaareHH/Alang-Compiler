using Antlr4.Runtime;
using AntlrGen;
using core_compile.Visitors;
using NUnit.Framework;
using core_compile.AbstractSyntaxTree;
using System.Text.RegularExpressions;
using System;
using System.IO;

namespace CompilerTests
{
    public static class TestHelpers
    {
        public static CompilationNode MakeAstRoot(string text)
        {
            var tokenStream = LexInputFile(text);
            var parseTree = ParseTokens(tokenStream);
            return (CompilationNode)new AstBuilderVisitor().VisitStart(parseTree);
        }

        public static CommonTokenStream LexInputFile(string text)
        {
            AntlrInputStream inputStream = new AntlrInputStream(text);
            ALangLexer aLangLexer = new ALangLexer(inputStream);
            CommonTokenStream aLangTokenStream = new CommonTokenStream(aLangLexer);
            return aLangTokenStream;
        }

        public static ALangParser.StartContext ParseTokens(CommonTokenStream tokenStream)
        {
            ALangParser aLangParser = new ALangParser(tokenStream);
            ALangParser.StartContext startContext = aLangParser.start();
            return startContext;
        }
        

        public static bool ReadFromFile(string fileName, out string text)
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
    }

}