using System;
using System.Collections;
using System.IO;
using core_compile;
using core_compile.AbstractSyntaxTree;
using core_compile.SymbolTableClasses;
using core_compile.Visitors;
using NUnit.Framework;

namespace CompilerTests
{
    [TestFixture]
    public class SymbolTableTest
    {
        [Test]
        public void Declaration_shouldbeInCorrectSCope()
        {
            var ast = TestHelpers.MakeAstRoot("int karen = 2;\nint mads = 8;\nfunction test -> | void\n if 1==1 then\nint torben = 3;\n" +
                                              "int bent = 4;\n endif\n karen = 2;\n int bob = 3; endfunction\n function scopeTest -> | void\n int bob = 6; endfunction\nint peter = 8;");

            var visitor = new SymbolTableVisitor();

            Assert.DoesNotThrow(() => ast.Accept(visitor));
        }

        [Test]
        public void DeclarationWithSameNameInScope_ShouldThrowException()
        {
            var ast = TestHelpers.MakeAstRoot("int karen = 2;\nint karen = 8;");

            var visitor = new SymbolTableVisitor();

            Assert.Throws<AlangExeption>(() => ast.Accept(visitor));
        }

        [Test]
        public void DeclarationWithSameNameInFunction_ShouldThrowException()
        {
            var ast = TestHelpers.MakeAstRoot("int karen = 2;\nfunction test -> | void\n int karen = 8;\n endfunction");

            var visitor = new SymbolTableVisitor();

            Assert.DoesNotThrow(() => ast.Accept(visitor));
        }



        [Test]
        public void AssignmentInTwoFunctions_ShouldNotThrowException()
        {
            var ast = TestHelpers.MakeAstRoot("int karen = 2;\nfunction test -> | void\n int karen = 8;\n endfunction\nfunction testFunc -> | void\n karen = 13;\n endfunction");

            var visitor = new SymbolTableVisitor();

            Assert.DoesNotThrow(() => ast.Accept(visitor));
        }

        [Test]
        public void GlobalScope_ShouldNotReachInnerFunction()
        {
            var ast = TestHelpers.MakeAstRoot("function test -> | void\n int karen = 8;\n endfunction\n int karen = 2;");

            var visitor = new SymbolTableVisitor();

            Assert.DoesNotThrow(() => ast.Accept(visitor));
        }

        [Test]
        public void FunctionParams_ShouldBeSavedInFunctionScope()
        {
            var ast = TestHelpers.MakeAstRoot("function test -> int bobby | void\n int bobby = 2; \n endfunction\n");

            var visitor = new SymbolTableVisitor();

            Assert.Throws<AlangExeption>(() => ast.Accept(visitor));
        }

        [Test]
        public void FunctionParams_ShouldBeSavedInFunctionScopeAnd_ShouldNotThrowExceptionWhenCorrectlyUsed()
        {
            var ast = TestHelpers.MakeAstRoot("function test -> int bobby | void\n bobby = 2; \n endfunction\n");

            var visitor = new SymbolTableVisitor();

            Assert.DoesNotThrow(() => ast.Accept(visitor));
        }

        [Test]
        public void FunctionParams_ShouldBeSavedInFunctionScope_v2()
        {
            var ast = TestHelpers.MakeAstRoot("int max = 2;\nfunction test -> int max | void\n max = 2; \n endfunction\n");

            var visitor = new SymbolTableVisitor();

            Assert.DoesNotThrow(() => ast.Accept(visitor));
        }

        [Test]
        public void FunctionParamVariables_ShouldBeCheckedIfTheyExistsAndThrowAnExceptionIfTheyDoNotExist_OtherwiseItShouldNotDoThat()
        {
            var ast = TestHelpers.MakeAstRoot("int max = 2;\nint peter = 2;\nfunction test -> int max | void\n peter = max + max; \n endfunction\n function main -> | void\n test -> peter;\n endfunction\n");

            var visitor = new SymbolTableVisitor();

            Assert.DoesNotThrow(() => ast.Accept(visitor));
        }

        [Test]
        public void CompilationNode_ShouldHaveSymbolTable()
        {
            var ast = TestHelpers.MakeAstRoot("int max = 2;\nint peter = 2;\nfunction test -> int max | void\n peter = max + max; \n endfunction\n function main -> | void\n test -> peter;\n endfunction\n");

            var visitor = new SymbolTableVisitor();

            ast.Accept(visitor);

            Assert.That(ast.SymbolTable, Is.Not.Null);
            Assert.That(((FunctionNode)ast.GetChildren(2)).SymbolTable, Is.Not.Null);
        }
    }
}