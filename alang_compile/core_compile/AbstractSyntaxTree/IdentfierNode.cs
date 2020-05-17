using Antlr4.Runtime;
using core_compile.AbstractSyntaxTree;
using core_compile.Visitors;

namespace core_compile.AbstractSyntaxTree
{
    public class IdentfierNode : AstNode
    {
        public string Symbol;
        public override string ToString()
        {
            return Symbol;
        }

        public IdentfierNode()
        {
        }

        public IdentfierNode(ParserRuleContext context) : base(context)
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