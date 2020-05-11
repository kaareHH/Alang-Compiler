using Antlr4.Runtime;
using core_compile.AbstractSyntaxTree;

namespace core_compile.AbstractSyntaxTree
{
    public class IdentfierNode : AstNode
    {
        public string Symbol;

        public IdentfierNode()
        {
        }

        public IdentfierNode(ParserRuleContext context) : base(context)
        {
        }
    }
}