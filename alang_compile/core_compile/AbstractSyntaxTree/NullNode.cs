using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class NullNode : AstNode
    {
        public NullNode(ParserRuleContext context) : base(context)
        {
        }
    }
}