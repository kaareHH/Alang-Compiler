namespace core_compile.AbstractSyntaxTree
{
    public class DeclarationNode : AstNode
    {
        public DeclarationType DeclarationType { get; set; }
        public string Identifier { get; set; }

        public ExpressionNode Expression { get; set; }

        public DeclarationNode()
        {
        }

        public DeclarationNode(string identifier)
        {
            Identifier = identifier;
        }
    }
}
