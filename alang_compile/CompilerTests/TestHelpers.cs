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
        public static CompilationUnit MakeAstRoot(string text)
        {
            var tokenStream = LexInputFile(text);
            var parseTree = ParseTokens(tokenStream);
            return (CompilationUnit)new AstBuilderVisitor().VisitStart(parseTree);
        }

        public static AstNode GetChildOfIndex(AstNode parent, int index)
        {
            var child = parent.GetChildren();

            for (int i = 0; i < index; i++)
            {
                child = child.RightSibling;

                if (child == null)
                {
                    throw new Exception("Child list out of bounds!");
                }
            }

            return child;
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

        public static void AssertLocation(AstNode ast, int startLine, int startCol, int stopLine, int stopCol)
        {
            Assert.AreEqual(startLine, ast.Start.Line);
            Assert.AreEqual(stopLine, ast.Stop.Line);
            Assert.AreEqual(startCol, ast.Start.Column);
            Assert.AreEqual(stopCol, ast.Stop.Column);
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