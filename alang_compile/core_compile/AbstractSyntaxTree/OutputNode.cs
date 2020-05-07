using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class OutputNode : AstNode
    {
        public OutputNode()
        {
        }

        public OutputNode(ParserRuleContext context) : base(context)
        {
        }
    }
}