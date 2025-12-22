namespace AdventOfCode2017.Days;

public class Day23 : Day
{
    private readonly string[] _program;
    private const string AvailableRegs = "abcdefgh";

    public Day23()
    {
        _program = GetInput();
    }

    public override object Part1()
    {
        var cur = 0L;
        var res = 0;
        var regs = AvailableRegs.ToDictionary(reg => reg, _ => 0L);
        while (cur < _program.Length)
        {
            var split = _program[cur].Split();
            switch (split[0])
            {
                case "set":
                    var reg = split[1][0];
                    regs[reg] = GetValue(split[2], regs);
                    break;
                case "sub":
                    reg = split[1][0];
                    regs[reg] -= GetValue(split[2], regs);
                    break;
                case "mul":
                    reg = split[1][0];
                    regs[reg] *= GetValue(split[2], regs);
                    res++;
                    break;
                case "jnz":
                    var val1 = GetValue(split[1], regs);
                    if (val1 != 0)
                    {
                        cur += GetValue(split[2], regs);
                        continue;
                    }

                    break;
            }

            cur++;
        }

        return res;
    }


    public override object Part2()
    {
        var cur = 0L;
        var regs = AvailableRegs.ToDictionary(reg => reg, _ => 0L);
        regs['a'] = 1;
        while (cur < 11)
        {
            var split = _program[cur].Split();
            switch (split[0])
            {
                case "set":
                    var reg = split[1][0];
                    regs[reg] = GetValue(split[2], regs);
                    break;
                case "sub":
                    reg = split[1][0];
                    regs[reg] -= GetValue(split[2], regs);
                    break;
                case "mul":
                    reg = split[1][0];
                    regs[reg] *= GetValue(split[2], regs);
                    break;
                case "jnz":
                    var val1 = GetValue(split[1], regs);
                    if (val1 != 0)
                    {
                        cur += GetValue(split[2], regs);
                        continue;
                    }

                    break;
            }

            cur++;
        }

        var res = 0;
        for (var i = regs['b']; i <= regs['c']; i += 17)
        {
            if (Enumerable.Range(2, (int)Math.Sqrt(i)).Any(div => i % div == 0))
            {
                res++;
            }
        }

        return res;
    }

    private static long GetValue(string value, Dictionary<char, long> regs)
    {
        return regs.TryGetValue(value[0], out var reg) ? reg : long.Parse(value);
    }
}