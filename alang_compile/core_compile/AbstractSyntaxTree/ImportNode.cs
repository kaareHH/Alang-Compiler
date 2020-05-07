using System.Dynamic;
using AntlrGen;

namespace core_compile.AbstractSyntaxTree
{
    public class ImportNode : AstNode
    {
        public ImportNode(ALangParser.ImportsContext context) : base (context) { }

        public ImportNode()
        {
        }

        public string Path { get; set; }
    }
}