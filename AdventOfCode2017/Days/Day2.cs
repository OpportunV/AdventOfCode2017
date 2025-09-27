using System.Text.RegularExpressions;

namespace AdventOfCode2017.Days;

public class Day2 : Day
{
    public override object Part1()
    {
        var lines = GetInput();

        var ans = 0;
        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, @"\d+");
            ans += matches.Select(m => int.Parse(m.Value)).Max() -
                   matches.Select(m => int.Parse(m.Value)).Min();
        }

        return ans;
    }

    public override object Part2()
    {
        var lines = GetInput();

        return lines.Select(line => Regex.Matches(line, @"\d+")).Select(GetDivisionResult).Sum();
    }

    private int GetDivisionResult(MatchCollection matches)
    {
        foreach (var match in matches)
        {
            var val = int.Parse(match.ToString()!);
            foreach (var match1 in matches)
            {
                var val1 = int.Parse(match1.ToString()!);
                if (val == val1)
                {
                    continue;
                }

                if (Math.Max(val, val1) % Math.Min(val, val1) == 0)
                {
                    return Math.Max(val, val1) / Math.Min(val, val1);
                }
            }
        }

        throw new ArithmeticException();
    }
}