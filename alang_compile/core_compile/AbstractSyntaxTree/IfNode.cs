using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class IfNode : AstNode
    {
        public IfNode(ParserRuleContext context) : base(context)
        {
        }
    }
}