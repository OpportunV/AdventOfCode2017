using System.Text;
using Common.Extensions;
using Common.Models;

namespace AdventOfCode2017.Days;

public class Day14 : Day
{
    private readonly Grid<char> _grid;
    private const int Amount = 128;
    private const int Used = '1';

    public Day14()
    {
        var key = GetInputRaw();
        _grid = new Grid<char>(
            Enumerable.Range(0, Amount)
                .Select(i => Day10
                    .DenseHashHex(Encoding.UTF8.GetBytes($"{key}-{i}").ToList())
                    .GetHexBits()
                    .ToArray())
                .ToArray());
    }

    public override object Part1()
    {
        return _grid
            .Flatten()
            .Count(item => item.Value == Used);
    }

    public override object Part2()
    {
        var seen = new HashSet<GridPos2d>();
        var res = 0;
        foreach (var gridItem in _grid.Flatten())
        {
            if (seen.Contains(gridItem.Pos))
            {
                continue;
            }

            if (gridItem.Value != Used)
            {
                continue;
            }

            res += 1;
            var toVisit = new Queue<GridPos2d>();
            toVisit.Enqueue(gridItem.Pos);
            while (toVisit.TryDequeue(out var cur))
            {
                foreach (var next in _grid.AdjacentSide(cur))
                {
                    if (next.Value != Used)
                    {
                        continue;
                    }

                    if (seen.Add(next.Pos))
                    {
                        toVisit.Enqueue(next.Pos);
                    }
                }
            }
        }

        return res;
    }
}