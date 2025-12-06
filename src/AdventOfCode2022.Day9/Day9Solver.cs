using AdventOfCode2022.Day9.Enums;
using AdventOfCode2022.Day9.Models;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day9;

public class Day9Solver(IMessageWriter messageWriter, IInputParser inputParser) : BaseChallengeSolver(messageWriter, inputParser)
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

        base.SolvePartOne();
    }
}
