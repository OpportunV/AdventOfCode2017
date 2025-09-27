namespace AdventOfCode2017.Days;

public class Day1 : Day
{
    public override object Part1()
    {
        var lines = GetInput()[0];

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

    public override object Part2()
    {
        var lines = GetInput()[0];

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