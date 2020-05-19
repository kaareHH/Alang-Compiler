using Antlr4.Runtime;
using core_compile.AbstractSyntaxTree;
using core_compile.Visitors;

namespace core_compile
{
    public class FunctionCallNode : AstNode
    {
        public string Name { get; set; }
        public FunctionCallNode(ParserRuleContext context) : base(context)
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