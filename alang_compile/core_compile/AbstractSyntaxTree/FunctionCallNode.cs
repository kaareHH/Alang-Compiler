using Antlr4.Runtime;
using core_compile.AbstractSyntaxTree;

namespace core_compile
{
    public class FunctionCallNode : AstNode
    {
        public FunctionCallNode(ParserRuleContext context) : base(context)
        {
        }
    }
}