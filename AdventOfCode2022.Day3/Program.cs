using AdventOfCode2022.Day3;

WriteToConsole("Advent of code 2022 - Day 3");
WriteToConsole();

IStringIntersecter stringIntersecter = new StringIntersecter();
IPriorityCalculator priorityCalculator = new PriorityCalculator();
IRucksackFactory rucksackFactory = new RucksackFactory(stringIntersecter);
IStringSplitter stringSplitter = new NewLineSplitter();

var storageRoom = new ElfStorageRoom(
    priorityCalculator,
    rucksackFactory,
    stringIntersecter,
    stringSplitter);

var content = File.ReadAllText("input.txt");

PartOne(storageRoom, content);
PartTwo(storageRoom, content);

static void PartOne(IElfStorageRoom storageRoom, string content)
{
    WriteToConsole("Part one", ConsoleColor.Red);
    WriteToConsole("========", ConsoleColor.Red);

    var priorityScore = storageRoom.CalculatePriorityOfSingleRucksacks(content);

    WriteToConsole($"The priority score is {priorityScore}.", ConsoleColor.Green);
    WriteToConsole();
}
static void PartTwo(IElfStorageRoom storageRoom, string content)
{
    WriteToConsole("Part two", ConsoleColor.Red);
    WriteToConsole("========", ConsoleColor.Red);

    var result = storageRoom.CalculatePriorityOfThreeElfGroupRucksacks(content);

    WriteToConsole($"The answer is {result}.", ConsoleColor.Green);
}

static void WriteToConsole(string content = "", ConsoleColor foregroundColor = ConsoleColor.White)
{
    Console.ForegroundColor = foregroundColor;
    Console.WriteLine(content);
    Console.ForegroundColor = ConsoleColor.White;
}