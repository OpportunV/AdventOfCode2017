using System.Reflection;
using AdventOfCode2017.Helpers;

namespace AdventOfCode2017.Days;

public class Day5
{
    private readonly string _inputPath = Path.Combine(
        "input",
        $"{MethodBase.GetCurrentMethod()!.DeclaringType!.Name}.txt");

    public object Part1()
    {
        var lines = Helper.GetInput(_inputPath);
        var instructions = lines.Select(int.Parse).ToArray();
        var stepCounter = 0;
        var currentIndex = 0;
        while (currentIndex < instructions.Length && currentIndex >= 0)
        {
            stepCounter++;
            var currentInstruction = instructions[currentIndex];
            instructions[currentIndex]++;
            currentIndex += currentInstruction;
        }

        return stepCounter;
    }

    public object Part2()
    {
        var lines = Helper.GetInput(_inputPath);

        var instructions = lines.Select(int.Parse).ToArray();
        var stepCounter = 0;
        var currentIndex = 0;
        while (currentIndex < instructions.Length && currentIndex >= 0)
        {
            stepCounter++;
            var currentInstruction = instructions[currentIndex];
            if (currentInstruction >= 3)
            {
                instructions[currentIndex]--;
            }
            else
            {
                instructions[currentIndex]++;
            }

            currentIndex += currentInstruction;
        }

        return stepCounter;
    }
}