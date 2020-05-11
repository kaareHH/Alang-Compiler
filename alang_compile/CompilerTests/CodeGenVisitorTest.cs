using System;
using core_compile.Visitors;
using NUnit.Framework;

namespace CompilerTests
{
    [TestFixture]
    public class CodeGenVisitorTest
    {
        [Test]
        public void Declaration_EmitsRightCode()
        {
            var ast = TestHelpers.MakeAstRoot("int torben = 2;");
            var visitor = new CodeGenVisitor();

            ast.Accept(visitor);
            
            Assert.That(visitor.program , Is.EqualTo("int torben=2;\n"));
        }
        
    }
}