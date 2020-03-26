using System;
using System.Collections.Generic;

namespace core_compile
{
    class Program
    {
        static void Main(string[] args)
        {
            var ged = Environment.CurrentDirectory;
            string directory = ged.Remove(ged.IndexOf("bin"), ged.Length - ged.IndexOf("bin")) + "inputFile.txt";

            char[] inputFile = System.IO.File.ReadAllText(directory).ToCharArray();

            List<Token> tokens = new List<Token>();

            Scanner scanner = new Scanner(inputFile);         

            tokens = scanner.tokens;

            foreach (var item in tokens)
            {
                Console.WriteLine(item.TokenType.ToString());
            }
        }
    }
}
