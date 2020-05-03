using Antlr4.Runtime;
using AntlrGen;
using core_compile.Visitors;
using NUnit.Framework;
using core_compile.AbstractSyntaxTree;
using System.Text.RegularExpressions;
using System;
using System.IO;

namespace CompilerTests
{
    [TestFixture]
    public class AstTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AstNodeShouldAdobtChild()
        {
            var newAstRoot = new ProgramNode();
            var importNode = new ImportNode();
            newAstRoot.AdobtChildren(importNode);
            Assert.IsNotNull(newAstRoot.GetChildren());
            Assert.IsInstanceOf(typeof(ImportNode), newAstRoot.GetChildren());
        }

        [Test]
        public void AstNodeShouldNotAdobtNull()
        {
            var newAstRoot = new ProgramNode();
            Assert.IsNotNull(newAstRoot.LeftMostSibling);

            newAstRoot.AdobtChildren(null);
            Assert.IsNotNull(newAstRoot.LeftMostSibling);
        }

        [Test]
        public void AdobtedChildHasCorrectParent()
        {
            var newAstRoot = new ProgramNode();
            newAstRoot.AdobtChildren(new ImportNode());
            newAstRoot.AdobtChildren(new ImportNode());

            for (AstNode child = newAstRoot.GetChildren(); child.RightSibling != null; child = child.RightSibling)
            {
                Assert.AreSame(newAstRoot, child.Parent);
            }
        }

        [Test]
        public void AllChildrenPointsToLeftMostSibling()
        {
            var newAstRoot = new ProgramNode();
            newAstRoot.AdobtChildren(new ImportNode());
            newAstRoot.AdobtChildren(new ImportNode());
            newAstRoot.AdobtChildren(new ImportNode());
            var leftMostSibling = newAstRoot.GetChildren();

            for (AstNode child = leftMostSibling; child.RightSibling != null; child = child.RightSibling)
            {
                Assert.AreSame(leftMostSibling, child.LeftMostSibling);
            }
        }

        [Test]
        public void LeftMostChildOfAstRootShouldBeLeftMostSibling()
        {
            var newAstRoot = new ProgramNode();
            newAstRoot.AdobtChildren(new ImportNode());
            Assert.AreEqual(newAstRoot.LeftMostChild, newAstRoot.GetChildren().LeftMostSibling);
        }

        [Test]
        public void MakeSiblingShouldChainSiblings()
        {
            var newAstRoot = new ProgramNode();
            var node = new ImportNode();
            newAstRoot.AdobtChildren(node);

            var node2 = new ImportNode();
            var node3 = new ImportNode();

            node = (ImportNode)node.MakeSiblings(node2.MakeSiblings(node3));

            Assert.AreSame(node, node2.LeftMostSibling);
            Assert.AreSame(node2, node.RightSibling);
            Assert.AreSame(node, node3.LeftMostSibling);
            Assert.AreSame(node3, node2.RightSibling);
        }

        [Test]
        public void MakeSiblingsShouldAssignCorrectParent()
        {
            var newAstRoot = new ProgramNode();
            var node = new ImportNode();
            newAstRoot.AdobtChildren(node);

            var node2 = new ImportNode();
            var node3 = new ImportNode();

            node = (ImportNode)node.MakeSiblings(node2.MakeSiblings(node3));

            Assert.AreSame(newAstRoot, node.Parent);
            Assert.AreSame(newAstRoot, node2.Parent);
            Assert.AreSame(newAstRoot, node3.Parent);
        }

        [Test]
        public void ImportsHasCorrectParent()
        {
            var ast = TestHelpers.MakeAstRoot("import lol.alang;\nimport torben.alang;");
            Assert.AreSame(ast, ast.GetChildren().Parent);
            Assert.AreSame(ast, (ast.GetChildren().RightSibling).Parent);
        }
    }
}