using System.Runtime;
using Antlr4.Runtime;
using core_compile.Visitors;

namespace core_compile.AbstractSyntaxTree
{
    public class ExpressionNode : AstNode
    {
        public AstNode Left { get; set; }
        public Operator Operator { get; set; }
        public AstNode Right { get; set; }

        public bool Parenthesized { get; set; } = false;
        public ExpressionNode()
        {
        }

        public ExpressionNode(ParserRuleContext context) : base(context)
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