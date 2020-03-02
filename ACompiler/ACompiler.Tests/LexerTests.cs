using System;
using System.Collections.Generic;
using Xunit;

namespace ACompiler.Tests
{
    public class LexTests
    {
        [Theory]
        [InlineData("2")]
        [InlineData("31")]
        [InlineData("34678")]
        public void LexNumberToken(string line)
        {
            var lexer = new Lexer(line);
            var token = lexer.Lex();
            Assert.IsType<SyntaxToken>(token);
            Assert.Equal(SyntaxKind.NumberToken, token.Kind);
        }

        [Fact]
        public void LexPlusToken()
        {
            var lexer = new Lexer("+");
            var token = lexer.Lex();
            Assert.IsType<SyntaxToken>(token);
            Assert.Equal(SyntaxKind.PlusToken, token.Kind);
        }

        [Fact]
        public void LexNumberPlusAndWhiteSpaceToken()
        {
            var lexer = new Lexer("2 + 2");
            SyntaxToken token;
            List<SyntaxToken> tokens = new List<SyntaxToken>();

            do
            {
                token = lexer.Lex();
                tokens.Add(token);

            } while (token.Kind != SyntaxKind.EndOfFileToken || token.Kind != SyntaxKind.EndOfFileToken);

            var expected = new List<SyntaxToken>()
            {
                new SyntaxToken(SyntaxKind.NumberToken, 0, "2", 2),
                new SyntaxToken(SyntaxKind.WhitespaceToken, 1, " ", null),
                new SyntaxToken(SyntaxKind.PlusToken, 2, "+", null),
                new SyntaxToken(SyntaxKind.WhitespaceToken, 3, " ", null),
                new SyntaxToken(SyntaxKind.NumberToken, 4, "2", 2),
                new SyntaxToken(SyntaxKind.EndOfFileToken, 5, "\0", null)

            };
            Assert.Equal(6, tokens.Count);
            Assert.Equal(expected[0].Kind, tokens[0].Kind);
            Assert.Equal(expected[1].Kind, tokens[1].Kind);
            Assert.Equal(expected[2].Kind, tokens[2].Kind);
            Assert.Equal(expected[3].Kind, tokens[3].Kind);
            Assert.Equal(expected[4].Kind, tokens[4].Kind);
            Assert.Equal(expected[5].Kind, tokens[5].Kind);
        }
    }
}
