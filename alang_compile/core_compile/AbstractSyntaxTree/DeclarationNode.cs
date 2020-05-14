using System;
using Antlr4.Runtime;
using AntlrGen;
using core_compile.Visitors;

namespace core_compile.AbstractSyntaxTree
{
    public class DeclarationNode : AstNode
    {
        public string Identifier { get; set; }
        public LanguageType Type { get; set; }

        public AstNode PrimaryExpression { get; set; }

        public DeclarationNode(ALangParser.DclContext context) : base(context) { }

        public DeclarationNode()
        {
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        public override LanguageType Accept(ITypeCheckerVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

}
