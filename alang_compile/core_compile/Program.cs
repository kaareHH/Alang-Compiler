using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace core_compile
{
    class Program
    {
        public class Token
        {
            public Token(TokenEnum tokenEnum)
            {
                Name = tokenEnum;
            }
            public Token(TokenEnum tokenEnum, string value)
            {
                Value = value;
                Name = tokenEnum;
            }
            TokenEnum Name;
            string Value;
        }

        public enum TokenEnum
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
            T_ENDOFLINE,
            T_IDENTIFIER,
            T_OUTPUT,

        }
        static void Main(string[] args)
        {
            string inputString = System.IO.File.ReadAllText(@"C:\Users\kaspe\Source\Repos\p4-compiler\alang_compile\core_compile\Program1.hest");



            Scan(inputString);


            Console.WriteLine(inputString);
            Console.WriteLine("Hello World!");
        }



        public static List<Token> Scan(string InputString)
        {







            return new List<Token>();





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
