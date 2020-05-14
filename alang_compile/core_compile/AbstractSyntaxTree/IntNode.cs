using Antlr4.Runtime;
using core_compile.Visitors;

namespace core_compile.AbstractSyntaxTree
{
    public class IntNode : AstNode
    {

        public int Value { get; set; }
        
        public IntNode()
        {
        }

        public IntNode(ParserRuleContext context) : base(context)
        {
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        
        public override LanguageType Accept(ITypeCheckerVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}