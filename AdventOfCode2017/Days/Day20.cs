using AdventOfCode2017.Models.Day20;

namespace AdventOfCode2017.Days;

public class Day20 : Day
{
    private const int Iterations = 1000;

    public override object Part1()
    {
        var particles = GetInput().Select(Particle.Parse).ToList();
        for (var i = 0; i < Iterations; i++)
        {
            particles = particles.Select(p => p.Update()).ToList();
        }

        return particles.MinBy(p => p.Distance())!.Id;
    }

    public override object Part2()
    {
        var particles = GetInput().Select(Particle.Parse).ToList();
        for (var i = 0; i < Iterations; i++)
        {
            particles = particles.Select(p => p.Update()).ToList();
            var grouped = particles.GroupBy(p => p.Position);
            particles = grouped.Where(grouping => grouping.Count() == 1).SelectMany(grouping => grouping).ToList();
        }

        return particles.Count;
    }
}