// See https://aka.ms/new-console-template for more information
using AdventOfCode2022.Day1;
using System.Runtime.CompilerServices;

Console.WriteLine("Advent of code 2022 - Day 1");
Console.WriteLine();

var elfCalorieCounter = new ElfCalorieCounter();
var inputFilePath = "input.txt";
Console.WriteLine($"Trying to read {inputFilePath}...");

var content = File.ReadAllText(inputFilePath);
Console.WriteLine($"{inputFilePath} file read.");

PlayPartOne(elfCalorieCounter, content);
PlayPartTwo(elfCalorieCounter, content);

static void PlayPartOne(IElfCalorieCounter elfCalorieCounter, string input)
{
    Console.WriteLine("Part One:");
    Console.WriteLine("=========");   

    var maxCount = elfCalorieCounter.GetMaxCalorieCountOfSingleElf(input);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"The max calorie count that a single elf is carrying is {maxCount}.");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine();
}

static void PlayPartTwo(IElfCalorieCounter elfCalorieCounter, string input)
{
    Console.WriteLine("Part Two:");
    Console.WriteLine("=========");

    var elfCount = 3;
    var sum = elfCalorieCounter.GetSumCaloriesOfTopElves(input, elfCount);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"The amount of calories the top {elfCount} elves are carrying is {sum}.");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine();



}

