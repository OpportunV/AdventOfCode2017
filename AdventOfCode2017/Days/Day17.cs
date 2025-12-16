namespace AdventOfCode2017.Days;

public class Day17 : Day
{
    private readonly int _steps;
    private const int Part1Amount = 2017;
    private const int Part2Amount = 50_000_000;

    public Day17()
    {
        _steps = int.Parse(GetInputRaw());
    }

    public override object Part1()
    {
        var vals = new List<int>(Part1Amount + 1) { 0 };
        var target = 0;
        for (var i = 1; i <= Part1Amount; i++)
        {
            var next = (_steps + target) % vals.Count + 1;
            vals.Insert(next, i);
            target = next;
        }

        return vals[target + 1];
    }

    public override object Part2()
    {
        var len = 1;
        var target = 0;
        var res = 0;
        for (var i = 1; i <= Part2Amount; i++)
        {
            var next = (_steps + target) % len + 1;
            if (next == 1)
            {
                res = i;
            }

            target = next;
            len++;
        }

        return res;
    }
}