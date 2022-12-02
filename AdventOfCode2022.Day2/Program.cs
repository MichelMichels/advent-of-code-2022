
using AdventOfCode2022.Day2;

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