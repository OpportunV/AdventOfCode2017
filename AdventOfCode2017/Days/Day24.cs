using Common.Extensions;

namespace AdventOfCode2017.Days;

public class Day24 : Day
{
    private readonly Dictionary<int, List<(int, int)>> _ports = new();

    public Day24()
    {
        var ports = GetInput().Select(line => line.GetNumbers<int>());
        foreach (var port in ports)
        {
            _ports.TryAdd(port[0], []);
            _ports.TryAdd(port[1], []);
            _ports[port[0]].Add((port[0], port[1]));
            _ports[port[1]].Add((port[0], port[1]));
        }
    }

    public override object Part1()
    {
        return _ports[0].Select(port => GetStrength(port, [])).Max();
    }

    public override object Part2()
    {
        return _ports[0]
            .Select(port => GetStrengthWithLength(port, []))
            .OrderByDescending(pair => pair.length)
            .ThenByDescending(pair => pair.strength)
            .First().strength;
    }

    private long GetStrength((int, int) cur, HashSet<(int, int)> seen)
    {
        seen.Add(cur);
        seen.Add((cur.Item2, cur.Item1));

        var res = 0L;
        foreach (var (next1, next2) in _ports[cur.Item2])
        {
            if (seen.Contains((next1, next2)) || seen.Contains((next2, next1)))
            {
                continue;
            }

            seen.Add((next1, next2));
            seen.Add((next2, next1));

            var next = next1 == cur.Item2 ? (next1, next2) : (next2, next1);
            res = Math.Max(GetStrength(next, seen), res);
            seen.Remove((next1, next2));
            seen.Remove((next2, next1));
        }

        return res + cur.Item1 + cur.Item2;
    }

    private (long strength, int length) GetStrengthWithLength((int, int) cur, HashSet<(int, int)> seen)
    {
        seen.Add(cur);
        seen.Add((cur.Item2, cur.Item1));

        var bridges = new List<(long, int)>();
        foreach (var (next1, next2) in _ports[cur.Item2])
        {
            if (seen.Contains((next1, next2)) || seen.Contains((next2, next1)))
            {
                continue;
            }

            seen.Add((next1, next2));
            seen.Add((next2, next1));

            var next = next1 == cur.Item2 ? (next1, next2) : (next2, next1);
            var bridge = GetStrengthWithLength(next, seen);
            bridges.Add(bridge);

            seen.Remove((next1, next2));
            seen.Remove((next2, next1));
        }

        if (bridges.Count == 0)
        {
            return (cur.Item1 + cur.Item2, 1);
        }

        var target = bridges
            .OrderByDescending(bridge => bridge.Item2)
            .ThenByDescending(bridge => bridge.Item1)
            .First();
        return (cur.Item1 + cur.Item2 + target.Item1, target.Item2 + 1);
    }
}