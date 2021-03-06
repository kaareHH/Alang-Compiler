using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using AntlrGen;
using core_compile.Visitors;

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

        public AstNode(ParserRuleContext context) : this()
        {
            AddLocationFromContext(context);
        }

        public void AcceptChildren(IVisitor visitor)
        {
            var child = LeftMostChild;
            while (child != null)
            {
                child.Accept(visitor);
                child = child.RightSibling;
            }
        }
        
        public LanguageType AcceptChildren(ITypeCheckerVisitor visitor)
        {
            var child = LeftMostChild;
            while (child != null)
            {
                child.Accept(visitor);
                child = child.RightSibling;
            }

            return LanguageType.Null;
        }

        public void AcceptSiblings(AstNode node, IVisitor visitor)
        {
            var child = node;
            while (child != null)
            {
                child.Accept(visitor);
                child = child.RightSibling;
            }
        }
        public void AcceptSiblings(AstNode node, ITypeCheckerVisitor visitor)
        {
            var child = node;
            while (child != null)
            {
                child.Accept(visitor);
                child = child.RightSibling;
            }
        }

        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        
        public virtual LanguageType Accept(ITypeCheckerVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public int NumberOfChildren
        {
            get
            {
                int children = 0;

                var node = GetChildren();

                while (node != null)
                {
                    children++;
                    node = node.RightSibling;
                }

                return children;
            }
        }
        
        public int NumberOfSiblings
        {
            get
            {
                int siblings = 1;

                var node = this;
                while (node.RightSibling != null)
                {
                    siblings++;
                    node = node.RightSibling;
                }

                return siblings;
            }
        }



        public AstNode GetChildren()
        {
            return LeftMostChild;
        }
        public AstNode GetChildren(int i)
        {
            if (i == 0)
                return GetChildren();

            var node = GetChildren();
            for (int j = 0; j < i; j++)
            {
                node = node.RightSibling;
            }
            return node;

        }

        // Implemented as shown in [CAC p. 253]
        public void AdoptChildren(AstNode y)
        {
            if (y == null)
            {
                return;
            }

            if (LeftMostChild != null)
            {
                LeftMostChild.MakeSiblings(y);
            }
            else
            {
                var ySibs = y.LeftMostSibling;
                LeftMostChild = ySibs;
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
            if (context.Start != null && context.Stop != null)
            {
                Start = new Location(context.Start.Line, context.Start.Column);
                Stop = new Location(context.Stop.Line, context.Stop.Column);
            }
            else
            {
                Start = new Location(1, 0);
                Stop = new Location(1, 0);
            }
        }
    }
}
