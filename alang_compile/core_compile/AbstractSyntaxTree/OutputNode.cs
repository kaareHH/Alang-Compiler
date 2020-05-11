using Antlr4.Runtime;

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
    }
}