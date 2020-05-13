#include <time.h>
time_t TIME = now(); //maybeimport lul
//maybeimport lul
int coffeMachine = 10;
int bedroomLight = 12;
void setup()
{
    digitalWrite(coffeMachine, LOW);
    digitalWrite(bedroomLight, LOW);
}
void loop()
{
    TIME = millis();
    everyHour();
    if (TIME >= 1000 && TIME < 3000)
    {
        digitalWrite(bedroomLight, HIGH);
    }
    else
    {
        digitalWrite(bedroomLight, LOW);
    }
}
void MorningRoutine()
{
    digitalWrite(coffeMachine, HIGH);
}
time_t TimePassed = 0;
void everyHour()
{
    int someVariable = 69;
    if (TimePassed < 3600000)
    {
        TimePassed = TimePassed + TIME;
    }
    else
    {
        TimePassed = 0;
    }
}
void repeatTest()
{
    int test = 2;
    while (2)
    {
        test = test + 1;
    }
}
void expressionTest()
{
    int kasper = test * 10 + (25 / 5);
}
