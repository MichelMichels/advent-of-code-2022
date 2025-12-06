using AdventOfCode2022.Day9.Enums;
using AdventOfCode2022.Day9.Models;
using AdventOfCode2022.Day9.Services;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day9;

public class Day9Solver(
    IMessageWriter messageWriter,
    IInputParser inputParser,
    IRopeMover ropeMover) : BaseChallengeSolver(messageWriter, inputParser)
{
    public override int DayNumber => 9;

    protected override void SolvePartOne()
    {
        List<Motion> motions = [];

        foreach (string line in parsed)
        {
            string[] parts = line.Split(' ');

            motions.Add(new Motion()
            {
                Direction = parts[0] switch
                {
                    "R" => Direction.Right,
                    "L" => Direction.Left,
                    "U" => Direction.Up,
                    "D" => Direction.Down,
                    _ => throw new NotSupportedException(),
                },
                Steps = int.Parse(parts[1])
            });
        }

        messageWriter.WriteMessage($"Motions parsed: {motions.Count}");

        HashSet<Position> tailPositions = [];
        Rope rope = new()
        {
            Head = new(100, 100),
            Tail = new(100, 100),
        };
        foreach (Motion motion in motions)
        {
            HashSet<Position> positions = ropeMover.Move(rope, motion);
            foreach (Position position in positions)
            {
                tailPositions.Add(position);
            }
        }

        messageWriter.WriteAnswer($"Tail positions visited: {tailPositions.Count}");

        base.SolvePartOne();
    }
}
