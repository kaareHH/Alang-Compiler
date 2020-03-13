using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core_compile
{
    public class Scanner
    {
        public Scanner(char[] inputStream)
        {
            tokens = Scan(inputStream);
        }

        public List<Token> tokens { get; private set; } = new List<Token>();

        private List<Token> Scan(char[] inputStream)
        {
            List<Token> TokensToReturn = new List<Token>();

            string word = "";

            for (int i = 0; i < inputStream.Length; i++)
            {

                if (Char.IsDigit(inputStream[i]) && !word.Any(c => char.IsLetter(c))) //! Avoid reading a3
                {
                    TokensToReturn.Add(findIntLiteral(inputStream, i, out i));
                    word = "";
                }
                else if (Char.IsLetter(inputStream[i]))
                {
                    word = createWord(inputStream, i, out i);
                }
                else
                {
                    word += inputStream[i];
                }

                switch (word)
                {
                    case "int":
                        TokensToReturn.Add(new Token(TokenType.T_INTDCL, word));
                        word = "";
                        i++; //! increment i to evaluate next character
                        TokensToReturn.AddRange(findIdentifier(inputStream, i, out i));
                        break;

                    case "=":
                        TokensToReturn.Add(new Token(TokenType.T_EQUAL, word));
                        word = "";
                        break;

                    case ";":
                        TokensToReturn.Add(new Token(TokenType.T_SEMICOLON, word));
                        word = "";
                        break;

                    case " ":
                        TokensToReturn.Add(new Token(TokenType.T_WHITESPACE, word));
                        word = "";
                        break;
                    case "\n":
                        TokensToReturn.Add(new Token(TokenType.T_WHITESPACE, word));
                        word = "";
                        break;

                    default:
                        break;
                }

                if (!string.IsNullOrEmpty(word))
                {
                    TokensToReturn.Add(new Token(TokenType.T_ID, word));
                    word = "";
                }
            }

            return TokensToReturn;
        }

        private static string createWord(char[] inputStream, int index, out int newIndex)
        {
            string word = "";
            while (Char.IsLetterOrDigit(inputStream[index]))
            {
                word += inputStream[index];
                if (Char.IsLetterOrDigit(inputStream[index+1]))
                {
                    index++;
                }
            }

            newIndex = index;
            return word;
        }

        private static Token findIntLiteral(char[] inputStream, int index, out int newIndex)
        {
            int intlit = 0;
            string number = "";
            while (char.IsNumber(inputStream[index]))
            {
                number += inputStream[index].ToString();
                if (Char.IsNumber(inputStream[index + 1]))
                {
                    index++;
                }
            }

            intlit = Int32.Parse(number);
            Token token = new Token(TokenType.T_INTLIT, number);
            newIndex = index;

            return token;
        }

        private static List<Token> findIdentifier(char[] inputStream, int index, out int newIndex)
        {
            string identifier = "";
            List<Token> tokens = new List<Token>();


            while (char.IsSeparator(inputStream[index]))
            {
                tokens.Add(new Token(TokenType.T_WHITESPACE, " "));
                index++;
            }

            while (!char.IsSeparator(inputStream[index]) && !char.IsPunctuation(inputStream[index]) && !char.IsSymbol(inputStream[index]))
            {
                identifier += inputStream[index];

                if (!char.IsSeparator(inputStream[index+1]) && !char.IsPunctuation(inputStream[index+1]) && !char.IsSymbol(inputStream[index+1]))
                {
                    index++;
                }
            }

            tokens.Add(new Token(TokenType.T_ID, identifier));

            newIndex = index;

            return tokens;
        }
    }
}
