using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class ExpressionNode : AstNode
    {
        public ExpressionNode()
        {
        }

        public ExpressionNode(ParserRuleContext context) : base(context)
        {
        }
    }
}