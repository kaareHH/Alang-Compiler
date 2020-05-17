using Antlr4.Runtime;
using AntlrGen;
using core_compile.Visitors;
using NUnit.Framework;
using core_compile.AbstractSyntaxTree;
using System.Text.RegularExpressions;
using System;
using System.ComponentModel.Design;
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
        public void GetChildrenShouldReturnSecondChild()
        {
            var ast = new CompilationNode
            {
                LeftMostChild = new ImportNode { RightSibling = new ImportNode() }
            };
            
            var firstChild = ast.LeftMostChild;
            var secondChild = ast.LeftMostChild.RightSibling;
            Assert.AreSame(firstChild, ast.GetChildren(0));
            Assert.AreSame(secondChild, ast.GetChildren(1));
        }

        [Test]
        public void GetChildrenOne_IsNotADeclaration()
        {
            var ast = new CompilationNode
            {
                LeftMostChild = new DeclarationNode() { RightSibling = new ImportNode { RightSibling = new DeclarationNode()} }
            };
            
            Assert.That(ast.GetChildren(1), Is.TypeOf<ImportNode>() );
        }

        [Test]
        public void GetChildren_Returns3Children()
        {
            var ast = new CompilationNode
            {
                LeftMostChild = new DeclarationNode() { RightSibling = new ImportNode { RightSibling = new DeclarationNode()} }
            };
            
            Assert.That(ast.NumberOfChildren, Is.EqualTo(3));
        }
        
        [Test]
        public void GetChildren_Returns0Children()
        {
            var ast = new CompilationNode();
            
            Assert.That(ast.NumberOfChildren, Is.EqualTo(0));
            
        }

        [Test]
        public void AstNodeShouldAdoptChild()
        {
            var newAstRoot = new CompilationNode();
            var importNode = new ImportNode();
            newAstRoot.AdoptChildren(importNode);
            Assert.IsNotNull(newAstRoot.GetChildren());
            Assert.IsInstanceOf(typeof(ImportNode), newAstRoot.GetChildren());
        }

        [Test]
        public void AstNodeShouldNotAdobtNull()
        {
            var newAstRoot = new CompilationNode();
            Assert.IsNotNull(newAstRoot.LeftMostSibling);

            newAstRoot.AdoptChildren(null);
            Assert.IsNotNull(newAstRoot.LeftMostSibling);
        }

        [Test]
        public void AdobtedChildHasCorrectParent()
        {
            var newAstRoot = new CompilationNode();
            newAstRoot.AdoptChildren(new ImportNode());
            newAstRoot.AdoptChildren(new ImportNode());

            for (AstNode child = newAstRoot.GetChildren(); child.RightSibling != null; child = child.RightSibling)
            {
                Assert.AreSame(newAstRoot, child.Parent);
            }
        }

        [Test]
        public void AllChildrenPointsToLeftMostSibling()
        {
            var newAstRoot = new CompilationNode();
            newAstRoot.AdoptChildren(new ImportNode());
            newAstRoot.AdoptChildren(new ImportNode());
            newAstRoot.AdoptChildren(new ImportNode());
            var leftMostSibling = newAstRoot.GetChildren();

            for (AstNode child = leftMostSibling; child.RightSibling != null; child = child.RightSibling)
            {
                Assert.AreSame(leftMostSibling, child.LeftMostSibling);
            }
        }

        [Test]
        public void LeftMostChildOfAstRootShouldBeLeftMostSibling()
        {
            var newAstRoot = new CompilationNode();
            newAstRoot.AdoptChildren(new ImportNode());
            Assert.AreEqual(newAstRoot.LeftMostChild, newAstRoot.GetChildren().LeftMostSibling);
        }

        [Test]
        public void MakeSiblingShouldChainSiblings()
        {
            var newAstRoot = new CompilationNode();
            var node = new ImportNode();
            newAstRoot.AdoptChildren(node);

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
            var newAstRoot = new CompilationNode();
            var node = new ImportNode();
            newAstRoot.AdoptChildren(node);

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