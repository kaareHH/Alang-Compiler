using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace ParserService
{
    public class Lexer
    {
        private Tokenfactory Tokenizer { get; set; } = new FirstTokenFactory();
        private StringBuffer _stringBuffer;
        private Lexer(StringBuffer strBuf)
        {
            _stringBuffer = strBuf;
        }

        public static Lexer FromStringBuffer(StringBuffer stringBuffer)
        {
            return new Lexer(stringBuffer);
        }
        public List<Token> Lex(StringBuffer stringBuffer)
        {
            var TokenList = new List<Token>();
            while (!stringBuffer.EOF())
            {
                TokenList.Add(Scan());
            }

            return TokenList;
        }

        private Token Scan()
        {
            while (_stringBuffer.peek() != StringBuffer.BLANK) {
                _stringBuffer.advance();
            }

            if (_stringBuffer.EOF())
            {
                return new EndOfFileToken();
            }

            if (Char.IsDigit(_stringBuffer.peek()))
            {
                return ScanDigits();
            }
            else
            {
                return Tokenizer.TokenIdentifier(_stringBuffer.advance());
            }

        }

        private Token ScanDigits()
        {
            throw new NotImplementedException();
        }
    }

    class EndOfFileToken : Token
    {
    }
}
