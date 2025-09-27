using System.Diagnostics;

for (var i = 1; i <= 25; i++)
{
    var start = Stopwatch.GetTimestamp();
    var (part1, part2) = GetSolutions($"AdventOfCode2017.Days.Day{i}");
    Console.WriteLine($"Day {i} took {Stopwatch.GetElapsedTime(start).TotalMilliseconds} milliseconds");
    Console.WriteLine($"part1: {part1}");
    Console.WriteLine($"part2: {part2}");
    Console.WriteLine();
}

return;


(string, string) GetSolutions(string className)
{
    var instance = Activator.CreateInstance(Type.GetType(className)!);

    var ans1 = Type.GetType(className)?
        .GetMethod("Part1")?
        .Invoke(instance, [])!.ToString()!;


    var ans2 = Type.GetType(className)?
        .GetMethod("Part2")?
        .Invoke(instance, [])!.ToString()!;


    return (ans1, ans2);
}