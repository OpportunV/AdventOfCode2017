using Common.Extensions;

namespace AdventOfCode2017.Days;

public class Day6 : Day
{
    public override object Part1()
    {
        var lines = GetInput();
        var banks = lines[0].GetNumbers<int>().ToList();

        var counter = GetCyclesAmount(ref banks);

        return counter;
    }

    public override object Part2()
    {
        var lines = GetInput();
        var banks = lines[0].GetNumbers<int>().ToList();

        GetCyclesAmount(ref banks);
        var counter = GetCyclesAmount(ref banks);

        return counter;
    }

    private int GetCyclesAmount(ref List<int> banks)
    {
        var seen = new HashSet<string>();
        var counter = 0;
        var n = banks.Count;
        while (!seen.Contains(string.Join(",", banks)))
        {
            seen.Add(string.Join(",", banks));
            counter++;
            var max = banks.Max();
            var index = banks.IndexOf(max);
            banks[index] = 0;
            for (var i = 1; i <= max; i++)
            {
                banks[(index + i) % n] += 1;
            }
        }

        return counter;
    }
}