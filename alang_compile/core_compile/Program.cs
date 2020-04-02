using System;
using System.Collections.Generic;
using System.Linq;

namespace core_compile
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ged = Environment.CurrentDirectory;
            //string directory = ged.Remove(ged.IndexOf("bin"), ged.Length - ged.IndexOf("bin")) + "inputFile.txt";

            char[] inputFile = System.IO.File.ReadAllText("inputFile.txt").ToCharArray();

            List<Token> tokens = new List<Token>();
            Node AST = new Node();

            Scanner scanner = new Scanner(inputFile);
            tokens = scanner.tokens;

            tokens.RemoveAll(x => (x.TokenType == TokenType.T_WHITESPACE));

            foreach (var item in tokens)
            {
                Console.WriteLine(item.TokenType.ToString());
            }

            Parse parse = new Parse(tokens);
            AST = parse.AST;

            System.Console.WriteLine("Start has " + AST.children.Count() + " children");
            foreach (var n in AST.children)
            {
                InterpretAST(n);
                
            }            
        }

        static void InterpretAST(Node node)
        {
            System.Console.WriteLine("\n");

            if(node.left != null)
            {
                System.Console.WriteLine("Root: " + node.op + ", left: " + node.left.op);
                InterpretAST(node.left);
            }
            if(node.right != null)
            {
                System.Console.WriteLine("Root: " + node.op + ", right: " + node.right.op);
                InterpretAST(node.right);
            }
            if(node.children.Count > 0)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Root: " + node.op + ", has the following stmt children:");
                System.Console.WriteLine();
                
                foreach (var childNode in node.children)
                {
                    InterpretAST(childNode);
                }
            }
        }





    }
}
