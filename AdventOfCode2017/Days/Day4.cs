using AdventOfCode2017.Helpers;

namespace AdventOfCode2017.Days;

public class Day4 : Day
{
    public override object Part1()
    {
        var lines = GetInput();

        return lines.Count(line =>
        {
            var split = line.Split(' ');
            return split.Distinct().Count() == split.Length;
        });
    }

    public override object Part2()
    {
        var lines = GetInput();

        return lines.Count(line => line.Split(' ').DoubleIteration().All(Validate));
    }

    private bool Validate((string, string) pair)
    {
        var (first, second) = pair;
        var f = first.ToCharArray();
        var s = second.ToCharArray();
        Array.Sort(f);
        Array.Sort(s);
        return string.Join(string.Empty, f) != string.Join(string.Empty, s);
    }
}