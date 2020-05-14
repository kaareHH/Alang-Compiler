using System.Collections.Generic;
using System.Reflection.Metadata;
using core_compile.SymbolTableClasses;
using core_compile.Visitors;

namespace core_compile.AbstractSyntaxTree
{
    public class FunctionNode : AstNode
    {
        public AstNode Params = new ParameterNode();
        public string Identifier { get; set; }
        public LanguageType Type { get; set; }

        public SymbolTable SymbolTable { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}