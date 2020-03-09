
using System;

namespace ParserService.Lexer
{
    public class OperatorToken : Token
    {
        private readonly string _terminal;

        public OperatorToken(string terminal)
        {
            _terminal = terminal;
        }
    }
}
