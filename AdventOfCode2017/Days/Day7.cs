using Common.Extensions;

namespace AdventOfCode2017.Days;

public class Day7 : Day
{
    private string _root = null!;
    private readonly Dictionary<string, List<string>> _progChildren = new();
    private readonly Dictionary<string, int> _progWeight = new();

    public override object Part1()
    {
        var lines = GetInput();
        var supported = new HashSet<string>();
        var all = new HashSet<string>();
        foreach (var line in lines)
        {
            var programs = line.GetWords();
            all.Add(programs[0]);
            if (programs.Count > 2)
            {
                supported.UnionWith(programs[2..]);
            }
        }

        all.ExceptWith(supported);
        _root = all.First();

        return _root;
    }

    public override object Part2()
    {
        var lines = GetInput();

        foreach (var line in lines)
        {
            var programs = line.GetWords();
            _progWeight[programs[0]] = int.Parse(programs[1]);
            if (programs.Count > 2)
            {
                _progChildren[programs[0]] = programs[2..];
            }
        }

        var candidate = _root;
        var previousTargetWeight = 0;

        while (_progChildren.TryGetValue(candidate, out var children))
        {
            var weights = children.Select(GetTotalWeight).ToList();

            var unique = weights
                .GroupBy(weight => weight)
                .FirstOrDefault(group => group.Count() == 1);

            if (unique != null)
            {
                candidate = children[weights.IndexOf(unique.Key)];
                previousTargetWeight = weights.First(weight => weight != unique.Key);
            }
            else
            {
                previousTargetWeight -= weights.Sum();
                break;
            }
        }

        return previousTargetWeight;
    }

    private int GetTotalWeight(string prog)
    {
        var total = 0;
        var toVisit = new Queue<string>();
        toVisit.Enqueue(prog);
        while (toVisit.TryDequeue(out var cur))
        {
            total += _progWeight[cur];
            if (_progChildren.TryGetValue(cur, out var children))
            {
                foreach (var child in children)
                {
                    toVisit.Enqueue(child);
                }
            }
        }

        return total;
    }
}