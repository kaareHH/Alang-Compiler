using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;

namespace ParserService.Lexer
{
    public class TokenStream
    {
        private Token nextToken;
        private readonly TokenFactory _tokenFactory;

        public TokenStream(CharStream charStream)
        {
            _tokenFactory = new TokenFactory(charStream);
        }

        public Token Peek() => nextToken;

        public Token Advance()
        {
            Token answer = nextToken;
            nextToken = _tokenFactory.Lex();
            return answer;
        }
    }

    public abstract class Token
    {
    }
}
