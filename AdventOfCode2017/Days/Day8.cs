namespace AdventOfCode2017.Days;

public class Day8 : Day
{
    private Dictionary<string, int> _registers = null!;

    public override object Part1()
    {
        return Solve(true);
    }

    public override object Part2()
    {
        return Solve(false);
    }

    private int Solve(bool part1)
    {
        _registers = new();
        var lines = GetInput();
        var max = int.MinValue;
        foreach (var line in lines)
        {
            var split = line.Split(" if ");
            var action = split[0];
            var condition = split[1];
            if (Evaluate(condition))
            {
                var actionSplit = action.Split();
                var register = actionSplit[0];
                var registerValue = _registers.GetValueOrDefault(register, 0);
                var targetValue = int.Parse(actionSplit[2]);
                var newVal = actionSplit[1] == "dec" ? registerValue - targetValue : registerValue + targetValue;
                _registers[register] = newVal;
                max = Math.Max(max, newVal);
            }
        }

        return part1 ? _registers.Values.Max() : max;
    }

    private bool Evaluate(string condition)
    {
        var split = condition.Split();
        var register = _registers.GetValueOrDefault(split[0], 0);
        var op = split[1];
        var value = int.Parse(split[2]);
        switch (op)
        {
            case "<":
                return register < value;
            case "<=":
                return register <= value;
            case "!=":
                return register != value;
            case "==":
                return register == value;
            case ">":
                return register > value;
            case ">=":
                return register >= value;
            default:
                Console.WriteLine($"Unknown operator {op}");
                return false;
        }
    }
}