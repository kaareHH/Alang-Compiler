using Antlr4.Runtime;
using AntlrGen;
using NUnit.Framework;
using core_compile;
using core_compile.Visitors;

namespace CompilerTests
{
    public class AstTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AstDclTest()
        {
            var cst = MakeCst("import torben.alang;");
            var ast = new AstBuilderVisitor().VisitStart(cst);
        }

        private ALangParser.StartContext MakeCst(string text)
        {
            var tokenStream = LexInputFile(text);
            return ParseTokens(tokenStream);
        }
        
        
        private static CommonTokenStream LexInputFile(string text)
        {
            AntlrInputStream inputStream = new AntlrInputStream(text);
            ALangLexer aLangLexer = new ALangLexer(inputStream);
            CommonTokenStream aLangTokenStream = new CommonTokenStream(aLangLexer);
            return aLangTokenStream;
        }
        
        private static ALangParser.StartContext ParseTokens(CommonTokenStream tokenStream)
        {
            ALangParser aLangParser = new ALangParser(tokenStream);
            ALangParser.StartContext startContext = aLangParser.start();
            return startContext;
        }
    }
}