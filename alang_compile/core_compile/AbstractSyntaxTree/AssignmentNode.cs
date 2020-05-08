using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class AssignmentNode : AstNode
    {
        public AssignmentNode()
        {
        }

        public AssignmentNode(ParserRuleContext context) : base(context)
        {
        }
    }
}