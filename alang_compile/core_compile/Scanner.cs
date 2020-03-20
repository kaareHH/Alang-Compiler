using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core_compile
{
    public class Scanner
    {
        public int line = 1;
        public int pos = 0;
        public List<Token> tokens { get; private set; } = new List<Token>();
        public List<string> ExpectedCases = new List<string>();

        public Scanner(char[] inputStream)
        {
            tokens = Scan(inputStream);
        }

        private List<Token> Scan(char[] inputStream)
        {
            List<Token> TokensToReturn = new List<Token>();


            string word = "";

            for (int index = 0; index < inputStream.Length; index++)
            {
                pos++;

                if (Char.IsDigit(inputStream[index]) && !word.Any(c => char.IsLetter(c))) //! Avoid reading a3
                {
                    TokensToReturn.Add(FindIntLiteral(inputStream, index, out index));
                    word = "";
                }
                else if (Char.IsLetter(inputStream[index]))
                {
                    word = CreateWord(inputStream, index, out index);
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
                        // IsExpected(word, ExpectedCases);
                        //  ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_OUTPUTPIN, word));
                        word = "";
                        break;

                    case "input":
                        // IsExpected(word, ExpectedCases);
                        // ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_INPUTPIN, word));
                        word = "";
                        break;

                    case "on":
                        // IsExpected(word, ExpectedCases);
                        //ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_ON, word));
                        word = "";
                        break;

                    case "off":
                        // IsExpected(word, ExpectedCases);
                        // ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_OFF, word));
                        word = "";
                        break;

                    case "toggle":
                        // IsExpected(word, ExpectedCases);
                        Console.WriteLine("pos er + " + pos);
                        // ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_TOGGLE, word));
                        word = "";
                        break;

                    case "+":
                        //  IsExpected(word, ExpectedCases);
                        // ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_PLUS, word));
                        word = "";
                        break;

                    case "-":
                        // IsExpected(word, ExpectedCases);
                        // ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_MINUS, word));
                        word = "";
                        break;

                    case "*":
                        // IsExpected(word, ExpectedCases);
                        //  ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_MULTIPLY, word));
                        word = "";
                        break;

                    case "/":
                        //IsExpected(word, ExpectedCases);
                        // ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_DIVIDE, word));
                        word = "";
                        break;

                    case "=":
                        // IsExpected(word, ExpectedCases);
                        //ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_EQUAL, word));
                        word = "";
                        break;

                    case "if":
                        //IsExpected(word, ExpectedCases);
                        // ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_IF, word));
                        word = "";
                        break;

                    case "endif":
                        TokensToReturn.Add(new Token(TokenType.T_ENDIF, word));
                        word = "";
                        break;

                    case "repeat":
                        // IsExpected(word, ExpectedCases);
                        // ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_REPEAT, word));
                        word = "";
                        break;

                    case "endrepeat":
                        TokensToReturn.Add(new Token(TokenType.T_ENDREPEAT, word));
                        word = "";
                        break;


                    case "times":
                        // IsExpected(word, ExpectedCases);
                        // ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_TIMES, word));
                        word = "";
                        break;

                    case "then":
                        // IsExpected(word, ExpectedCases);
                        // ExpectedCases = Expect(word);
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
                        //  IsExpected(word, ExpectedCases);
                        // ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_INTDCL, word));
                        word = "";
                        index++; //! increment i to evaluate next character
                        TokensToReturn.AddRange(FindIdentifier(inputStream, index, out index));
                        break;

                    case "pin":
                        // IsExpected(word, ExpectedCases);
                        // ExpectedCases = Expect(word);
                        TokensToReturn.Add(new Token(TokenType.T_PINDCL, word));
                        word = "";
                        index++; //! increment i to evaluate next character
                        TokensToReturn.AddRange(FindIdentifier(inputStream, index, out index));
                        break;

                    case ";":
                        //IsExpected(word, ExpectedCases);
                        // ExpectedCases = Expect(word);
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

                if (!string.IsNullOrEmpty(word) && !(char.IsPunctuation(inputStream[index]) || char.IsSymbol(inputStream[index]) || char.IsControl(inputStream[index])))
                {
                    //IsExpected("id", ExpectedCases);
                    //ExpectedCases = Expect("id");
                    TokensToReturn.Add(new Token(TokenType.T_ID, word));
                    word = "";
                
                }

                else if (!string.IsNullOrEmpty(word) && (char.IsPunctuation(inputStream[index]) || char.IsSymbol(inputStream[index])))
                { 
                    TokensToReturn.Add(new Token(TokenType.T_BADTOKEN, inputStream[index].ToString()));
                    word = "";
                }
            }

            return TokensToReturn;
        }

        private string CreateWord(char[] inputStream, int index, out int newIndex)
        {
            string word = "";
            while (Char.IsLetterOrDigit(inputStream[index]))
            {
                word += inputStream[index];
                pos++;
                index++;
            }

            pos--;
            newIndex = index;
            newIndex--;
            return word;

        }

        private Token FindIntLiteral(char[] inputStream, int index, out int newIndex)
        {
            int intlit = 0;
            string number = "";
            while (char.IsNumber(inputStream[index]))
            {
                number += inputStream[index].ToString();
                pos++;
                index++;
            }

            //! decrease pos by 1 to avoid skipping a character

            pos--;
            newIndex = index;
            newIndex--;

            intlit = Int32.Parse(number);
            Token token = new Token(TokenType.T_INTLIT, number);
            // IsExpected("intlit", ExpectedCases);
            // ExpectedCases = Expect("intlit");

            return token;
        }

        private List<Token> FindIdentifier(char[] inputStream, int index, out int newIndex)
        {
            string identifier = "";
            List<Token> tokens = new List<Token>();

            while (char.IsSeparator(inputStream[index]))
            {
                tokens.Add(new Token(TokenType.T_WHITESPACE, " "));
                pos++;
                index++;
            }

            if (char.IsLetter(inputStream[index]))
            {
                while (!char.IsSeparator(inputStream[index]) && !char.IsPunctuation(inputStream[index]) && !char.IsSymbol(inputStream[index]))
                {
                    identifier += inputStream[index];
                    pos++;
                    index++;
                }
            }

            //! decrease pos by 1 to avoid skipping a character
            pos--;
            newIndex = index;
            newIndex--;

            if (identifier != "")
            {
                tokens.Add(new Token(TokenType.T_ID, identifier));
                // IsExpected("id", ExpectedCases);
                // ExpectedCases = Expect("id");
            }

            return tokens;
        }

        /*
        private List<string> Expect(string current)
        {
            List<string> expectedStrings = new List<string>();
            switch (current)
            {
                case "=":
                    expectedStrings.Add("id");
                    expectedStrings.Add("intlit");
                    break;
                
                    
                case "output":

                    break;

                case "input":

                    break;
                    

                case "on":
                    expectedStrings.Add("id");
                    break;

                case "off":
                    expectedStrings.Add("id");
                    break;

                case "toggle":
                    expectedStrings.Add("id");
                    break;

                case "+":
                    expectedStrings.Add("intlit");
                    expectedStrings.Add("id");

                    break;

                case "-":
                    expectedStrings.Add("intlit");
                    expectedStrings.Add("id");
                    break;

                case "*":
                    expectedStrings.Add("intlit");
                    expectedStrings.Add("id");
                    break;

                case "/":
                    expectedStrings.Add("intlit");
                    expectedStrings.Add("id");
                    break;

                case "if":
                    expectedStrings.Add("intlit");
                    expectedStrings.Add("id");
                    break;

                case "endif":

                    break;

                case "repeat":
                    expectedStrings.Add("intlit");
                    expectedStrings.Add("id");
                    break;

                case "endrepeat":

                    break;

                case "times":
                    expectedStrings.Add("on");
                    expectedStrings.Add("off");                    
                    expectedStrings.Add("id");
                    expectedStrings.Add("toggle");
                    break;

                case "then":
                    expectedStrings.Add("on");
                    expectedStrings.Add("off");
                    expectedStrings.Add("id");
                    expectedStrings.Add("toggle");
                    break;

                    
                case "(":

                    break;

                case ")":

                    break;
                    

                case "int":
                    expectedStrings.Add("id");
                    break;

                case "pin":
                    expectedStrings.Add("id");
                    break;

                case "id":
                    expectedStrings.Add("+");
                    expectedStrings.Add("-");
                    expectedStrings.Add("*");
                    expectedStrings.Add("/");
                    expectedStrings.Add("=");
                    expectedStrings.Add("times");
                    expectedStrings.Add("then");
                    expectedStrings.Add(";");
                    break;

                case "intlit":
                    expectedStrings.Add("+");
                    expectedStrings.Add("-");
                    expectedStrings.Add("*");
                    expectedStrings.Add("/");
                    expectedStrings.Add(";");
                    expectedStrings.Add("times");
                    expectedStrings.Add("then");

                    break;

                case ";":
                    break;

                default:
                    break;

            }

            return expectedStrings;
        }

        private void IsExpected(string word, List<string> expectedCases)
        {
            if (!expectedCases.Contains(word) && expectedCases.Count > 0)
            {
                Console.Write("Error on line {0}, position {1}. Expected: ", line, pos);
                foreach (var item in expectedCases)
                {
                    Console.Write(" " + item);              
                }
                Console.WriteLine();
            }
        }
        */
    }
}
