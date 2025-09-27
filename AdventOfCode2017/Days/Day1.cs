using System.Reflection;
using AdventOfCode2017.Helpers;

namespace AdventOfCode2017.Days;

public class Day1
{
    private readonly string _inputPath = Path.Combine(
        "input",
        $"{MethodBase.GetCurrentMethod()!.DeclaringType!.Name}.txt");

    public object Part1()
    {
        var lines = Helper.GetInput(_inputPath)[0];

        var ans = 0;
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i] == lines[(i + 1) % lines.Length])
            {
                ans += int.Parse(lines[i].ToString());
            }
        }

        return ans;
    }

    public object Part2()
    {
        var lines = Helper.GetInput(_inputPath)[0];

        var length = lines.Length;
        var ans = 0;
        for (var i = 0; i < length; i++)
        {
            if (lines[i] == lines[(i + length / 2) % length])
            {
                ans += int.Parse(lines[i].ToString());
            }
        }

        return ans;
    }
}