using Antlr4.Runtime;
using core_compile.Visitors;

namespace core_compile.AbstractSyntaxTree
{
    public class ParameterNode : AstNode
    {
        public LanguageType Type;
        public string Identifier;

        public ParameterNode()
        {
        }

        public ParameterNode(ParserRuleContext context) : base(context)
        {
        }
        
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}