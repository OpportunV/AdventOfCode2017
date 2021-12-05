using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2017.Helpers;

namespace AdventOfCode2017.Days
{
    public static class Day2
    {
        private static readonly string _inputPath = Path.Combine("input",
            $"{System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.Name}.txt");
        
        public static object Part1()
        {
            var lines = Helper.GetInput(_inputPath);

            var ans = 0;
            foreach (var line in lines)
            {
                var matches = Regex.Matches(line, @"\d+");
                ans += matches.Cast<Match>().Select(m => int.Parse(m.Value)).Max() -
                       matches.Cast<Match>().Select(m => int.Parse(m.Value)).Min();
            }

            return ans;
        }
        
        public static object Part2()
        {
            var lines = Helper.GetInput(_inputPath);

            return lines.Select(line => Regex.Matches(line, @"\d+")).Select(GetDivisionResult).Sum();
        }

        private static int GetDivisionResult(MatchCollection matches)
        {
            foreach (var match in matches)
            {
                var val = int.Parse(match.ToString());
                foreach (var match1 in matches)
                {
                    var val1 = int.Parse(match1.ToString());
                    if (val == val1)
                    {
                        continue;
                    }
                    if (Math.Max(val, val1) % Math.Min(val, val1) == 0)
                    {
                        return Math.Max(val, val1) / Math.Min(val, val1);
                    }
                }
            }

            throw new EntryPointNotFoundException();
        }
    }
}