using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public class AssignmentNode : AstNode
    {
        public string Identifier { get; set; }
        public AstNode Expression { get; set; }

        public AssignmentNode()
        {
        }

        public AssignmentNode(ParserRuleContext context) : base(context)
        {
        }

    }
}