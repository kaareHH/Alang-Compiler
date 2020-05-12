using System;
using AntlrGen;
using core_compile.Visitors;

namespace core_compile.AbstractSyntaxTree
{
    public class CompilationNode : AstNode
    {
        public CompilationNode(ALangParser.StartContext context) : base(context) { }

        public CompilationNode()
        {
            
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}