using System;
using Antlr4.Runtime;
using AntlrGen;
using core_compile.Visitors;

namespace core_compile.AbstractSyntaxTree
{
    public class TimeNode : AstNode
    {
        public Time Value { get; set; }
        public TimeNode()
        {
        }

        public TimeNode(ParserRuleContext context) : base(context)
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