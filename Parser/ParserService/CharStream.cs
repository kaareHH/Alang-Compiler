using System.IO;
namespace ParserService
{
    public class CharStream
    {
        public static readonly char
            BLANK = ' ';


        private readonly StreamReader _streamReader;
        private bool _eof = false;

        public CharStream(StreamReader streamReader)
        {
            _streamReader = streamReader;
        }

        public char Peek() => (char)_streamReader.Peek();
        public bool EOF => _eof;

        public char Advance()
        {
            int answer = (char)_streamReader.Read();

            if (answer < 0)
                _eof = true;

            return (char)answer;
        }
    }
}
