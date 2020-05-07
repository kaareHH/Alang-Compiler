namespace core_compile.AbstractSyntaxTree
{
    public class FunctionNode : AstNode
    {
        public string Identifier { get; set; }
        public LanguageType Type { get; set; }
    }
}