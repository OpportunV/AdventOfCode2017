using System;
using System.IO;
using System.Linq;
using AdventOfCode2017.Helpers;

namespace AdventOfCode2017.Days
{
    public static class Day4
    {
        private static readonly string _inputPath = Path.Combine("input",
            $"{System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.Name}.txt");
        
        public static object Part1()
        {
            var lines = Helper.GetInput(_inputPath);

            return lines.Count(line =>
            {
                var split = line.Split(' ');
                return split.Distinct().Count() == split.Length;
            });
        }
        
        public static object Part2()
        {
            var lines = Helper.GetInput(_inputPath);

            return lines.Count(line => line.Split(' ').DoubleIteration().All(Validate));
        }
        
        private static bool Validate((string, string) pair)
        {
            var (first, second) = pair;
            var f = first.ToCharArray();
            var s = second.ToCharArray();
            Array.Sort(f);
            Array.Sort(s);
            return string.Join("", f) != string.Join("", s);
        }
    }
}

