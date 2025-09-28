using Common.Extensions;

namespace AdventOfCode2017.Days;

public class Day5 : Day
{
    public override object Part1()
    {
        var lines = GetInput();
        var instructions = lines.Select(line => line.GetNumbers<int>()[0]).ToArray();
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

    public override object Part2()
    {
        var lines = GetInput();

        var instructions = lines.Select(line => line.GetNumbers<int>()[0]).ToArray();
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