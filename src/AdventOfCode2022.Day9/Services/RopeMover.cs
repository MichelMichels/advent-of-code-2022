using AdventOfCode2022.Day9.Enums;
using AdventOfCode2022.Day9.Models;

namespace AdventOfCode2022.Day9.Services;

public class RopeMover : IRopeMover
{
    public void Move(Rope rope, Motion motion)
    {

        for (int i = 0; i < motion.Steps; i++)
        {
            rope.Head = Move(rope.Head, motion.Direction);

            if (rope.IsHeadOnTail)
            {
                continue;
            }

            if (!rope.IsTailAroundHead())
            {
                bool isTailInSameRow = rope.Tail.Y == rope.Head.Y;
                bool isTailInSameColumn = rope.Tail.X == rope.Head.X;

                if (isTailInSameColumn || isTailInSameRow)
                {
                    rope.Tail = Move(rope.Tail, motion.Direction);
                }
            }
        }
    }

    private Position Move(Position position, Direction direction)
    {
        int x = position.X;
        int y = position.Y;

        int modifier = 1;

        switch (direction)
        {
            case Direction.Up:
                y = position.Y - modifier;
                break;
            case Direction.Down:
                y = position.Y + modifier;
                break;
            case Direction.Left:
                x = position.X - modifier;
                break;
            case Direction.Right:
                x = position.X + modifier;
                break;
        }

        return new Position(x, y);
    }
}
