using System;

namespace core_compile.AbstractSyntaxTree
{
    public class Time
    {
        public int Sec { get; set; }
        public int Min { get; set; }

        public int Hours { get; set; }
        public static Time TimeFromString(string timeString)
        {
            var time = new Time();
            var timestringarray = timeString.Split(':');

            time.Hours = int.Parse(timestringarray[0]);
            time.Min = int.Parse(timestringarray[1]);
            time.Sec = int.Parse(timestringarray[2]);

            return time;
        }
        
        public const int MillisecondsInSeconds = 1000;
        public const int ADAYINSECONDS = HOURSINSECOUNDS * 24;
        public const int HOURSINSECOUNDS = MINSINSECOUNDS * 60;
        public const int MINSINSECOUNDS = 60;

        public int ToMillis()
        {
            return ((Hours * HOURSINSECOUNDS + Min * MINSINSECOUNDS + Sec) % ADAYINSECONDS) * MillisecondsInSeconds;
        }

        public override string ToString()
        {
            return ToMillis().ToString();
        }
    }
}