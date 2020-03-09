using System;

namespace ParserService.Lexer
{
    internal class NumberToken : Token
    {
        private readonly int _valueInInt;

        public NumberToken(in int valueInInt)
        {
            _valueInInt = valueInInt;
        }
    }
}
