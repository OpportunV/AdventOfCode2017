using Common.Models;

namespace AdventOfCode2017.Days;

public class Day3 : Day
{
    public override object Part1()
    {
        var lines = GetInput();
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

    public override object Part2()
    {
        var lines = GetInput();
        var target = int.Parse(lines[0]);

        var grid = new Dictionary<GridPos2d, int> { { GridPos2d.Zero, 1 }, { GridPos2d.Down, 1 } };

        var pos = new GridPos2d(1, 1);
        var last = 0;
        var direction = GridPos2d.Right;
        while (last < target)
        {
            last = pos.AdjacentAll().Sum(adjPos => grid.GetValueOrDefault(adjPos, 0));
            grid[pos] = last;
            if (pos.Row == pos.Col && pos.Row > 0)
            {
                direction = GridPos2d.Up;
            }

            if (pos.Row == -pos.Col && pos.Row < 0)
            {
                direction = GridPos2d.Left;
            }

            if (pos.Row == pos.Col && pos.Row < 0)
            {
                direction = GridPos2d.Down;
            }

            if (pos.Row - 1 == -pos.Col && pos.Row > 0)
            {
                direction = GridPos2d.Right;
            }

            pos += direction;
        }

        return last;
    }
}