using AdventOfCode2022.Day5;
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
            .AddSingleton<IInterpreter<RearrangementProcedure[]>, RearrangementProcedureInterpreter>()
            .AddSingleton<IInterpreter<CrateStack[]>, CrateStackInterpreter>()
            .AddSingleton<IInterpreter<Instruction>, InstructionInterpreter>()
            .AddSingleton<ICrateMover9000, CrateMover9000>()
            .AddSingleton<ICrateMover9001, CrateMover9001>())            
    .Build();

SolveChallenges(inputFilePath, host.Services);

await host.RunAsync();

static void SolveChallenges(string inputFilePath, IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    IConsoleWriter consoleWriter = provider.GetRequiredService<IConsoleWriter>();
    IInputParser inputParser = provider.GetRequiredService<IInputParser>();

    PrintWelcomeBanner(consoleWriter);

    var content = inputParser.ParseTextFile(inputFilePath);

    SolvePartOne(content, provider);
    SolvePartTwo(content, provider);
}
static void SolvePartOne(string[] content, IServiceProvider services)
{
    var consoleWriter = services.GetRequiredService<IConsoleWriter>();
    PrintPartBanner(consoleWriter, 1);

    var instructionInterpreter = services.GetRequiredService<IInterpreter<Instruction>>();
    var giantCrane = services.GetRequiredService<ICrateMover9000>();

    consoleWriter.WriteLine("Interpreting input...");
    var instruction = instructionInterpreter.Interpret(content);

    consoleWriter.WriteLine("Rearranging crates with CrateMover9000...");
    giantCrane.Rearrange(instruction);

    var answer = new String(instruction.CrateStacks.Select(x => x.Peek()).ToArray());
    PrintAnswer(consoleWriter, $"The answer is {answer}.");
}
static void SolvePartTwo(string[] content, IServiceProvider services)
{
    var consoleWriter = services.GetRequiredService<IConsoleWriter>();
    PrintPartBanner(consoleWriter, 2);

    var instructionInterpreter = services.GetRequiredService<IInterpreter<Instruction>>();
    var giantCrane = services.GetRequiredService<ICrateMover9001>();

    consoleWriter.WriteLine("Interpreting input...");
    var instruction = instructionInterpreter.Interpret(content);

    consoleWriter.WriteLine("Rearranging crates with CrateMover9001...");
    giantCrane.Rearrange(instruction);

    var answer = new String(instruction.CrateStacks.Select(x => x.Peek()).ToArray());
    PrintAnswer(consoleWriter, $"The answer is {answer}.");
}

static void PrintWelcomeBanner(IConsoleWriter consoleWriter)
{
    consoleWriter.WriteLine("Advent of code 2022 - Day 5");
    consoleWriter.WriteLine("===========================");
    consoleWriter.WriteLine();
}
static void PrintPartBanner(IConsoleWriter consoleWriter, int index)
{
    consoleWriter.WriteLine($"Part {index}");
    consoleWriter.WriteLine($"------");
}
static void PrintAnswer(IConsoleWriter consoleWriter, string answer)
{
    consoleWriter.WriteLine(answer, ConsoleColor.Green);
    consoleWriter.WriteLine();
}