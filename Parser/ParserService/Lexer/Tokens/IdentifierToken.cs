using System;

namespace ParserService.Lexer
{
    public class IdentifierToken : Token
    {
        private readonly string _terminal;

        public IdentifierToken(string terminal)
        {
            _terminal = terminal;
        }
    }
}
