using Common.Extensions;

namespace AdventOfCode2017.Days;

public class Day16 : Day
{
    private readonly string[] _commands;
    private const char Exchange = 'x';
    private const int Part2Iterations = 1_000_000_000;
    private const char Partner = 'p';
    private const int ProgramsAmount = 16;
    private const char Spin = 's';
    private readonly List<char> _programs;

    public Day16()
    {
        _programs = Enumerable.Range(0, ProgramsAmount)
            .Select(i => (char)(i + 'a'))
            .ToList();
        _commands = GetInputRaw().Split(",");
    }

    public override object Part1()
    {
        DoDance();
        return string.Join("", _programs);
    }

    public override object Part2()
    {
        var seen = new List<string>();
        for (var i = 0; i < Part2Iterations; i++)
        {
            var cur = string.Join("", _programs);
            if (seen.Contains(cur))
            {
                return seen[Part2Iterations % seen.Count - 1];
            }

            seen.Add(cur);
            DoDance();
        }

        throw new Exception("No solution found");
    }

    private void DoDance()
    {
        foreach (var command in _commands)
        {
            var nums = command.GetNumbers<int>();
            switch (command[0])
            {
                case Spin:
                    _programs.Rotate(nums[0]);
                    break;
                case Exchange:
                    (_programs[nums[0]], _programs[nums[1]]) = (_programs[nums[1]], _programs[nums[0]]);
                    break;
                case Partner:
                    var index1 = _programs.IndexOf(command[1]);
                    var index2 = _programs.IndexOf(command[3]);
                    (_programs[index1], _programs[index2]) = (_programs[index2], _programs[index1]);
                    break;
            }
        }
    }
}