using AdventOfCode2022.Day9.Enums;
using AdventOfCode2022.Day9.Models;
using AdventOfCode2022.Day9.Services;

namespace AdventOfCode2022.Day9Tests;

[TestClass]
public sealed class RopeMoverTests
{
    [TestMethod]
    public void MoveRope_Right_Test()
    {
        // Arrange
        RopeMover ropeMover = new();
        Rope rope = new();
        Motion motion = new()
        {
            Direction = Direction.Right,
            Steps = 1,
        };
        Position expectedHeadEndPosition = new(1, 0);
        Position expectedTailEndPosition = new(0, 0);

        // Act
        ropeMover.Move(rope, motion);

        // Assert

        Assert.AreEqual(expectedHeadEndPosition, rope.Head);
        Assert.AreEqual(expectedTailEndPosition, rope.Tail);
    }

    [TestMethod]
    public void MoveRope_Left_Test()
    {
        // Arrange
        RopeMover ropeMover = new();
        Rope rope = new()
        {
            Head = new(1, 1),
            Tail = new(1, 1),
        };
        Motion motion = new()
        {
            Direction = Direction.Left,
            Steps = 1,
        };
        Position expectedHeadEndPosition = new(0, 1);
        Position expectedTailEndPosition = new(1, 1);

        // Act
        ropeMover.Move(rope, motion);

        // Assert
        Assert.AreEqual(expectedHeadEndPosition, rope.Head);
        Assert.AreEqual(expectedTailEndPosition, rope.Tail);
    }

    [TestMethod]
    public void MoveRope_Up_Test()
    {
        // Arrange
        RopeMover ropeMover = new();
        Rope rope = new()
        {
            Head = new(1, 1),
            Tail = new(1, 1),
        };
        Motion motion = new()
        {
            Direction = Direction.Up,
            Steps = 1,
        };
        Position expectedHeadEndPosition = new(1, 0);
        Position expectedTailEndPosition = new(1, 1);

        // Act
        ropeMover.Move(rope, motion);

        // Assert
        Assert.AreEqual(expectedHeadEndPosition, rope.Head);
        Assert.AreEqual(expectedTailEndPosition, rope.Tail);
    }

    [TestMethod]
    public void MoveRope_Down_Test()
    {
        // Arrange
        RopeMover ropeMover = new();
        Rope rope = new()
        {
            Head = new(1, 1),
            Tail = new(1, 1),
        };
        Motion motion = new()
        {
            Direction = Direction.Down,
            Steps = 1,
        };
        Position expectedHeadEndPosition = new(1, 2);
        Position expectedTailEndPosition = new(1, 1);

        // Act
        ropeMover.Move(rope, motion);

        // Assert
        Assert.AreEqual(expectedHeadEndPosition, rope.Head);
        Assert.AreEqual(expectedTailEndPosition, rope.Tail);
    }

    [TestMethod]
    public void MoveRope_Down_Diagonal_Test()
    {
        // Arrange
        RopeMover ropeMover = new();
        Rope rope = new()
        {
            Head = new(1, 1),
            Tail = new(0, 0),
        };
        Motion motion = new()
        {
            Direction = Direction.Down,
            Steps = 1,
        };
        Position expectedHeadEndPosition = new(1, 2);
        Position expectedTailEndPosition = new(1, 1);

        // Act
        HashSet<Position> tailPositions = ropeMover.Move(rope, motion);

        // Assert
        Assert.AreEqual(expectedHeadEndPosition, rope.Head);
        Assert.AreEqual(expectedTailEndPosition, rope.Tail);
        Assert.HasCount(2, tailPositions);
    }

    [TestMethod]
    [DataRow(1, 1, Direction.Down, 1, 1, 2, 1, 1)]
    [DataRow(1, 1, Direction.Down, 3, 1, 4, 1, 3)]
    [DataRow(1, 1, Direction.Up, 1, 1, 0, 1, 1)]
    [DataRow(1, 1, Direction.Left, 1, 0, 1, 1, 1)]
    [DataRow(1, 1, Direction.Right, 1, 2, 1, 1, 1)]
    public void MoveRope_Test(int startX, int startY, Direction direction, int steps, int expHeadX, int expHeadY, int expTailX, int expTailY)
    {
        // Arrange
        RopeMover ropeMover = new();
        Rope rope = new()
        {
            Head = new(startX, startY),
            Tail = new(startX, startY),
        };
        Motion motion = new()
        {
            Direction = direction,
            Steps = steps,
        };
        Position expectedHeadEndPosition = new(expHeadX, expHeadY);
        Position expectedTailEndPosition = new(expTailX, expTailY);

        // Act
        ropeMover.Move(rope, motion);

        // Assert
        Assert.AreEqual(expectedHeadEndPosition, rope.Head);
        Assert.AreEqual(expectedTailEndPosition, rope.Tail);
    }
}
