namespace AdventOfCode2022.Day9.Models;

public class Rope
{
    public Position Head { get; set; }
    public Position Tail { get; set; }

    public bool IsHeadOnTail => Head == Tail;

    public bool IsTailAroundHead()
    {
        return Math.Abs(Head.X - Tail.X) <= 1 && Math.Abs(Head.Y - Tail.Y) <= 1;
    }
}
