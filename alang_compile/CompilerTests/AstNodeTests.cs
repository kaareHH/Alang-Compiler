using Antlr4.Runtime;
using AntlrGen;
using core_compile.Visitors;
using NUnit.Framework;
using core_compile.AbstractSyntaxTree;
using System.Text.RegularExpressions;
using System;
using System.IO;
using ValueType = core_compile.AbstractSyntaxTree.ValueType;

namespace CompilerTests
{
    [TestFixture]
    public class AstNodeTests
    {
        ProgramNode astRoot;

        [SetUp]
        public void Setup()
        {
            var filePath = "../../../test.alang";
            var AbsolutePath = Path.GetFullPath(filePath);
            if (TestHelpers.ReadFromFile(AbsolutePath, out var text)) return;
            this.astRoot = TestHelpers.MakeAstRoot(text);
        }

        [Test]
        public void AstShouldContainProgramAstNode()
        {
            Assert.IsInstanceOf(typeof(ProgramNode), astRoot);
        }

        [Test]
        public void AstHasChildren()
        {
            Assert.IsNotNull(astRoot.GetChildren());
        }

        [Test]
        public void ChildOfAstRootHasParentAstRoot()
        {
            Assert.AreSame(astRoot, astRoot.GetChildren().Parent);
        }

        [Test]
        public void AstRootHasNoParentOrSiblings()
        {
            Assert.IsNull(astRoot.Parent);
            Assert.IsNotNull(astRoot.LeftMostSibling);
            Assert.IsNull(astRoot.RightSibling);
        }

        [Test]
        public void EmptyAstRootHasNullNodeChildren()
        {
            var ast = TestHelpers.MakeAstRoot("");
            Assert.IsNotNull(ast.GetChildren());
            Assert.IsInstanceOf(typeof(NullNode), ast.GetChildren());
            Assert.IsInstanceOf(typeof(NullNode), ast.GetChildren().RightSibling);
        }

        [Test]
        public void DeclarationNodeHasCorrectTypeAndId()
        {
            var ast = TestHelpers.MakeAstRoot("number max = 10;");

            Assert.That(ast.GetChildren(), Is.TypeOf(typeof(NullNode)));
            Assert.That(ast.GetChildren().RightSibling, Is.TypeOf(typeof(DeclarationNode)));
            Assert.That(((DeclarationNode) ast.GetChildren().RightSibling).Identifier, Is.EqualTo("max"));
            Assert.That(((DeclarationNode) ast.GetChildren().RightSibling).Value.Value, Is.EqualTo(10));
        }
        
        [Test]
        public void ImportsShouldHaveCorrectPath()
        {
            Assert.AreEqual("std.alang", ((ImportNode)(astRoot.GetChildren())).Path);
            Assert.AreEqual("string.alang", ((ImportNode)astRoot.GetChildren().RightSibling).Path);
        }
        
        [Test]
        public void AstRootHasCorrectChildren()
        {
            Assert.IsInstanceOf(typeof(DeclarationNode), TestHelpers.GetChildOfIndex(astRoot, 2));
            Assert.IsInstanceOf(typeof(FunctionNode), TestHelpers.GetChildOfIndex(astRoot, 3));
            Assert.IsInstanceOf(typeof(FunctionNode), TestHelpers.GetChildOfIndex(astRoot, 4));
            Assert.IsInstanceOf(typeof(FunctionNode), TestHelpers.GetChildOfIndex(astRoot, 5));
            Assert.IsInstanceOf(typeof(DeclarationNode), TestHelpers.GetChildOfIndex(astRoot, 6));
            Assert.IsInstanceOf(typeof(FunctionNode), TestHelpers.GetChildOfIndex(astRoot, 7));
        }

        [Test]
        public void DeclarationShouldHaveTypeAndIdentifier()
        {
            var dclnode = new DeclarationNode("Torben");
            Assert.AreEqual(ValueType.Integer, dclnode.ValueKind);
            Assert.AreEqual("Torben", dclnode.Identifier);
        }

        [Test]
        public void AstRootHasStartAndEndOfWholeProgram()
        {
            Assert.IsNotNull(this.astRoot);
            Assert.AreEqual(0, this.astRoot.Start.Column);
            Assert.AreEqual(1, this.astRoot.Start.Line);

            Assert.AreEqual(0, this.astRoot.Stop.Column);
            Assert.AreEqual(61, this.astRoot.Stop.Line);
        }

        [Test]
        public void ImportNodeShouldHaveCorrectLocation()
        {
            var ast = TestHelpers.MakeAstRoot("import mads.alang;\nimport anders.alang;");

            Assert.AreEqual(1, ast.GetChildren().Start.Line);
            Assert.AreEqual(0, ast.GetChildren().Start.Column);
            Assert.AreEqual(2, ast.GetChildren().Stop.Line);
            Assert.AreEqual(19, ast.GetChildren().Stop.Column);
        }
    }
}