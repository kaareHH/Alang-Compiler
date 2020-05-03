namespace core_compile.AbstractSyntaxTree
{
    public class Location
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Location(int line, int column)
        {
            Line = line;
            Column = column;
        }
    }
}