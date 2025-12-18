using Common.Extensions;

namespace AdventOfCode2017.Days;

public class Day18 : Day
{
    private readonly string[] _program;

    public Day18()
    {
        _program = GetInput();
    }

    public override object Part1()
    {
        return new Program(_program).RunProgram().Last();
    }

    public override object Part2()
    {
        var p0 = new Program(_program, 0);
        var p1 = new Program(_program, 1);
        var res = 0;
        do
        {
            foreach (var val0 in p0.RunProgram())
            {
                p1.Send(val0);
            }

            foreach (var val1 in p1.RunProgram())
            {
                res++;
                p0.Send(val1);
            }
        } while (p0.Ready || p1.Ready);

        return res;
    }
}

public class Program(string[] program)
{
    public bool Ready => _queue.Count > 0;

    private readonly Queue<long> _queue = new();

    private readonly Dictionary<char, long> _regs = new();
    private const char IdReg = 'p';
    private long _cur;

    public Program(string[] program, long id) : this(program)
    {
        _regs[IdReg] = id;
    }

    public void Send(long value)
    {
        _queue.Enqueue(value);
    }

    public IEnumerable<long> RunProgram()
    {
        while (_cur < program.Length)
        {
            var split = program[_cur].Split();
            switch (split[0])
            {
                case "snd":
                    yield return GetValue(split[1]);
                    break;
                case "set":
                    var reg = split[1][0];
                    _regs[reg] = GetValue(split[2]);
                    break;
                case "add":
                    reg = split[1][0];
                    _regs.TryAdd(reg, 0);
                    _regs[reg] += GetValue(split[2]);
                    break;
                case "mul":
                    reg = split[1][0];
                    _regs.TryAdd(reg, 0);
                    _regs[reg] *= GetValue(split[2]);
                    break;
                case "mod":
                    reg = split[1][0];
                    _regs.TryAdd(reg, 0);
                    _regs[reg] = _regs[reg].Mod(GetValue(split[2]));
                    break;
                case "rcv":
                    if (!_queue.TryDequeue(out var next))
                    {
                        yield break;
                    }

                    _regs[split[1][0]] = next;

                    break;
                case "jgz":
                    var val1 = GetValue(split[1]);
                    var val = GetValue(split[2]);
                    if (val1 > 0)
                    {
                        _cur += val;
                        continue;
                    }

                    break;
            }

            _cur++;
        }
    }

    private long GetValue(string value)
    {
        return _regs.TryGetValue(value[0], out var reg) ? reg : long.Parse(value);
    }
}