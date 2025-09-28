using Common.Models;

namespace AdventOfCode2017.Days;

public class Day11 : Day
{
    private readonly Dictionary<string, HexGridPos> _movements = new()
    {
        { "n", HexGridPos.Up },
        { "ne", HexGridPos.RightUp },
        { "se", HexGridPos.RightDown },
        { "s", HexGridPos.Down },
        { "sw", HexGridPos.LeftDown },
        { "nw", HexGridPos.LeftUp }
    };

    public override object Part1()
    {
        var movements = GetInput()[0].Split(",");

        var pos = movements.Aggregate(HexGridPos.Zero, (current, movement) => current + _movements[movement]);

        return pos.Length;
    }

    public override object Part2()
    {
        var movements = GetInput()[0].Split(",");

        var pos = HexGridPos.Zero;
        var res = int.MinValue;
        foreach (var movement in movements)
        {
            pos += _movements[movement];
            res = Math.Max(res, pos.Length);
        }

        return res;
    }
}