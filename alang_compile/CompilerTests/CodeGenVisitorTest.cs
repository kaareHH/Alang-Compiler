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

        [Test]
        public void TryToCompileProgram()
        {
            AstNode astRoot = GetFromTestString();

            var visitor = new CodeGenVisitor();

            astRoot.Accept(visitor);
            visitor.WriteToFile();
        }

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

        private AstNode GetFromTestString()
        {
            var text = @"
            import std.alang; # finder lolleren.alang i mappen
            import string.alang;

            pin coffeMachine = 10;
            pin bedroomLight = 12;
            
            function setup -> | void
                OFF -> coffeMachine;
                OFF -> bedroomLight;
            endfunction

            function loop -> | void
                everyHour ->;

                # Define when each state is reached during the day
                if TIME >= 00:00:01 && TIME < 00:00:03 then
                    ON -> bedroomLight;
                else
                    OFF -> bedroomLight;
                endif
        
            endfunction

            function MorningRoutine ->| void
                ON -> coffeMachine;
            endfunction

            time TimePassed = 00:00:00;
            function everyHour ->| void
                int someVariable = 69;
                if TimePassed < 01:00:00 then
                    TimePassed = TimePassed + TIME;
                else
                    TimePassed = 00:00:00;
                    ON -> bedroomLight;
                endif
            endfunction

            function repeatTest -> | void
             int test = 2;
                while 2 do
                    test = test + 1;
                endwhile
            endfunction

            function expressionTest -> | void
                int kasper = test * 10 + (25 / 5);
            endfunction
            ";


            return TestHelpers.MakeAstRoot(text);
        }

    }
}