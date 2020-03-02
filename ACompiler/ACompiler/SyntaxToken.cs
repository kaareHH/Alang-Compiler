namespace ACompiler
{
    public class SyntaxToken
    {
        public SyntaxToken(SyntaxKind Kind, int Position, string Text, object Value)
        {
            this.Kind = Kind;
            this.Position = Position;
            this.Text = Text;
            this.Value = Value;
        }

        public SyntaxKind Kind { get; }
        public int Position { get; }
        public string Text { get; }
        public object Value { get; }
    }

    public enum SyntaxKind
    {
        NumberToken,
        MinusToken,
        PlusToken,
        BadToken,
        EndOfFileToken,
        WhitespaceToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        TrueKeyword,
        FalseKeyword,
        IdentifierToken
    }
}