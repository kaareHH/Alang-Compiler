using Antlr4.Runtime;
using AntlrGen;
using core_compile.Visitors;
using NUnit.Framework;
using core_compile.AbstractSyntaxTree;
using System.Text.RegularExpressions;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Transactions;
using core_compile;

namespace CompilerTests
{
    [TestFixture]
    public class AstNodeTests
    {
        CompilationUnit astRoot;

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
            Assert.IsInstanceOf(typeof(CompilationUnit), astRoot);
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
            Assert.That(ast, Is.TypeOf<CompilationUnit>());
            Assert.That(ast.GetChildren(), Is.TypeOf<NullNode>());
        }

        [Test]
        public void DeclarationNodeHasCorrectTypeAndId()
        {
            // https://stackoverflow.com/questions/39386586/c-sharp-generic-interface-and-factory-pattern
            AstNode astMads = astRoot.GetChildren(2);
            Assert.That(astMads, Is.TypeOf<DeclarationNode>());

            DeclarationNode dclMads = astMads as DeclarationNode;
            Assert.That(dclMads.Identifier, Is.EqualTo("mads"));
            Assert.That(dclMads.Type, Is.EqualTo(LanguageType.Int));
        }

        [Test]
        public void FunctionNodeHasCorrectIdAndTypeAndChildren()
        {
            AstNode presumableFuncNode = astRoot.GetChildren(3);
            Assert.That(presumableFuncNode, Is.TypeOf<FunctionNode>());

            FunctionNode functionNode = presumableFuncNode as FunctionNode;
            Assert.That(functionNode.Identifier, Is.EqualTo("setup"));
            Assert.That(functionNode.Type, Is.EqualTo(LanguageType.Void));
            Assert.That(functionNode.NumberOfChildren, Is.EqualTo(8));
        }

        [Test]
        public void FourthChildOfRoot_ReturnsCorrectNodeTypes()
        {
            FunctionNode funcNode = astRoot.GetChildren(4) as FunctionNode;

            Assert.That(funcNode.GetChildren(0), Is.TypeOf<FunctionCallNode>());
            Assert.That(funcNode.GetChildren(1), Is.TypeOf<IfNode>());
            Assert.That(funcNode.GetChildren(2), Is.TypeOf<IfNode>());
            Assert.That(funcNode.GetChildren(3), Is.TypeOf<IfNode>());
        }

        [Test]
        public void IfNode_ShouldHaveAlternative()
        {
            FunctionNode funcNode = astRoot.GetChildren(4) as FunctionNode;
            AstNode presumableIfNode = funcNode.GetChildren(1);
            Assert.That(presumableIfNode, Is.TypeOf<IfNode>());

            IfNode ifNode = presumableIfNode as IfNode;
            Assert.That(ifNode.Alternative, Is.Not.Null);
        }

        [Test]
        public void FifthChildOfRoot_ReturnsCorrectNodeTypes()
        {
            FunctionNode funcNode = astRoot.GetChildren(5) as FunctionNode;

            Assert.That(funcNode.GetChildren(0), Is.TypeOf<OutputNode>());
            Assert.That(funcNode.GetChildren(1), Is.TypeOf<IfNode>());
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
            Assert.IsInstanceOf(typeof(ImportNode), astRoot.GetChildren(0));
            Assert.IsInstanceOf(typeof(ImportNode), astRoot.GetChildren(1));
            Assert.IsInstanceOf(typeof(DeclarationNode), astRoot.GetChildren(2));
            Assert.IsInstanceOf(typeof(FunctionNode), astRoot.GetChildren(3));
            Assert.IsInstanceOf(typeof(FunctionNode), astRoot.GetChildren(4));
            Assert.IsInstanceOf(typeof(FunctionNode), astRoot.GetChildren(5));
            Assert.IsInstanceOf(typeof(DeclarationNode), astRoot.GetChildren(6));
            Assert.IsInstanceOf(typeof(FunctionNode), astRoot.GetChildren(7));
        }

        [Test]
        public void AstRootHasStartAndEndOfWholeProgram()
        {
            Assert.IsNotNull(this.astRoot);
            Assert.AreEqual(0, this.astRoot.Start.Column);
            Assert.AreEqual(1, this.astRoot.Start.Line);

            Assert.AreEqual(0, this.astRoot.Stop.Column);
            Assert.AreEqual(70, this.astRoot.Stop.Line);
        }

        [Test]
        public void ImportNodeShouldHaveCorrectLocation()
        {
            var ast = TestHelpers.MakeAstRoot("import mads.alang;\nimport anders.alang;");

            var firstchild = ast.GetChildren();
            Assert.AreEqual(1, firstchild.Start.Line);
            Assert.AreEqual(0, firstchild.Start.Column);
            Assert.AreEqual(1, firstchild.Stop.Line);
            Assert.AreEqual(17, firstchild.Stop.Column);

            var secondChild = firstchild.RightSibling;
            Assert.AreEqual(2, secondChild.Start.Line);
            Assert.AreEqual(0, secondChild.Start.Column);
            Assert.AreEqual(2, secondChild.Stop.Line);
            Assert.AreEqual(19, secondChild.Stop.Column);
        }

        [Test]
        public void RepeatTestFunction_ShouldHaveRepeatNodeAsSecondChild()
        {
            FunctionNode funcNode = this.astRoot.GetChildren(8) as FunctionNode;
            Assert.That(funcNode.Identifier, Is.EqualTo("repeatTest"));

            Assert.That(funcNode.GetChildren(1), Is.TypeOf<RepeatNode>());
        }

        [Test]
        public void RepeatTestNode_ShouldHaveLoopExpression()
        {
            FunctionNode funcNode = this.astRoot.GetChildren(8) as FunctionNode;
            var repeatNode = funcNode.GetChildren(1) as RepeatNode;

            Assert.That(repeatNode.LoopExpression, Is.Not.Null);
        }

        [Test]
        public void RepeatTestNode_ShouldHaveAssignmentChild()
        {
            FunctionNode funcNode = this.astRoot.GetChildren(8) as FunctionNode;
            var repeatNode = funcNode.GetChildren(1) as RepeatNode;

            Assert.That(repeatNode.GetChildren(0), Is.TypeOf<AssignmentNode>());
        }
    }
}