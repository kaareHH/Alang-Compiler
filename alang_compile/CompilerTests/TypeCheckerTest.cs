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
        public void Peter()
        {
            var ast = TestHelpers.MakeAstRoot("int testrup = 2 + 3 + 4 * 2;");
            var visitor = new TypeCheckerVisitor();
            ast.Accept(visitor);
            Assert.Fail();
        }
    }
}