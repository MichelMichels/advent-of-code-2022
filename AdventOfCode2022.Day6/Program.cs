



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
            .AddSingleton<IDatastreamDecoder, DatastreamDecoder>())
    .Build();

SolveParts(host.Services);

await host.RunAsync();

static void SolveParts(IServiceProvider services)
{
    var consoleWriter = services.GetService<IConsoleWriter>();
    consoleWriter.WriteLine("Advent of code 2022 - Day 6", ConsoleColor.Blue);
    consoleWriter.WriteLine();
    consoleWriter.WriteLine("Part one");
    consoleWriter.WriteLine("--------");

    var inputParser = services.GetRequiredService<IInputParser>();

    consoleWriter.WriteLine("Parsing input.txt...");
    var stream = inputParser.ParseTextFile("input.txt").First();

    var decoder = services.GetRequiredService<IDatastreamDecoder>();
    consoleWriter.WriteLine("Decoding stream...");
    var data = decoder.DecodeStartOfPacket(stream);

    consoleWriter.WriteLine($"The answer is {data.NumberOfCharactersBeforeMarker}.", ConsoleColor.Green);

    consoleWriter.WriteLine();
    consoleWriter.WriteLine("Part two");
    consoleWriter.WriteLine("--------");

    var dataMessage = decoder.DecodeStartOfMessage(stream);

    consoleWriter.Write($"The answer is {dataMessage.NumberOfCharactersBeforeMarker}.", ConsoleColor.Green);
    consoleWriter.WriteLine();
    consoleWriter.WriteLine();
}