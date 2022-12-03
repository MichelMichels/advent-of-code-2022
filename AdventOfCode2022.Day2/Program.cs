using AdventOfCode2022.Day2;
using System.Diagnostics;

var sw = Stopwatch.StartNew();

Console.WriteLine("Advent of code 2022 - Day 2");
Console.WriteLine();

var inputFilePath = "input.txt";

var engine = new RockPaperScissorEngine(new RockPaperScissorParser());
Console.WriteLine($"Trying to read {inputFilePath}...");

var content = File.ReadAllText(inputFilePath);
Console.WriteLine($"{inputFilePath} file read.");

PlayPartOne(engine, content);

var outcomeEngine = new RockPaperScissorEngine(new OutcomeRockPaperScissorParser());
PlayPartTwo(outcomeEngine, content);

Console.WriteLine($"Solution found in {sw.ElapsedMilliseconds} ms");

sw = Stopwatch.StartNew();
PlayPartOneASAP();

Console.WriteLine($"ASAP Solution part one found in {sw.ElapsedMilliseconds} ms");

static void PlayPartOne(IRockPaperScissorEngine engine, string input)
{
    Console.WriteLine("Part One:");
    Console.WriteLine("=========");

    var score = engine.GetTotalScore(input);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"The total score is {score}.");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine();
}

static void PlayPartTwo(IRockPaperScissorEngine engine, string input)
{
    Console.WriteLine("Part Two:");
    Console.WriteLine("=========");

    var score = engine.GetTotalScore(input);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"The total score is {score}.");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine();
}

static void PlayPartOneASAP()
{
    var score = File.ReadLines("input.txt")
        .Select(s => (s[0], s[2]))
        .Sum(x =>
        {
            return (x.Item2 - 'X' + 1) +
                (x.Item1 == x.Item2 - 23 ? 3 : 0) +
                ((x.Item1 == 'A' && x.Item2 == 'Y') ? 6 : 0) +
                ((x.Item1 == 'B' && x.Item2 == 'Z') ? 6 : 0) +
                ((x.Item1 == 'C' && x.Item2 == 'X') ? 6 : 0);
        });

    Console.WriteLine(score);
}