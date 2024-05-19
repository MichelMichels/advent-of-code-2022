using AdventOfCode2022.Day3;
using AdventOfCode2022.Shared;

string inputFilePath = "input.txt";
IConsoleWriter consoleWriter = new ConsoleWriter(ConsoleColor.Yellow);

consoleWriter.WriteLine("Advent of code 2022 - Day 3");
consoleWriter.WriteLine("===========================");
consoleWriter.WriteLine();

IStringIntersecter stringIntersecter = new StringIntersecter();
IPriorityCalculator priorityCalculator = new PriorityCalculator();
IRucksackFactory rucksackFactory = new RucksackFactory(stringIntersecter);
IStringSplitter stringSplitter = new NewLineSplitter();

var storageRoom = new ElfStorageRoom(
    priorityCalculator,
    rucksackFactory,
    stringIntersecter,
    stringSplitter);

var content = File.ReadAllText(inputFilePath);
consoleWriter.WriteLine($"Contents of {inputFilePath} read.");

PartOne(storageRoom, consoleWriter, content);
PartTwo(storageRoom, consoleWriter, content);

static void PartOne(IElfStorageRoom storageRoom, IConsoleWriter consoleWriter, string content)
{
    consoleWriter.WriteLine("Part one", ConsoleColor.Red);
    consoleWriter.WriteLine("--------", ConsoleColor.Red);

    var priorityScore = storageRoom.CalculatePriorityOfSingleRucksacks(content);

    consoleWriter.WriteLine($"The priority score is {priorityScore}.", ConsoleColor.Green);
    consoleWriter.WriteLine();
}
static void PartTwo(IElfStorageRoom storageRoom, IConsoleWriter consoleWriter, string content)
{
    consoleWriter.WriteLine("Part two", ConsoleColor.Red);
    consoleWriter.WriteLine("--------", ConsoleColor.Red);

    var result = storageRoom.CalculatePriorityOfThreeElfGroupRucksacks(content);

    consoleWriter.WriteLine($"The answer is {result}.", ConsoleColor.Green);
}