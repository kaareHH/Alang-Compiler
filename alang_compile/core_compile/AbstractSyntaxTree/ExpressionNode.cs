using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class ExpressionNode : AstNode
    {

        public ExpressionNode Left { get; set; }
        public Operator Operator { get; set; }
        public ExpressionNode Right { get; set; }

        public ExpressionNode()
        {
        }

        public ExpressionNode(ParserRuleContext context) : base(context)
        {
        }
    }
}