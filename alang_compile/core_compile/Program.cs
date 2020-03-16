﻿using System;
using System.Collections.Generic;

namespace core_compile
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] inputFile = System.IO.File.ReadAllText(@"D:\github\p4-compiler\alang_compile\core_compile\inputFile.txt").ToCharArray();

            List<Token> tokens = new List<Token>();

            Scanner scanner = new Scanner(inputFile);         

            tokens = scanner.tokens;

            foreach (var item in tokens)
            {
                Console.WriteLine(item.TokenType.ToString());
            }

            Console.WriteLine("Hello World!");
        }
    }
}
