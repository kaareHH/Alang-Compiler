using Antlr4.Runtime;
using core_compile.Visitors;

namespace core_compile.AbstractSyntaxTree
{
    public class OutputNode : AstNode
    {

        public bool State { get; set; }
        public string Identifier { get; set; }

        public OutputNode()
        {
        }

        public OutputNode(ParserRuleContext context) : base(context)
        {
        }
        
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}