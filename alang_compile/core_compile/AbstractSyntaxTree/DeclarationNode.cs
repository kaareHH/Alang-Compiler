namespace core_compile.AbstractSyntaxTree
{
    public class DeclarationNode : AstNode
    {
        public AlangType Type { get; set; }
        public string Identifier { get; set; }

        public DeclarationNode()
        {
        }

        public DeclarationNode(AlangType type, string identifier)
        {
            Type = type;
            Identifier = identifier;
        }
    }
}
