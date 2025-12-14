using Common.Extensions;

namespace AdventOfCode2017.Models.Day13;

public record Layer(long Depth, long Range)
{
    public long Severity => Depth * Range;

    public long GetPos(int time)
    {
        var (div, rem) = Math.DivRem(time, Range - 1);
        if (div % 2 == 0)
        {
            return rem;
        }

        return Range - rem - 1;
    }

    public static Layer Parse(string data)
    {
        var nums = data.GetNumbers<long>();
        return new Layer(nums[0], nums[1]);
    }
}