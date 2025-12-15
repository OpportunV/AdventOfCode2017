using Common.Extensions;

namespace AdventOfCode2017.Days;

public class Day15 : Day
{
    private const long GeneratorA = 16807;
    private const long GeneratorB = 48271;
    private const long Mod = 2147483647;
    private const int Part1Iterations = 40_000_000;
    private const int Part2Iterations = 5_000_000;

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
            var bitsA = Convert.ToString(nextA, 2);
            var bitsB = Convert.ToString(nextB, 2);

            if (AreEqual(bitsA, bitsB))
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

            var bitsA = Convert.ToString(nextA, 2);
            var bitsB = Convert.ToString(nextB, 2);

            if (AreEqual(bitsA, bitsB))
            {
                ans++;
            }
        }

        return ans;
    }

    private static bool AreEqual(string a, string b)
    {
        for (var i = 1; i <= 16; i++)
        {
            if (a[^i] != b[^i])
            {
                return false;
            }
        }

        return true;
    }
}