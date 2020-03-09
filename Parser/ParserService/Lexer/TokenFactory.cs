using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Schema;
using ParserService.Lexer.Tokens;

namespace ParserService.Lexer
{
    public class TokenFactory
    {
        private CharStream s;

        public TokenFactory(CharStream sp)
        {
            s = sp;
        }


        public Token Lex()
        {
            SkipCommentsAndWhitespace();
            if (s.EOF)
                return new EndOfFileToken();
            if (IsDigit(s.Peek()))
                return DigitToken();

            string terminal = FindTerminal();
            Console.WriteLine(terminal);
            switch (terminal)
            {
                case "int":
                    return new IntTypeToken();
                case "pin":
                    return new PinTypeToken();
                case "if":
                    return new IfToken();
                case "endif":
                    return new EndIfToken();
                case "endrepeat":
                    return new EndRepeatToken();
                case "+":
                case "-":
                case "*":
                case "/":
                    return new OperatorToken(terminal);
                default:
                    return new IdentifierToken(terminal);
            }
        }

        private void SkipCommentsAndWhitespace()
        {
            SkipWhitespace();
            SkipComments();
        }

        private void SkipComments()
        {
            if (s.Peek() == '/')
            {
                s.Advance();
                if (s.Peek() == '/')
                {
                    SkipUntilSymbol('\n');
                } else if (s.Peek() == '*')
                {
                    SkipUntilSymbol('*');
                    SkipUntilSymbol('/');
                }
                else
                    throw new LexicalException();
            }

        }

        private void SkipUntilSymbol(char symbol)
        {
            while (s.Peek() != symbol)
            {
                s.Advance();
            }
        }

        private string FindTerminal()
        {
            // TODO IsMatch(terminal) så vi kun får A-z og 0-9
            string terminal = "";
            string LettersAndDigigtsPattern = @"[A-z]|[0-9]|\*|\-|\+|\/";
            while (Regex.IsMatch(s.Peek().ToString(),LettersAndDigigtsPattern))
            {
                terminal += s.Advance();
            }

            return terminal;
        }

        private void SkipWhitespace()
        {
            while (s.Peek() == CharStream.BLANK)
            {
                s.Advance();
            }
        }

        private bool IsDigit(char input) => Char.IsDigit(input);

        private Token DigitToken()
        {
            string value = "";
            while (IsDigit(s.Peek()))
            {
                value += s.Advance();
            }

            int valueInInt = Int32.Parse(value);

            return new NumberToken(valueInInt);
        }
    }

    internal class LexicalException : Exception
    {
    }
}
