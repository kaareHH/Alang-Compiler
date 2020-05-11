using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class WhileNode : AstNode
    {
        public AstNode LoopExpression { get; set; }

        public WhileNode()
        {

        }

        public WhileNode(ParserRuleContext context) : base(context)
        {
        }
    }
}