using Common.Extensions;

namespace AdventOfCode2017.Days;

public class Day12 : Day
{
    private readonly Dictionary<int, HashSet<int>> _graph;
    private const int Start = 0;

    public Day12()
    {
        _graph = GetInput()
            .Select(line => line.GetNumbers<int>())
            .ToDictionary(
                numbers => numbers[0],
                numbers => numbers[1..].ToHashSet());
    }

    public override object Part1()
    {
        return GetGroup(Start).Count;
    }

    public override object Part2()
    {
        var all = _graph.Keys.ToHashSet();
        var counter = 0;
        while (all.Count > 0)
        {
            counter++;
            var cur = all.First();
            var group = GetGroup(cur);
            all.ExceptWith(group);
        }

        return counter;
    }

    private HashSet<int> GetGroup(int start)
    {
        var toVisit = new Queue<int>();
        var seen = new HashSet<int>();
        toVisit.Enqueue(start);

        while (toVisit.TryDequeue(out var cur))
        {
            foreach (var next in _graph[cur])
            {
                if (seen.Add(next))
                {
                    toVisit.Enqueue(next);
                }
            }
        }

        return seen;
    }
}