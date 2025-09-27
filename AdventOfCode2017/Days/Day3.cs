using System.Reflection;
using AdventOfCode2017.Helpers;

namespace AdventOfCode2017.Days;

public class Day3
{
    private readonly string _inputPath = Path.Combine(
        "input",
        $"{MethodBase.GetCurrentMethod()!.DeclaringType!.Name}.txt");

    public object Part1()
    {
        var lines = Helper.GetInput(_inputPath);
        var target = int.Parse(lines[0]);

        var squareAbove = 0;

        while (squareAbove * squareAbove < target)
        {
            squareAbove += 2;
        }

        var sideLength = squareAbove - 1;
        var diff = squareAbove * squareAbove - target;
        diff %= sideLength;
        var dist = sideLength - diff;

        return dist;
    }

    public object Part2()
    {
        var lines = Helper.GetInput(_inputPath);
        var target = int.Parse(lines[0]);

        var grid = new Dictionary<(int, int), int> { { (0, 0), 1 }, { (1, 0), 1 } };

        var pos = (x: 1, y: 1);
        var last = 0;
        var direction = Direction.Up;
        while (last < target)
        {
            last = Helper.Adjacent(pos).Sum(adjPos => grid.GetOrDefault(adjPos, 0));
            grid[pos] = last;
            if (pos.x == pos.y && pos.x > 0)
            {
                direction = Direction.Left;
            }

            if (pos.x == -pos.y && pos.x < 0)
            {
                direction = Direction.Down;
            }

            if (pos.x == pos.y && pos.x < 0)
            {
                direction = Direction.Right;
            }

            if (pos.x - 1 == -pos.y && pos.x > 0)
            {
                direction = Direction.Up;
            }

            pos = pos.Add(Helper.Directions[(int)direction]);
        }

        return last;
    }
}