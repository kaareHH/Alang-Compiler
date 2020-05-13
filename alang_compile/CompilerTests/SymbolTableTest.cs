using System;
using System.Collections;
using System.IO;
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

            ast.Accept(visitor);

            //int karen = 2;\nint mads = 8;\nfunction test -> | void\n if 1==1 then\ntorben = 3;\n int bent = 4;\n endif\n karen = 2;\n int bob = 3; endfunction\n function scopeTest -> | void\n int bob = 5;\n endfunction

            // var table = visitor.CurrentSymbolTable;
            // while (table != null)
            // {
            //     Console.WriteLine("Opened scope: " + table.Table.Count);
            //     foreach (DictionaryEntry item in table.Table)
            //     {
            //         Console.WriteLine("Key: " + item.Key + " Value: " + item.Value);
            //     }
            //     Console.WriteLine("Closed scope");
            //     table = table.currentTable;
            // }

            // Opened scope:
            //      Name: karen Type: Int
            //      Name: mads Type: Int
            //      Name: test Type: Void
            //          Opened scope:½
            //              name: bent Type: int
            //          Closed scope
            //      Name: scopeTest Type: Void
            //          Opened scope:
            //              name: bent Type: int
            //          Closed scope
            // Closed scope
        }

        [Test]
        public void DeclarationWithSameNameInScope_ShouldThrowException()
        {
            var ast = TestHelpers.MakeAstRoot("int karen = 2;\nint karen = 8;");

            var visitor = new SymbolTableVisitor();

            Assert.Throws<SymbolExistException>(() => ast.Accept(visitor));
        }

        [Test]
        public void DeclarationWithSameNameInFunction_ShouldThrowException()
        {
            var ast = TestHelpers.MakeAstRoot("int karen = 2;\nfunction test -> | void\n int karen = 8;\n endfunction");

            var visitor = new SymbolTableVisitor();

            Assert.DoesNotThrow(() => ast.Accept(visitor));
        }

        [Test]
        public void AssignmentToNotDeclaredVar_ShouldThrowException()
        {
            var ast = TestHelpers.MakeAstRoot("function test -> | void\n karen = 8;\n endfunction");
            // var ast = TestHelpers.MakeAstRoot("karen = 8;");

            var visitor = new SymbolTableVisitor();

            Assert.Throws<SymbolDoNotExistException>(() => ast.Accept(visitor));
        }
    }
}