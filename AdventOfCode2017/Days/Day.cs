namespace AdventOfCode2017.Days;

public abstract class Day
{
    public abstract object Part1();

    public abstract object Part2();

    protected string[] GetInput()
    {
        var path = Path.Combine("input", $"{GetType().Name}.txt");
        var tmp = File.ReadLines(Path.Combine(path));
        return tmp as string[] ?? tmp.ToArray();
    }
}