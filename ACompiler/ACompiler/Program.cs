using System;
using System.Linq;

namespace ACompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ResetColor();
                Console.Write("> ");
                var line = Console.ReadLine();
                var lexer = new Lexer(line);
                SyntaxToken token;
                do
                {
                    token = lexer.Lex();
                    Console.WriteLine(token.Kind.ToString());
                } while (token.Kind != SyntaxKind.EndOfFileToken || token.Kind != SyntaxKind.EndOfFileToken);

                if (lexer.Dianostics.ToList().Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    lexer.Dianostics.ToList().ForEach(Console.WriteLine);
                }

            }
        }
    }
}
