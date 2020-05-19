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
        

        private AstNode GetFromTestString()
        {
            var text = @"
            import std.alang; # finder lolleren.alang i mappen
            import string.alang;

            pin coffeMachine = 10;
            pin bedroomLight = 12;
            pin light = 4;
            
            function setup -> | void
                OFF -> coffeMachine;
                OFF -> bedroomLight;
            endfunction

            function loop -> | void
                everyHour ->;

                # Define when each state is reached during the day
                int Morning = TIME >= 00:00:01 && TIME < 00:00:03;
                int Afternoon = TIME >= 00:00:05 && TIME < 00:00:07;
                if Morning || Afternoon then
                    ON -> bedroomLight;
                else
                    OFF -> bedroomLight;
                endif

                if Morning then
                    MorningRoutine->;
                endif
        
            endfunction

            function MorningRoutine ->| void
                ON -> coffeMachine;
            endfunction

            time TimePassed = 00:00:00;
            int toggle = 0;
            function everyHour ->| void
                int someVariable = 69;
                if TIME - TimePassed >= 00:00:01 then
                    TimePassed = TIME;
                    toggle = (toggle + 1) % 2;
                endif
                if toggle then
                    ON -> light;
                else
                    OFF -> light;
                endif
                    
            endfunction

            function repeatTest -> int tal, int tid | void
             int test = 2;
                while 2 do
                    int kasper = test * 10 + (25 / 5);
                endwhile
            endfunction
            ";


            return TestHelpers.MakeAstRoot(text);
        }

    }
}