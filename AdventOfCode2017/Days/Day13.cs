using AdventOfCode2017.Models.Day13;

namespace AdventOfCode2017.Days;

public class Day13 : Day
{
    private readonly Dictionary<long, Layer> _layers;
    private readonly long _maxDepth;

    public Day13()
    {
        _layers = GetInput()
            .Select(Layer.Parse)
            .ToDictionary(layer => layer.Depth, layer => layer);
        _maxDepth = _layers.Keys.Max();
    }

    public override object Part1()
    {
        return GetTotalSeverity(0, out _);
    }

    public override object Part2()
    {
        var time = 0;
        while (true)
        {
            GetTotalSeverity(time, out var seen);

            if (!seen)
            {
                break;
            }

            time++;
        }

        return time;
    }

    private long GetTotalSeverity(int startTime, out bool seen)
    {
        var ans = 0L;
        seen = false;
        for (var time = 0; time <= _maxDepth; time++)
        {
            if (_layers.TryGetValue(time, out var layer) && layer.GetPos(time + startTime) == 0)
            {
                ans += layer.Severity;
                seen = true;
            }
        }

        return ans;
    }
}