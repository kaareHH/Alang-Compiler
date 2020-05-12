using Antlr4.Runtime;
using core_compile.Visitors;

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
        
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}