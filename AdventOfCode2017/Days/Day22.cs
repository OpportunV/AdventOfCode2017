using Common.Extensions;
using Common.Helpers;
using Common.Models;

namespace AdventOfCode2017.Days;

public class Day22 : Day
{
    private readonly string[] _input;
    private readonly GridPos2d _start;
    private const char Clean = '.';
    private const char Flagged = 'F';
    private const char Infected = '#';
    private const int Part1Iterations = 10000;
    private const int Part2Iterations = 10000000;
    private const char Weakened = 'W';

    public Day22()
    {
        _input = GetInput();
        _start = new GridPos2d(_input.Length / 2, _input[0].Length / 2);
    }

    public override object Part1()
    {
        var curPos = _start;
        var curDirIndex = 3;

        var res = 0;
        var grid = GetGrid();

        for (var i = 0; i < Part1Iterations; i++)
        {
            var curVal = grid.GetValueOrDefault(curPos, Clean);
            curDirIndex = curVal == Infected
                ? (curDirIndex + 1).Mod(Directions2d.Side.Count)
                : (curDirIndex - 1).Mod(Directions2d.Side.Count);

            grid[curPos] = curVal == Infected ? Clean : Infected;

            if (curVal != Infected)
            {
                res++;
            }

            curPos += Directions2d.Side[curDirIndex];
        }

        return res;
    }

    public override object Part2()
    {
        var curPos = _start;
        var curDirIndex = 3;

        var res = 0;
        var grid = GetGrid();

        for (var i = 0; i < Part2Iterations; i++)
        {
            var curVal = grid.GetValueOrDefault(curPos, Clean);
            switch (curVal)
            {
                case Clean:
                    curDirIndex = (curDirIndex - 1).Mod(Directions2d.Side.Count);
                    grid[curPos] = Weakened;
                    break;
                case Weakened:
                    res++;
                    grid[curPos] = Infected;
                    break;
                case Infected:
                    curDirIndex = (curDirIndex + 1).Mod(Directions2d.Side.Count);
                    grid[curPos] = Flagged;
                    break;
                case Flagged:
                    curDirIndex = (curDirIndex + 2).Mod(Directions2d.Side.Count);
                    grid[curPos] = Clean;
                    break;
            }

            curPos += Directions2d.Side[curDirIndex];
        }

        return res;
    }

    private Dictionary<GridPos2d, char> GetGrid()
    {
        var grid = new Dictionary<GridPos2d, char>();
        for (var i = 0; i < _input.Length; i++)
        {
            for (var j = 0; j < _input[0].Length; j++)
            {
                grid[new GridPos2d(i, j)] = _input[i][j];
            }
        }

        return grid;
    }
}