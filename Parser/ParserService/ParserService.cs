using System;
using System.Linq;
using System.IO;
using ParserService.Lexer;
using ParserService.Lexer.Tokens;

namespace ParserService
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullFilePath = Path.GetFullPath(args[1]);
            Console.WriteLine("Compiling: " + fullFilePath);

            var charStream = new CharStream(new StreamReader(fullFilePath));
            Console.WriteLine("lol");
            var factory = new TokenStream(charStream);

            int amountOfTokens = 0;
            do
            {

                Console.WriteLine(factory.Advance());
                amountOfTokens++;
            } while (!(factory.Peek() is EndOfFileToken));


            Console.WriteLine("Tokens: @{amountOfTokens}");
        }
    }
}
