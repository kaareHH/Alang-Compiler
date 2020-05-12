using System;
using core_compile.AbstractSyntaxTree;
using core_compile.Visitors;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace CompilerTests
{
    [TestFixture]
    public class CodeGenVisitorTest
    {
        private EqualConstraint MatchCode(string code)
        {
            return Is.EqualTo($"#include <time.h>\n{code}");
        }
        [Test]
        public void Declaration_EmitsRightCode()
        {
            var ast = TestHelpers.MakeAstRoot("int torben = 2;");
            var visitor = new CodeGenVisitor();

            ast.Accept(visitor);
            
            Assert.That(visitor.program , MatchCode("int torben=2;") );
        }

        [Test]
        public void EnumToString_ShouldBetime_t()
        {
            var torben = LanguageType.Time;
            Assert.That(torben.ToEnumString(), Is.EqualTo("time_t"));
        }

        [Test]
        public void WriteToFile()
        {
            var ast = TestHelpers.MakeAstRoot("int torben = 2;");
            var visitor = new CodeGenVisitor();

            ast.Accept(visitor);
            visitor.WriteToFile();
        }

    }
}