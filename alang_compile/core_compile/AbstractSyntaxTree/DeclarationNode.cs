using System;
using Antlr4.Runtime;
using AntlrGen;

namespace core_compile.AbstractSyntaxTree
{
    public class DeclarationNode : AstNode
    {
        public string Identifier { get; set; }
        public LanguageType Type { get; set; }
        
        public ExpressionNode Value { get; set; }
        
        public DeclarationNode(ALangParser.DclContext context) : base (context) { }

        public DeclarationNode()
        {
        }
    }

}
