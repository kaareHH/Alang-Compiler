using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class RepeatNode : AstNode
    {
        public ExpressionNode LoopExpression { get; set; }

        public RepeatNode()
        {

        }

        public RepeatNode(ParserRuleContext context) : base(context)
        {
        }
    }
}