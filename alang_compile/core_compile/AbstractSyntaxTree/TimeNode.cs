using System;
using Antlr4.Runtime;
using AntlrGen;

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
    }
}