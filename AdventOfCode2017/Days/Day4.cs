using System.Reflection;
using AdventOfCode2017.Helpers;

namespace AdventOfCode2017.Days;

public class Day4
{
    private readonly string _inputPath = Path.Combine(
        "input",
        $"{MethodBase.GetCurrentMethod()!.DeclaringType!.Name}.txt");

    public object Part1()
    {
        var lines = Helper.GetInput(_inputPath);

        return lines.Count(line =>
        {
            var split = line.Split(' ');
            return split.Distinct().Count() == split.Length;
        });
    }

    public object Part2()
    {
        var lines = Helper.GetInput(_inputPath);

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