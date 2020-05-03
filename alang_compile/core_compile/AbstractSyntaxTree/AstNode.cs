using System;
using System.Collections.Generic;
using Antlr4.Runtime;

namespace core_compile.AbstractSyntaxTree
{
    public abstract class AstNode
    {
        public Location Start { get; set; }
        public Location Stop { get; set; }

        public AstNode Parent { get; set; }
        public AstNode LeftMostChild { get; set; }
        public AstNode LeftMostSibling { get; set; }
        public AstNode RightSibling { get; set; }

        public AstNode()
        {
            LeftMostSibling = this;
        }


        public AstNode GetChildren()
        {
            return LeftMostChild;
        }

        // Implemented as shown in [CAC p. 253]
        public void AdobtChildren(AstNode y)
        {
            if (y == null)
            {
                return;
            }

            if (this.LeftMostChild != null)
            {
                this.LeftMostChild.MakeSiblings(y);
            }
            else
            {
                var ySibs = y.LeftMostSibling;
                this.LeftMostChild = ySibs;
                while (ySibs != null)
                {
                    ySibs.Parent = this;
                    ySibs = ySibs.RightSibling;
                }
            }
        }

        // Implemented as shown in [CAC p. 253]
        public AstNode MakeSiblings(AstNode y)
        {
            if (y == null)
            {
                return this;
            }

            var xSibs = this;

            while (xSibs.RightSibling != null)
            {
                xSibs = xSibs.RightSibling;
            }

            var ySibs = y.LeftMostSibling;
            xSibs.RightSibling = ySibs;

            ySibs.LeftMostSibling = xSibs.LeftMostSibling;
            ySibs.Parent = xSibs.Parent;

            while (ySibs.RightSibling != null)
            {
                ySibs = ySibs.RightSibling;
                ySibs.LeftMostSibling = xSibs.LeftMostSibling;
                ySibs.Parent = xSibs.Parent;
            }

            return xSibs;
        }

        public void AddLocationFromContext(ParserRuleContext context)
        {
            this.Start = new Location(context.Start.Line, context.Start.Column);
            this.Stop = new Location(context.Stop.Line, context.Stop.Column);
        }
    }
}
