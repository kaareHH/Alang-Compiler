using Antlr4.Runtime;
using core_compile.AbstractSyntaxTree;

namespace core_compile
{
    public class FunctionCallNode : AstNode
    {
        public string FunctionToBeCalled { get; set; }
        public AstNode Params { get; set; }

        public FunctionCallNode(ParserRuleContext context) : base(context)
        {
        }
    }
}