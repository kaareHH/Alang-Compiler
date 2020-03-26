using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace core_compile
{
    class Program
    {
        public class Tree
        {
            public string Name { get; set; }
            public Token Token { get; set; }
            public Tree Parent { get; set; }
            public List<Tree> Children { get; set; }


            public Tree()
            {
                Children = new List<Tree>();
            }
            public void AddChild(Tree Child)
            {
                Child.Parent = this;
                this.Children.Add(Child);
            }
        }

        public class Token
        {
            public Token(TokenType tokenType)
            {
                TokenType = tokenType;
                Value = string.Empty;
            }
            public Token(TokenType tokenType, string value)
            {
                Value = value;
                TokenType = tokenType;
            }

            public TokenType TokenType { get; set; }
            public string Value { get; set; }
        }

        public enum TokenType
        {
            T_START,
            T_TIME,
            T_TIMELIT,
            T_AT,
            T_IS,
            T_AS,
            T_ON,
            T_OFF,
            T_SCOPESTART,
            T_SCOPEEND,
            T_INTLIT,
            T_STRINGLIT,
            T_IDENTIFIER,
            T_ENDOFLINE,
            T_OUTPUT,
            T_INPUT,
        }
        static void Main(string[] args)
        {
            //string inputString = System.IO.File.ReadAllText(@"C:\Users\kaspe\Source\Repos\p4-compiler\alang_compile\core_compile\Program1.hest");
            string inputString = "" ;
            var test = Environment. CurrentDirectory;
            var ged = test.IndexOf("bin");
            var directory = test.Remove(ged, test.Length - ged) + "Program1.hest";
            inputString = System.IO.File.ReadAllText(directory);
            var result = Scan(inputString);
            foreach (var item in result)
            {
                Console.WriteLine(item.TokenType + " - " + item.Value);
            }




            Console.WriteLine(inputString);
            Console.WriteLine("Hello World!");
        }



        public static List<Token> Scan(string InputString)
        {
            var returnTokenList = new List<Token>();
            var temp = InputString;
            var stringTrimed = InputString.Replace("\r", string.Empty).Replace("\n", string.Empty);
            var tempArray = InputString.Replace("\r", string.Empty).Replace("\n", string.Empty).Split(' ').ToList();
            var tesad = Regex.Match(InputString, @"\S[A-z]*[0-9]*");

            List<string> returnList = new List<string>(tempArray);
            foreach (var item in tempArray)
            {
                if (item.Length <= 0)
                    returnList.Remove(item);
            }
            string match = "";
            int counter = stringTrimed.Length;
            int i = 0;
            while (counter > i)
            {
                match += stringTrimed[i++].ToString().ToLower().Trim();
                if (char.IsDigit(match.Trim().FirstOrDefault()))
                {
                    while (char.IsDigit(stringTrimed[i]))
                    {
                        match += stringTrimed[i++].ToString().ToLower().Trim();
                    }
                    returnTokenList.Add(new Token(TokenType.T_INTLIT, match));
                    match = "";
                }
                if (char.IsLetter(match.Trim().FirstOrDefault()))
                {
                    while (char.IsLetterOrDigit(stringTrimed[i]))
                    {
                        match += stringTrimed[i++].ToString().ToLower().Trim();
                    }
                }

                switch (match.Trim())
                {
                    case "start":
                        returnTokenList.Add(new Token(TokenType.T_START, match));
                        match = "";
                        break;
                    case "{":
                        returnTokenList.Add(new Token(TokenType.T_SCOPESTART, match));
                        match = "";
                        break;
                    case "}":
                        returnTokenList.Add(new Token(TokenType.T_SCOPEEND, match));
                        match = "";
                        break;
                    case "time":
                        returnTokenList.Add(new Token(TokenType.T_TIME, match));
                        match = "";
                        break;
                    case "is":
                        returnTokenList.Add(new Token(TokenType.T_IS, match));
                        match = "";
                        break;
                    case "as":
                        returnTokenList.Add(new Token(TokenType.T_AS, match));
                        match = "";
                        break;
                    case ";":
                        returnTokenList.Add(new Token(TokenType.T_ENDOFLINE, match));
                        match = "";
                        break;
                    case "output":
                        returnTokenList.Add(new Token(TokenType.T_OUTPUT, match));
                        match = "";
                        break;
                    case "on":
                        returnTokenList.Add(new Token(TokenType.T_ON, match));
                        match = "";
                        break;
                    case "off":
                        returnTokenList.Add(new Token(TokenType.T_OFF, match));
                        match = "";
                        break;
                    default:
                        break;
                }
                if (match.Trim() != string.Empty)
                {
                    returnTokenList.Add(new Token(TokenType.T_IDENTIFIER, match));
                    match = "";
                }
            }




            return returnTokenList;





            //List<Token> returnValue = new List<Token>();

            //InputString = Regex.Replace( InputString, @"\s+", string.Empty);
            //var ged = InputString.ToLower().ToCharArray();
            //var test = InputString.Split();

            //string temp = "";
            //foreach (var item in ged)
            //{
            //    temp += item.ToString();

            //    switch (temp)
            //    {
            //        case "start":
            //            returnValue.Add(new Token(TokenEnum.T_START));
            //            temp = "";
            //            break;
            //        case "{":
            //            returnValue.Add(new Token(TokenEnum.T_SCOPESTART));
            //            temp = "";
            //            break;
            //        case "}":
            //            returnValue.Add(new Token(TokenEnum.T_SCOPEEND));
            //            temp = "";
            //            break;
            //        case "is":
            //            returnValue.Add(new Token(TokenEnum.T_IS));
            //            temp = "";
            //            break;
            //        case "on":
            //            returnValue.Add(new Token(TokenEnum.T_ON));
            //            temp = "";
            //            break;
            //        case "off":
            //            returnValue.Add(new Token(TokenEnum.T_OFF));
            //            temp = "";
            //            break;
            //        case "as":
            //            returnValue.Add(new Token(TokenEnum.T_AS));
            //            temp = "";
            //            break;
            //        case "at":
            //            returnValue.Add(new Token(TokenEnum.T_AT));
            //            temp = "";
            //            break;
            //        case ";":
            //            returnValue.Add(new Token(TokenEnum.T_ENDOFLINE));
            //            temp = "";
            //            break;
            //        case "time":
            //            returnValue.Add(new Token(TokenEnum.T_TIME));
            //            temp = "";
            //            break;
            //        case "timelit":
            //            returnValue.Add(new Token(TokenEnum.T_TIMELIT));
            //            temp = "";
            //            break;
            //        case "intlit":
            //            returnValue.Add(new Token(TokenEnum.T_INTLIT));
            //            temp = "";
            //            break;
            //        //case "time":
            //        //    returnValue.Add(new Token(TokenEnum.T_START));
            //        //    temp = "";
            //        //    break;
            //        //case "time":
            //        //    returnValue.Add(new Token(TokenEnum.T_START));
            //        //    temp = "";
            //        //    break;
            //        //case "time":
            //        //    returnValue.Add(new Token(TokenEnum.T_START));
            //        //    temp = "";
            //        //    break;
            //        //case "time":
            //        //    returnValue.Add(new Token(TokenEnum.T_START));
            //        //    temp = "";
            //        //    break;
            //        //case "time":
            //        //    returnValue.Add(new Token(TokenEnum.T_START));
            //        //    temp = "";
            //        //    break;
            //        //case "time":
            //        //    returnValue.Add(new Token(TokenEnum.T_START));
            //        //    temp = "";
            //        //    break;
            //        //case "time":
            //        //    returnValue.Add(new Token(TokenEnum.T_START));
            //        //    temp = "";
            //        //    break;
            //        default:
            //            break;
            //    }
            //}


            //return new List<Token>();
        }


    }
}
