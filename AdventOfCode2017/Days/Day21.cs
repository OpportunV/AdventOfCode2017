using Common.Models;

namespace AdventOfCode2017.Days;

public class Day21 : Day
{
    private readonly Grid<char> _grid;
    private readonly Dictionary<string, Grid<char>> _mappings = new();
    private const string InitialField = ".#...####";
    private const string MappingsSeparator = "=>";
    private const int Part1Iterations = 5;
    private const int Part2Iterations = 18;
    private const char Pixel = '#';
    private const string RowsSeparator = "/";

    public Day21()
    {
        _grid = new Grid<char>(InitialField.Chunk(3).ToArray());
        var mappings = GetInput()
            .Select(line => line.Split(MappingsSeparator, StringSplitOptions.TrimEntries))
            .ToDictionary(
                line => new Grid<char>(line[0].Split(RowsSeparator).Select(s => s.ToCharArray()).ToArray()),
                line => new Grid<char>(line[1].Split(RowsSeparator).Select(s => s.ToCharArray()).ToArray()));

        foreach (var from in mappings.Keys.ToList())
        {
            var to = mappings[from];
            var cur = from;
            for (var i = 0; i < 4; i++)
            {
                cur = cur.RotateClockwise();
                mappings[cur] = to;
                mappings[cur.FlipVertically()] = to;
            }
        }

        foreach (var (from, to) in mappings)
        {
            _mappings[from.ToString()] = to;
        }
    }

    public override object Part1()
    {
        var grid = new Grid<char>(_grid);
        for (var i = 0; i < Part1Iterations; i++)
        {
            grid = UpdateGrid(grid);
        }

        return grid.Flatten().Count(item => item.Value == Pixel);
    }

    public override object Part2()
    {
        var grid = new Grid<char>(_grid);
        for (var i = 0; i < Part2Iterations; i++)
        {
            grid = UpdateGrid(grid);
        }

        return grid.Flatten().Count(item => item.Value == Pixel);
    }

    private Grid<char> UpdateGrid(Grid<char> grid)
    {
        var oldSize = grid.Rows % 2 == 0 ? 2 : 3;
        var newSize = grid.Rows % 2 == 0 ? 3 : 4;

        var newGrid = new Grid<char>(grid.Rows / oldSize * newSize, grid.Cols / oldSize * newSize, '.');
        for (var i = 0; i < grid.Rows; i += oldSize)
        {
            for (var j = 0; j < grid.Cols; j += oldSize)
            {
                var from = new Grid<char>(oldSize, oldSize, '.');
                for (var r = 0; r < from.Rows; r++)
                {
                    for (var c = 0; c < from.Cols; c++)
                    {
                        from[r, c] = grid[i + r, j + c];
                    }
                }

                var to = _mappings[from.ToString()];
                for (var r = 0; r < to.Rows; r++)
                {
                    for (var c = 0; c < to.Cols; c++)
                    {
                        newGrid[r + i / oldSize * newSize, c + j / oldSize * newSize] = to[r, c];
                    }
                }
            }
        }

        return newGrid;
    }
}