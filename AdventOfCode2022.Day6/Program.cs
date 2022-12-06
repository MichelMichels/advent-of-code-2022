



using AdventOfCode2022.Day6;
using AdventOfCode2022.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
        services
            .AddSingleton<IConsoleWriter, ConsoleWriter>()
            .AddSingleton<IStringSplitter, NewLineSplitter>()
            .AddSingleton<IInputParser, InputParser>()
            .AddSingleton<IDatastreamDecoder, DatastreamDecoder>()
            .AddSingleton<IMessageWriter, ConsoleMessageWriter>()
            .AddSingleton<IChallengeSolver, Day6Solver>())
    .Build();

host.Services
    .GetRequiredService<IChallengeSolver>()
    .Solve();

await host.RunAsync();