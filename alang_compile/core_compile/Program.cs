using System;
using System.Collections.Generic;

namespace core_compile
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ged = Environment.CurrentDirectory;
            //string directory = ged.Remove(ged.IndexOf("bin"), ged.Length - ged.IndexOf("bin")) + "inputFile.txt";

            char[] inputFile = System.IO.File.ReadAllText(@"C:\Users\kaare\Documents\GitHub\p4-compiler\alang_compile\core_compile\inputFile.txt").ToCharArray();

            List<Token> tokens = new List<Token>();

            Scanner scanner = new Scanner(inputFile);

            tokens = scanner.tokens;

            tokens.RemoveAll(x => (x.TokenType == TokenType.T_WHITESPACE));

            foreach (var item in tokens)
            {
                Console.WriteLine(item.TokenType.ToString());
            }

            Parser parser = new Parser(tokens);         

            
        }
    }
}
