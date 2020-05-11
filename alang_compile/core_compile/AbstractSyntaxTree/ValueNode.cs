using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class ValueNode : AstNode
    {
        public AstNode Value { get; set; }
        
        public ValueNode()
        {
        }

        public ValueNode(ParserRuleContext context) : base(context)
        {
        }
    }
}