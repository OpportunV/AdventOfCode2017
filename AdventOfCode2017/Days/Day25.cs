using Common.Extensions;
using ActionResult = (int write, int dir, char nextState);

namespace AdventOfCode2017.Days;

public class Day25 : Day
{
    private readonly Dictionary<char, Dictionary<int, ActionResult>> _instructions;
    private readonly char _startState;
    private readonly long _steps;
    private const string Right = "right";

    public Day25()
    {
        var sections = GetInputRaw().GetSections();
        _startState = sections[0][0][^2];
        _steps = sections[0][1].GetNumbers<long>()[0];

        _instructions = sections[1..]
            .ToDictionary(
                section => section[0][^2],
                section => new Dictionary<int, ActionResult>
                {
                    { int.Parse(section[1][^2].ToString()), GetActionResult(section[2..6]) },
                    { int.Parse(section[5][^2].ToString()), GetActionResult(section[6..]) }
                });
    }

    public override object Part1()
    {
        var tape = new Dictionary<int, int>();
        var cur = _startState;
        var pos = 0;

        for (var i = 0; i < _steps; i++)
        {
            var state = _instructions[cur];
            var val = tape.GetValueOrDefault(pos, 0);
            var instr = state[val];
            tape[pos] = instr.write;
            pos += instr.dir;
            cur = instr.nextState;
        }

        return tape.Values.Sum();
    }

    public override object Part2()
    {
        return "*";
    }

    private static ActionResult GetActionResult(string[] section)
    {
        return (int.Parse(section[0][^2].ToString()),
            section[1].Split()[^1].Contains(Right) ? 1 : -1,
            section[2][^2]);
    }
}