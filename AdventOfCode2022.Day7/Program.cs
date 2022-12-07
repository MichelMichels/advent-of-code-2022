using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AdventOfCode2022.Shared;
using AdventOfCode2022.Day7;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
        services
            .AddSingleton<IInputParser, InputParser>()
            .AddSingleton<IStringSplitter, NewLineSplitter>()
            .AddSingleton<IConsoleWriter, ConsoleWriter>() 
            .AddSingleton<IMessageWriter, ConsoleMessageWriter>()
            .AddSingleton<ITerminalParser, TerminalParser>()    
            .AddSingleton<ITerminalEmulator, TerminalEmulator>()
            .AddSingleton<IChallengeSolver, Day7Solver>())
    .Build();

host.Services
    .GetRequiredService<IChallengeSolver>()
    .Solve("input.txt");

await host.RunAsync();
