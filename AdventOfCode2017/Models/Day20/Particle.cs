using Common.Extensions;
using Common.Models;

namespace AdventOfCode2017.Models.Day20;

public record Particle(Vector3<long> Position, Vector3<long> Velocity, Vector3<long> Acceleration, int Id)
{
    public static Particle Parse(string data, int id)
    {
        var nums = data.GetNumbers<long>();
        return new Particle(
            new Vector3<long>(nums[0], nums[1], nums[2]),
            new Vector3<long>(nums[3], nums[4], nums[5]),
            new Vector3<long>(nums[6], nums[7], nums[8]),
            id);
    }

    public Particle Update()
    {
        var velocity = Velocity + Acceleration;
        return this with { Velocity = velocity, Position = Position + velocity };
    }

    public long Distance()
    {
        return Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);
    }
}