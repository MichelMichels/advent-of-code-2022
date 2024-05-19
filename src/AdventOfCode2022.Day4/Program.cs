using AdventOfCode2022.Day4;
using AdventOfCode2022.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

string inputFilePath = "input.txt";

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) => 
        services
            .AddSingleton<IConsoleWriter>(services => new ConsoleWriter(ConsoleColor.Yellow))
            .AddSingleton<IStringSplitter, NewLineSplitter>()
            .AddSingleton<IInputParser, InputParser>()
            .AddSingleton<IElfPairParser, ElfPairParser>()
            .AddSingleton<IDoubleAssignmentChecker, DoubleAssignmentChecker>()
            .AddSingleton<IOverlapChecker, OverlapChecker>())    
    .Build();

SolveChallenges(inputFilePath, host.Services);

await host.RunAsync();

static void SolveChallenges(string inputFilePath, IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    IConsoleWriter consoleWriter = provider.GetRequiredService<IConsoleWriter>();
    IInputParser inputParser = provider.GetRequiredService<IInputParser>();
    IElfPairParser elfPairParser = provider.GetRequiredService<IElfPairParser>();

    PrintWelcomeBanner(consoleWriter);
    
    var content = inputParser.ParseTextFile(inputFilePath);
    var elfPairs = content.Select(elfPairParser.Parse);

    SolvePartOne(elfPairs, consoleWriter, provider.GetRequiredService<IDoubleAssignmentChecker>());
    SolvePartTwo(elfPairs, consoleWriter, provider.GetRequiredService<IOverlapChecker>());
}
static void SolvePartOne(IEnumerable<ElfPair> elfPairs, IConsoleWriter consoleWriter, IDoubleAssignmentChecker doubleAssignmentChecker)
{
    PrintPartBanner(consoleWriter, 1);

    var count = elfPairs
        .Where(doubleAssignmentChecker.IsDoubleAssigned)
        .Count();

    PrintAnswer(consoleWriter, $"The amount of double assigned pairs is {count}.");
}
static void SolvePartTwo(IEnumerable<ElfPair> elfPairs, IConsoleWriter consoleWriter, IOverlapChecker overlapChecker)
{
    PrintPartBanner(consoleWriter, 2);

    var count = elfPairs
        .Where(overlapChecker.IsOverlapping)
        .Count();

    PrintAnswer(consoleWriter, $"The amount of overlapping pairs is {count}.");
}

static void PrintWelcomeBanner(IConsoleWriter consoleWriter)
{
    consoleWriter.WriteLine("Advent of code 2022 - Day 4");
    consoleWriter.WriteLine("===========================");
    consoleWriter.WriteLine();
}
static void PrintPartBanner(IConsoleWriter consoleWriter, int index)
{
    consoleWriter.WriteLine($"Part {index}");
    consoleWriter.WriteLine($"------");
}
static void PrintAnswer(IConsoleWriter consoleWriter,  string answer)
{
    consoleWriter.WriteLine(answer, ConsoleColor.Green);
    consoleWriter.WriteLine();
}