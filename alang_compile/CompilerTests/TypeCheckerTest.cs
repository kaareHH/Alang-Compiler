using System;
using System.Collections;
using System.IO;
using core_compile.AbstractSyntaxTree;
using core_compile.SymbolTableClasses;
using core_compile.Visitors;
using NUnit.Framework;

namespace CompilerTests
{
    [TestFixture]
    public class TypeCheckerTest
    {
        // [Test]
        // public void InvalidExpression_ShouldThrowException()
        // {
        //     var ast = TestHelpers.MakeAstRoot("time karl = 00:00:00;\n int karen = karl;");

        //     var visitor = new TypeCheckerVisitor();

        //     Assert.Throws<Exception>(() => ast.Accept(visitor));
        // }

        // [Test]
        // public void Anders()
        // {
        //     var ast = TestHelpers.MakeAstRoot("time karl = 00:00:00;\n time karen = karl;");
        //     var visitor = new TypeCheckerVisitor();
        //     Assert.DoesNotThrow(() => ast.Accept(visitor));
        // }

        [Test]
        public void DeclarationOfTimeToInt_ShouldThrowException()
        {
            var ast = TestHelpers.MakeAstRoot("int testrup = 00:00:00;");
            var visitor = new TypeCheckerVisitor();
            Assert.Throws<Exception>(() => ast.Accept(visitor));
        }

        [Test]
        public void AssignmentOfTimeToInt_ShouldThrowException()
        {
            // System.Console.WriteLine("asdasd");
            var ast = TestHelpers.MakeAstRoot("int testrup = 2; function lars -> | void\n testrup = 00:00:00; endfunction");
            var visitor = new TypeCheckerVisitor();
            var symVisitor = new SymbolTableVisitor();
            ast.Accept(symVisitor);
            Assert.Throws<Exception>(() => ast.Accept(visitor));
        }

        [Test]
        public void FunctionParams_ShouldThrowExeption()
        {
            var ast = TestHelpers.MakeAstRoot("int testrup = 2; function lars -> int franz | void\n testrup = 2; endfunction\n function mads -> | void\n lars -> 00:00:00; int alberte = 4; endfunction");
            var visitor = new TypeCheckerVisitor();
            var symVisitor = new SymbolTableVisitor();
            ast.Accept(symVisitor);
            Assert.Throws<Exception>(() => ast.Accept(visitor));
        }
    }
}