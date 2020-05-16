using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using core_compile.AbstractSyntaxTree;
using core_compile.Exceptions;
using core_compile.SymbolTableClasses;
using core_compile.Visitors;
using NUnit.Framework;
using Type = System.Type;

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
            var ast = TestHelpers.MakeAstRoot(@"
            int testrup = 2;
            function lars -> | void
                testrup = 00:00:00;
            endfunction");
            var visitor = new TypeCheckerVisitor();
            var symVisitor = new SymbolTableVisitor();
            ast.Accept(symVisitor);

            Assert.Throws<Exception>(() => ast.Accept(visitor));
        }

        [Test]
        public void FunctionParams_ShouldThrowFunctionCalledWithWrongTypeException()
        {
            ThrowsExceptionOfType<FunctionCalledWithWrongTypeException>(@"
            function takeint -> int heltal | void
            endfunction
            function try -> | void
                takeint -> 00:00:00; # Should not be possible.
            endfunction");
        }

        
        
        [Test]
        public void FunctionParams_ThrowsTooFewArgumentsException()
        {
            ThrowsExceptionOfType<TooFewArgumentsException>(@"
            function takeint -> int heltal | void
            endfunction
            function try -> | void
                takeint ->; # Should have some input param.
            endfunction");
        }

        [Test]
        public void TooManyArgumentsInFunction_ShouldThrowTooManyArgumentsException()
        {
            ThrowsExceptionOfType<TooManyArgumentsException>(@"
            function takeint -> int heltal | void
            endfunction
            function try -> | void
                takeint -> 2, 2; # function takeint only takes 1 argument.
            endfunction");
        }
        
        private void ThrowsExceptionOfType<T>(string code) where T : Exception
        {
            var ast = TestHelpers.MakeAstRoot(code);
            
            var symbolTableVisitor = new SymbolTableVisitor();
            var typeCheckerVisitor = new TypeCheckerVisitor();
            ast.Accept(symbolTableVisitor);
            
            Assert.Throws<T>(() => ast.Accept(typeCheckerVisitor));
        }
        
        private void DoesNotThrowExceptionOfType(string code)
        {
            var ast = TestHelpers.MakeAstRoot(code);
            
            var symbolTableVisitor = new SymbolTableVisitor();
            var typeCheckerVisitor = new TypeCheckerVisitor();
            ast.Accept(symbolTableVisitor);
            
            Assert.DoesNotThrow(() => ast.Accept(typeCheckerVisitor));
        }

        [Test]
        public void IfNode_ConditionWShouldThrowException()
        {
            ThrowsExceptionOfType<TypeDoNotMatchConditionException>(@"
            function try -> | void
                pin cond = P2;
                if cond then
                    # Something.
                endif
            endfunction");
        }
        [Test]
        public void IfNode_ConditionWShouldNotThrowException()
        {
            DoesNotThrowExceptionOfType(@"
            function try -> | void
                int cond = 1;
                int condTwo = 2;
                if cond > condTwo then
                    # Something.
                endif
            endfunction");
        }

        [Test]
        public void WhileNode_ConditionWShouldThrowException()
        {
            ThrowsExceptionOfType<TypeDoNotMatchConditionException>(@"
            function try -> | void
                pin cond = P2;
                while cond do
                    # Something.
                endwhile
            endfunction");
        }
        [Test]
        public void WhileNode_ConditionWShouldNotThrowException()
        {
            ThrowsExceptionOfType<InvalidExpressionException>(@"
            function try -> | void
                time cond = 01:00:00;
                int condTwo = 2;
                while cond > condTwo && 1 == 2 do
                    # Something.
                endwhile
            endfunction");
        }
    }
}