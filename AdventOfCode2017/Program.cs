using System.Diagnostics;
using AdventOfCode2017.Days;

for (var dayNumber = 1; dayNumber <= 25; dayNumber++)
{
    RunDay(dayNumber);
}

return;

void RunDay(int dayNumber)
{
    var day = GetDay(dayNumber);
    Console.WriteLine($"Day {dayNumber}");
    var start = Stopwatch.GetTimestamp();
    Console.WriteLine($"part1: {day.Part1()}\t\ttook {Stopwatch.GetElapsedTime(start).TotalMilliseconds} milliseconds");
    start = Stopwatch.GetTimestamp();
    Console.WriteLine($"part2: {day.Part2()}\t\ttook {Stopwatch.GetElapsedTime(start).TotalMilliseconds} milliseconds");
    Console.WriteLine();
}


Day GetDay(int day)
{
    var instance = (Day)Activator.CreateInstance(Type.GetType($"AdventOfCode2017.Days.Day{day}")!)!;

    return instance;
}