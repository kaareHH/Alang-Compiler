using System.Collections.Generic;
using System.Reflection.Metadata;

namespace core_compile.AbstractSyntaxTree
{
    public class FunctionNode : AstNode
    {
        public AstNode Params;
        public string Identifier { get; set; }
        public LanguageType Type { get; set; }
    }
}