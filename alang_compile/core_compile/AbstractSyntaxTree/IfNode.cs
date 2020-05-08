using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class IfNode : AstNode
    {
        public AstNode Alternate { get; set; }

        public AstNode Consequent { get; set; }
        public ExpressionNode Condition { get; set; }

        public IfNode(ParserRuleContext context) : base(context)
        {
        }
    }
}