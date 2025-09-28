namespace AdventOfCode2017.Days;

public class Day9 : Day
{
    public override object Part1()
    {
        var line = GetInput()[0];
        var total = 0;
        var cancelNext = false;
        var garbageZone = false;
        var stack = new Stack<char>();
        foreach (var chr in line)
        {
            if (cancelNext)
            {
                cancelNext = false;
                continue;
            }

            switch (chr)
            {
                case '!':
                    cancelNext = true;
                    break;
                case '<' when !garbageZone:
                    garbageZone = true;
                    break;
                case '>' when garbageZone:
                    garbageZone = false;
                    break;
                case '{' when !garbageZone:
                    stack.Push(chr);
                    break;
                case '}' when !garbageZone:
                    total += stack.Count;
                    stack.Pop();
                    break;
            }
        }

        return total;
    }

    public override object Part2()
    {
        var line = GetInput()[0];
        var total = 0;
        var cancelNext = false;
        var garbageZone = false;
        foreach (var chr in line)
        {
            if (cancelNext)
            {
                cancelNext = false;
                continue;
            }

            switch (chr)
            {
                case '!':
                    cancelNext = true;
                    break;
                case '<' when !garbageZone:
                    garbageZone = true;
                    break;
                case '>' when garbageZone:
                    garbageZone = false;
                    break;
                default:
                    if (garbageZone)
                    {
                        total += 1;
                    }

                    break;
            }
        }

        return total;
    }
}