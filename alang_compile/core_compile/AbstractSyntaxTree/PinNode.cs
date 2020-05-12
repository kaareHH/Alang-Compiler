using Antlr4.Runtime;
using core_compile.AbstractSyntaxTree;

namespace core_compile.Visitors
{
    public class PinNode : AstNode
    {
        public int Value { get; set; }
        
        public PinNode()
        {
        }

        public PinNode(ParserRuleContext context) : base(context)
        {
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}