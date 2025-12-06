using AdventOfCode2022.Day9;
using AdventOfCode2022.Day9.Services;
using AdventOfCode2022.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
        services
            .AddSingleton<IInputParser, InputParser>()
            .AddSingleton<IStringSplitter, NewLineSplitter>()
            .AddSingleton<IConsoleWriter, ConsoleWriter>()
            .AddSingleton<IMessageWriter, ConsoleMessageWriter>()
            .AddSingleton<IRopeMover, RopeMover>()
            .AddSingleton<IChallengeSolver, Day9Solver>())
    .Build();

host.Services
    .GetRequiredService<IChallengeSolver>()
    .Solve("input.txt");