using System;
using AntlrGen;

namespace core_compile.AbstractSyntaxTree
{
    public class CompilationUnit : AstNode
    {
        public CompilationUnit(ALangParser.StartContext context) : base(context) { }

        public CompilationUnit()
        {
            
        }
    }
}