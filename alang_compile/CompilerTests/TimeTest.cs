using core_compile.AbstractSyntaxTree;
using NUnit.Framework;

namespace CompilerTests
{
    [TestFixture]
    public class TimeTest
    {
        private const int Day = 86400, Hour = 3600, Min = 60, Sec = 1;
        [Test]
        public void OneHour_ShouldReturn3600()
        {
            var time = new Time(){Hours = 1};
            Assert.That(time.ToSeconds(), Is.EqualTo(Hour));
        }
        
        [Test]
        public void OneMin_ShouldReturnAMin()
        {
            var time = new Time(){Min = 1};
            Assert.That(time.ToSeconds(), Is.EqualTo(Min));
        }
        
        [Test]
        public void TwentyFiveHours_ShouldReturnOneHour()
        {
            var time = new Time(){Hours = 25};
            Assert.That(time.ToSeconds(), Is.EqualTo(Hour));
        }
        
        [Test]
        public void FiveHoursTwoMinutesOneSecond_ShouldReturn18121()
        {
            var time = new Time(){Hours = 5, Min = 2, Sec = 1};
            Assert.That(time.ToSeconds(), Is.EqualTo(Hour * 5 + Min * 2 + Sec * 1));
        }
        
    }
    
}