using System;
using System.Linq;
using System.IO;

namespace ParserService
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullFilePath = Path.GetFullPath(args[0]);
            Console.WriteLine("Compiling: " + fullFilePath);

            var FileBody = StringBuffer.FromFilePath(fullFilePath);

        }
    }
}
