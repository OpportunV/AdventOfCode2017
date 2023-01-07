using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2017.Helpers;


namespace AdventOfCode2017.Days
{
    public static class Day6
    {
        private static readonly string _inputPath =
            Path.Combine("input", $"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.Name}.txt");

        public static object Part1()
        {
            var lines = Helper.GetInput(_inputPath);
            var banks = lines[0].Split().Select(int.Parse).ToList();

            var counter = GetCyclesAmount(ref banks);

            return counter;
        }

        public static object Part2()
        {
            var lines = Helper.GetInput(_inputPath);
            var banks = lines[0].Split().Select(int.Parse).ToList();

            GetCyclesAmount(ref banks);
            var counter = GetCyclesAmount(ref banks);

            return counter;
        }

        private static int GetCyclesAmount(ref List<int> banks)
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
                for (int i = 1; i <= max; i++)
                {
                    banks[(index + i) % n] += 1;
                }
            }

            return counter;
        }
    }
}