using Antlr4.Runtime;
using core_compile.Visitors;

namespace core_compile.AbstractSyntaxTree
{
    public class IfNode : AstNode
    {
        public AstNode Alternate { get; set; }

        public AstNode Consequent { get; set; }
        public AstNode Condition { get; set; }

        public IfNode(ParserRuleContext context) : base(context)
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