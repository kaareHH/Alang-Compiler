using System.Dynamic;
using AntlrGen;
using core_compile.Visitors;

namespace core_compile.AbstractSyntaxTree
{
    public class ImportNode : AstNode
    {
        public ImportNode(ALangParser.ImportsContext context) : base(context) { }

        public ImportNode()
        {
        }

        public string Path { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}