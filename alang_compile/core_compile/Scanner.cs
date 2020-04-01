using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core_compile
{
    public class Scanner
    {
        // Line position in the input file
        public int line = 1;
        // Character position on the line
        public int pos = 0;
        public List<Token> tokens { get; private set; } = new List<Token>();

        public Scanner(char[] inputStream)
        {
            tokens = Scan(inputStream);
        }

        /// <summary>
        /// Creates and returns a list of tokens from the inputstream.
        /// </summary>
        private List<Token> Scan(char[] inputStream)
        {
            List<Token> TokensToReturn = new List<Token>();

            string word = "";

            for (int index = 0; index < inputStream.Length; index++)
            {
                pos++;

                // Find integer literals
                if (Char.IsDigit(inputStream[index]) && !word.Any(c => char.IsLetter(c))) //! Avoid reading a3
                {
                    TokensToReturn.Add(FindIntLiteral(inputStream, index, out index));
                    word = "";
                }
                // Construct a word
                else if (Char.IsLetter(inputStream[index]))
                {
                    word = CreateWord(inputStream, index, out index);
                }
                // Special characters etc.
                else if((inputStream[index] == '!' || inputStream[index] == '=' || 
                         inputStream[index] == '<' || inputStream[index] == '>'))
                {
                    word = findOperator(inputStream, index, out index);
                }
                else
                {
                    word += inputStream[index];
                }

                switch (word)
                {
                    /*
                    case "start":
                        TokensToReturn.Add(new Token(TokenType.T_START, word));
                        word = "";
                        break;
                    */

                    case "output":
                        TokensToReturn.Add(new Token(TokenType.T_OUTPUTPIN, word));
                        word = "";
                        break;

                    case "input":
                        TokensToReturn.Add(new Token(TokenType.T_INPUTPIN, word));
                        word = "";
                        break;

                    case "on":
                        TokensToReturn.Add(new Token(TokenType.T_ON, word));
                        word = "";
                        break;

                    case "off":
                        TokensToReturn.Add(new Token(TokenType.T_OFF, word));
                        word = "";
                        break;

                    case "toggle":
                        TokensToReturn.Add(new Token(TokenType.T_TOGGLE, word));
                        word = "";
                        break;

                    case "+":
                        TokensToReturn.Add(new Token(TokenType.T_PLUS, word));
                        word = "";
                        break;

                    case "-":
                        TokensToReturn.Add(new Token(TokenType.T_MINUS, word));
                        word = "";
                        break;

                    case "*":
                        TokensToReturn.Add(new Token(TokenType.T_MULTIPLY, word));
                        word = "";
                        break;

                    case "/":
                        TokensToReturn.Add(new Token(TokenType.T_DIVIDE, word));
                        word = "";
                        break;

                    case "=":
                        TokensToReturn.Add(new Token(TokenType.T_EQUAL, word));
                        word = "";
                        break;



                    case "==":
                        TokensToReturn.Add(new Token(TokenType.T_EQUALEQUAL, word));
                        word = "";
                        break;
                    case ">=":
                        TokensToReturn.Add(new Token(TokenType.T_GREATEREQUAL, word));
                        word = "";
                        break;
                    case "<=":
                        TokensToReturn.Add(new Token(TokenType.T_LESSEQUAL, word));
                        word = "";
                        break;
                    case "!=":
                        TokensToReturn.Add(new Token(TokenType.T_NOTEQUAL, word));
                        word = "";
                        break;
                    case ">":
                        TokensToReturn.Add(new Token(TokenType.T_GREATER, word));
                        word = "";
                        break;
                    case "<":
                        TokensToReturn.Add(new Token(TokenType.T_LESS, word));
                        word = "";
                        break;



                    case "if":
                        TokensToReturn.Add(new Token(TokenType.T_IF, word));
                        word = "";
                        break;

                    case "endif":
                        TokensToReturn.Add(new Token(TokenType.T_ENDIF, word));
                        word = "";
                        break;

                    case "repeat":
                        TokensToReturn.Add(new Token(TokenType.T_REPEAT, word));
                        word = "";
                        break;

                    case "endrepeat":
                        TokensToReturn.Add(new Token(TokenType.T_ENDREPEAT, word));
                        word = "";
                        break;


                    case "times":
                        TokensToReturn.Add(new Token(TokenType.T_TIMES, word));
                        word = "";
                        break;

                    case "then":
                        TokensToReturn.Add(new Token(TokenType.T_THEN, word));
                        word = "";
                        break;

                        /*
                    case "{":
                        TokensToReturn.Add(new Token(TokenType.T_BEGINSCOPE, word));
                        word = "";
                        break;

                    case "}":
                        TokensToReturn.Add(new Token(TokenType.T_ENDSCOPE, word));
                        word = "";
                        break;
                        */

                    case "(":
                        TokensToReturn.Add(new Token(TokenType.T_PARANBEGIN, word));
                        word = "";
                        break;

                    case ")":
                        TokensToReturn.Add(new Token(TokenType.T_PARANEND, word));
                        word = "";
                        break;

                    case "int":
                        TokensToReturn.Add(new Token(TokenType.T_INTDCL, word));
                        word = "";
                        index++; // increment i to evaluate next character
                        TokensToReturn.AddRange(FindIdentifier(inputStream, index, out index));
                        break;

                    case "pin":
                        TokensToReturn.Add(new Token(TokenType.T_PINDCL, word));
                        word = "";
                        index++; // increment i to evaluate next character
                        TokensToReturn.AddRange(FindIdentifier(inputStream, index, out index));
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
                        line++;
                        pos = 0;
                        TokensToReturn.Add(new Token(TokenType.T_WHITESPACE, word));
                        word = "";
                        break;

                    case "\r":
                        TokensToReturn.Add(new Token(TokenType.T_WHITESPACE, word));
                        word = "";
                        break;

                    case "\t":
                        TokensToReturn.Add(new Token(TokenType.T_WHITESPACE, word));
                        word = "";
                        break;

                    default:
                        break;
                }

                // If no case matches the word, the word must be an identifier
                if (!string.IsNullOrEmpty(word) && !(char.IsPunctuation(inputStream[index]) || char.IsSymbol(inputStream[index]) || char.IsControl(inputStream[index])))
                {
                    TokensToReturn.Add(new Token(TokenType.T_ID, word));
                    word = "";
                
                }
                // If no case matches the word and the word is not an identifier, the word is not in the language
                else if (!string.IsNullOrEmpty(word) && (char.IsPunctuation(inputStream[index]) || char.IsSymbol(inputStream[index])))
                { 
                    TokensToReturn.Add(new Token(TokenType.T_BADTOKEN, inputStream[index].ToString()));
                    word = "";
                }
            }

            return TokensToReturn;
        }

        private string findOperator(char[] inputStream, int index, out int newIndex)
        {
            string word = "";
            while(inputStream[index] == '!' || inputStream[index] == '=' || 
                  inputStream[index] == '<' || inputStream[index] == '>')
            {
                word += inputStream[index];
                index++;
                pos++;
            }
            pos--;
            newIndex = index;
            newIndex--;

            return word;
        }

        /// <summary>
        /// Creates a word from the inputstream, consisting of letters and/or digits.
        /// The first character of the word is allways a letter.
        /// Returns the word as a string.
        /// </summary>
        private string CreateWord(char[] inputStream, int index, out int newIndex)
        {
            string word = "";
            while (Char.IsLetterOrDigit(inputStream[index]))
            {
                word += inputStream[index];
                pos++;
                index++;
            }

            // decrease pos and index by 1 to avoid skipping a character
            pos--;
            newIndex = index;
            newIndex--;
            
            return word;

        }

        /// <summary>
        /// Find and creates an integer literal token from the inputstream.
        /// Returns an INTLIT token
        /// </summary>
        private Token FindIntLiteral(char[] inputStream, int index, out int newIndex)
        {
            string number = "";
            while (char.IsNumber(inputStream[index]))
            {
                number += inputStream[index].ToString();
                pos++;
                index++;
            }

            // decrease pos and index by 1 to avoid skipping a character
            pos--;
            newIndex = index;
            newIndex--;

            Token token = new Token(TokenType.T_INTLIT, number);

            return token;
        }

        /// <summary>
        /// Finds an identifier from the inputstream.
        /// The method also handles whitespaces.
        /// The identifier must begin with a letter.
        /// Returns a list of tokens consisting of the identifier and the possible whitespace tokens.
        /// </summary>
        private List<Token> FindIdentifier(char[] inputStream, int index, out int newIndex)
        {
            string identifier = "";
            List<Token> tokens = new List<Token>();

            // Dealing with whitespaces leading up to the identifier
            while (char.IsSeparator(inputStream[index]))
            {
                tokens.Add(new Token(TokenType.T_WHITESPACE, " "));
                pos++;
                index++;
            }

            // Ensures that the first character of the identifier is a letter
            if (char.IsLetter(inputStream[index]))
            {
                while (!char.IsSeparator(inputStream[index]) && !char.IsPunctuation(inputStream[index]) && !char.IsSymbol(inputStream[index]))
                {
                    identifier += inputStream[index];
                    pos++;
                    index++;
                }
            }

            // decrease pos by 1 to avoid skipping a character
            pos--;
            newIndex = index;
            newIndex--;

            if (identifier != "")
            {
                tokens.Add(new Token(TokenType.T_ID, identifier));
            }

            return tokens;
        }
    }
}
