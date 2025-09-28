using Common.Extensions;

namespace AdventOfCode2017.Days;

public class Day2 : Day
{
    public override object Part1()
    {
        var lines = GetInput();

        return lines
            .Select(line => line.GetNumbers<int>())
            .Select(nums => nums.Max() - nums.Min())
            .Sum();
    }

    public override object Part2()
    {
        var lines = GetInput();

        return lines
            .Select(line => line
                .GetNumbers<int>()
                .DoubleIteration()
                .Where(pair => Math.Max(pair.Item1, pair.Item2) % Math.Min(pair.Item1, pair.Item2) == 0)
                .Select(pair => Math.Max(pair.Item1, pair.Item2) / Math.Min(pair.Item1, pair.Item2))
                .First())
            .Sum();
    }
}