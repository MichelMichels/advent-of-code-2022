using AdventOfCode2022.Day4;
using AdventOfCode2022.Shared;

internal class Program
{
    private static IConsoleWriter consoleWriter;
    private static IStringSplitter stringSplitter;
    private static IInputParser inputParser;
    private static IElfPairParser elfPairParser;
    private static IDoubleAssignmentChecker doubleAssignmentChecker;
    private static IOverlapChecker overlapChecker;

    private static void Main(string[] args)
    {
        elfPairParser = new ElfPairParser();
        stringSplitter = new NewLineSplitter();
        inputParser = new InputParser(stringSplitter);
        doubleAssignmentChecker = new DoubleAssignmentChecker();
        overlapChecker = new OverlapChecker();

        consoleWriter = new ConsoleWriter(ConsoleColor.Yellow);
        consoleWriter.WriteLine("Advent of code 2022 - Day 4");
        consoleWriter.WriteLine("===========================");
        consoleWriter.WriteLine();

        var content = inputParser.ParseTextFile("input.txt");
        var elfPairs = content.Select(elfPairParser.Parse);

        SolvePartOne(elfPairs);
        SolvePartTwo(elfPairs);
    }

    static void SolvePartOne(IEnumerable<ElfPair> elfPairs)
    {
        consoleWriter.WriteLine("Part 1");
        consoleWriter.WriteLine("------");

        var count = elfPairs.Where(doubleAssignmentChecker.IsDoubleAssigned).Count();

        consoleWriter.WriteLine($"The amount of double assigned pairs is {count}.", ConsoleColor.Green);
    }

    static void SolvePartTwo(IEnumerable<ElfPair> elfPairs)
    {
        consoleWriter.WriteLine("Part 2");
        consoleWriter.WriteLine("------");

        var count = elfPairs.Where(overlapChecker.IsOverlapping).Count();

        consoleWriter.WriteLine($"The amount of overlapping pairs is {count}.", ConsoleColor.Green);
    }
}