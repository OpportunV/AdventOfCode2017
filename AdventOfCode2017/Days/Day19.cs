using Common.Models;

namespace AdventOfCode2017.Days;

public class Day19 : Day
{
    private readonly Grid<char> _grid;
    private readonly GridPos2d _start;
    private const int Cross = '+';
    private const int Empty = ' ';

    public Day19()
    {
        _grid = new Grid<char>(GetInput().Select(line => line.ToCharArray()).ToArray());
        _start = _grid.Flatten().First(item => item.Value != Empty).Pos;
    }

    public override object Part1()
    {
        return string.Join("", GetPath().Where(char.IsLetter));
    }

    public override object Part2()
    {
        return GetPath().Count;
    }

    private List<char> GetPath()
    {
        var cur = _start;
        var dir = _grid[cur + GridPos2d.Down] != Empty ? GridPos2d.Down : GridPos2d.Right;
        var path = new List<char>();

        while (_grid[cur] != Empty)
        {
            var chr = _grid[cur];
            path.Add(chr);

            if (chr == Cross)
            {
                if (dir == GridPos2d.Down || dir == GridPos2d.Up)
                {
                    dir = _grid[cur + GridPos2d.Right] != Empty ? GridPos2d.Right : GridPos2d.Left;
                }
                else
                {
                    dir = _grid[cur + GridPos2d.Up] != Empty ? GridPos2d.Up : GridPos2d.Down;
                }
            }

            cur += dir;
        }

        return path;
    }
}