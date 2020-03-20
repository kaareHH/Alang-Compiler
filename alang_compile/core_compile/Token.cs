using System;
using System.Collections.Generic;
using System.Text;

namespace core_compile
{
    public enum TokenType
    {
        T_INTLIT, T_INTDCL, T_PINDCL, T_OUTPUTPIN, T_INPUTPIN, T_ID, T_SEMICOLON,
        T_ON, T_OFF, T_TOGGLE,
        T_PLUS, T_MINUS, T_MULTIPLY, T_DIVIDE, T_EQUAL, 
        T_IF, T_ENDIF, T_REPEAT, T_ENDREPEAT, T_TIMES, T_THEN, 
        T_PARANBEGIN, T_PARANEND, T_WHITESPACE,
        T_BADTOKEN
        /*T_PINLIT, T_BEGINSCOPE, T_ENDSCOPE, T_START */
    }

    public class Token
    {
        public Token(TokenType newTokenType, string newTokenValue)
        {
            this.TokenValue = newTokenValue;
            this.TokenType = newTokenType;
        }

        public TokenType TokenType { get; set; }
        public string TokenValue { get; set; }
    }
}
