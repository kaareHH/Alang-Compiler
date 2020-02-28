using System.IO;

namespace ParserService
{
    public class StringBuffer
    {
        public const char BLANK = ' ';
        private char[] charStream;
        private int cursor = 0;
        private StringBuffer(string FilePath)
        {
            var fileText = File.ReadAllText(FilePath);
            charStream = fileText.ToCharArray();
        }
        public static StringBuffer FromFilePath(string FilePath)
        {
            return new StringBuffer(FilePath);
        }

        public char peek()
        {
            return charStream[cursor];
        }
        public char advance()
        {
            return charStream[cursor++];
        }
        public bool EOF()
        {
            return cursor == charStream.Length - 1;
        }
    }
}
