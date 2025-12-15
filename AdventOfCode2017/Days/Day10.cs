using Common.Extensions;

namespace AdventOfCode2017.Days;

public class Day10 : Day
{
    private static readonly List<byte> _extraLengths = [17, 31, 73, 47, 23];
    private const int ChunkSize = 16;
    private const int ListSize = 256;
    private const int RoundAmount = 64;

    public override object Part1()
    {
        var lengths = GetInput()[0].GetNumbers<byte>();
        var list = Enumerable.Range(0, ListSize).Select(i => (byte)i).ToList();
        var pos = 0;
        var skip = 0;

        DoRound(list, lengths, ref pos, ref skip);

        return list[0] * list[1];
    }

    public override object Part2()
    {
        var lengths = GetInput()[0].Select(chr => (byte)chr).ToList();
        
        return DenseHashHex(lengths);
    }

    public static string DenseHashHex(List<byte> data)
    {
        data.AddRange(_extraLengths);
        var list = Enumerable.Range(0, ListSize).Select(i => (byte)i).ToList();

        var pos = 0;
        var skip = 0;

        for (var i = 0; i < RoundAmount; i++)
        {
            DoRound(list, data, ref pos, ref skip);
        }

        return GetDenseHashHex(list);
    }

    private static string GetDenseHashHex(List<byte> list)
    {
        var denseHash = GetDenseHash(list);
        return Convert.ToHexStringLower(denseHash);
    }

    private static byte[] GetDenseHash(List<byte> list)
    {
        var denseHash = list
            .Chunk(ChunkSize)
            .Select(chunk => chunk.Aggregate((acc, val) => (byte) (acc ^ val)))
            .ToArray();

        return denseHash;
    }

    private static void DoRound(List<byte> list, List<byte> lengths, ref int pos, ref int skip)
    {
        foreach (var length in lengths)
        {
            ReverseFragment(list, pos, pos + length - 1);
            pos += length + skip;
            skip += 1;
            pos = pos.Mod(list.Count);
            skip = skip.Mod(list.Count);
        }
    }

    private static void ReverseFragment(List<byte> list, int start, int end)
    {
        var length = list.Count;
        while (start < end)
        {
            (list[start.Mod(length)], list[end.Mod(length)]) = (list[end.Mod(length)], list[start.Mod(length)]);
            start++;
            end--;
        }
    }
}