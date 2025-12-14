namespace AdventOfCode2017.Days;

public abstract class Day
{
    private readonly string _inputPath;

    public Day()
    {
        _inputPath = Path.Combine("input", $"{GetType().Name}.txt");
    }

    public abstract object Part1();

    public abstract object Part2();

    protected string[] GetInput()
    {
        return File.ReadAllLines(_inputPath);
    }

    protected string GetInputRaw()
    {
        return File.ReadAllText(_inputPath);
    }
}