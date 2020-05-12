using Antlr4.Runtime;
using core_compile.Visitors;

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
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

    }
}