using AdventOfCode2022.Day5;
using AdventOfCode2022.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services
            .AddSingleton<IConsoleWriter, ConsoleWriter>()
            .AddSingleton<IStringSplitter, NewLineSplitter>()
            .AddSingleton<IInputParser, InputParser>()
            .AddSingleton<IInterpreter<RearrangementProcedure[]>, RearrangementProcedureInterpreter>()
            .AddSingleton<IInterpreter<CrateStack[]>, CrateStackInterpreter>()
            .AddSingleton<IInterpreter<Instruction>, InstructionInterpreter>()
            .AddSingleton<ICrateMover9000, CrateMover9000>()
            .AddSingleton<ICrateMover9001, CrateMover9001>()
            .AddSingleton<IMessageWriter, ConsoleMessageWriter>()
            .AddSingleton<IChallengeSolver, Day5Solver>()
            )            
    .Build();

host.Services
    .GetRequiredService<IChallengeSolver>()
    .Solve("input.txt");

await host.RunAsync();