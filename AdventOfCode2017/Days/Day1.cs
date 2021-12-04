using System.IO;
using AdventOfCode2017.Helpers;

namespace AdventOfCode2017.Days
{
    public static class Day1
    {
        private static readonly string _inputPath = Path.Combine("input",
            $"{System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.Name}.txt");
        
        public static object Part1()
        {
            var lines = Helper.GetInput(_inputPath)[0];
            
            var ans = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == lines[(i + 1) % lines.Length])
                {
                    ans += int.Parse(lines[i].ToString());
                }
            }

            return ans;
        }
        
        public static object Part2()
        {
            var lines = Helper.GetInput(_inputPath)[0];

            var length = lines.Length;
            var ans = 0;
            for (int i = 0; i < length; i++)
            {
                if (lines[i] == lines[(i + length / 2) % length])
                {
                    ans += int.Parse(lines[i].ToString());
                }
            }

            return ans;
        }
    }
}