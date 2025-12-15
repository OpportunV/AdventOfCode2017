using Common.Extensions;

namespace AdventOfCode2017.Days;

public class Day15 : Day
{
    private const long GeneratorA = 16807;
    private const long GeneratorB = 48271;
    private const long Mod = 2147483647;
    private const int Part1Iterations = 40_000_000;
    private const int Part2Iterations = 5_000_000;
    private const long RelevantBits = 0xFFFF;

    public override object Part1()
    {
        var generators = GetInput()
            .Select(line => line.GetNumbers<long>()[0])
            .ToList();

        var ans = 0L;
        for (var i = 0; i < Part1Iterations; i++)
        {
            var nextA = generators[0] * GeneratorA % Mod;
            var nextB = generators[1] * GeneratorB % Mod;
            generators[0] = nextA;
            generators[1] = nextB;
            if ((nextA & RelevantBits) == (nextB & RelevantBits))
            {
                ans++;
            }
        }

        return ans;
    }

    public override object Part2()
    {
        var generators = GetInput()
            .Select(line => line.GetNumbers<long>()[0])
            .ToList();

        var ans = 0L;
        for (var i = 0; i < Part2Iterations; i++)
        {
            var nextA = generators[0] * GeneratorA % Mod;
            generators[0] = nextA;
            while (nextA % 4 != 0)
            {
                nextA = generators[0] * GeneratorA % Mod;
                generators[0] = nextA;
            }

            var nextB = generators[1] * GeneratorB % Mod;
            generators[1] = nextB;
            while (nextB % 8 != 0)
            {
                nextB = generators[1] * GeneratorB % Mod;
                generators[1] = nextB;
            }

            if ((nextA & RelevantBits) == (nextB & RelevantBits))
            {
                ans++;
            }
        }

        return ans;
    }
}