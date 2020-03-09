using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserService;
using ParserService.Lexer;
using ParserService.Lexer.Tokens;

namespace ParseService.Test
{
    [TestClass]
    public class TokenFactoryTest
    {
        [TestMethod]
        public void ReadAllTokensFromtest1Good()
        {
            var charStream = new CharStream(new StreamReader("../../../../ParserService/TestFiles/test1.good"));
            var factory = new TokenStream(charStream);

            int amountOfTokens = 0;
            while (!(factory.Peek() is EndOfFileToken))
            {
                factory.Advance();
                amountOfTokens++;
            }

            int TokensInFile = 37;
            Assert.Equals(TokensInFile, amountOfTokens);




        }
    }
}
