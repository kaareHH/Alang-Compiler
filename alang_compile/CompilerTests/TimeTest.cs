using core_compile.AbstractSyntaxTree;
using NUnit.Framework;

namespace CompilerTests
{
    [TestFixture]
    public class TimeTest
    {
        private const int Day=24*Hour, Hour=60*Min, Min=60*Sec, Sec = 1000;
        [Test]
        public void OneHour_ShouldReturn3600()
        {
            var time = new Time(){Hours = 1};
            Assert.That(time.ToMillis(), Is.EqualTo(Hour));
        }
        
        [Test]
        public void OneMin_ShouldReturnAMin()
        {
            var time = new Time(){Min = 1};
            Assert.That(time.ToMillis(), Is.EqualTo(Min));
        }
        
        [Test]
        public void TwentyFiveHours_ShouldReturnOneHour()
        {
            var time = new Time(){Hours = 25};
            Assert.That(time.ToMillis(), Is.EqualTo(Hour));
        }
        
        [Test]
        public void FiveHoursTwoMinutesOneSecond_ShouldReturn18121()
        {
            var time = new Time(){Hours = 5, Min = 2, Sec = 1};
            Assert.That(time.ToMillis(), Is.EqualTo(Hour * 5 + Min * 2 + Sec * 1));
        }
        
    }
    
}