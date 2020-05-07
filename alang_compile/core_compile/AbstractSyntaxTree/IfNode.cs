using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class IfNode : AstNode
    {
        public IfNode Alternative { get; set; }

        public IfNode(ParserRuleContext context) : base(context)
        {
        }
    }
}