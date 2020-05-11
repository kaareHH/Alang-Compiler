using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class ParameterNode : AstNode
    {
        public LanguageType Type;
        public string Identifier;

        public ParameterNode()
        {
        }

        public ParameterNode(ParserRuleContext context) : base(context)
        {
        }
    }
}