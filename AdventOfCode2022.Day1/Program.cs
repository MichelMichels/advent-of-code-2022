// See https://aka.ms/new-console-template for more information
using AdventOfCode2022.Day1;

Console.WriteLine("Advent of code 2022 - day 1");
Console.WriteLine();

var elfCalorieCounter = new ElfCalorieCounter();

var inputFilePath = "input.txt";
Console.WriteLine($"Trying to read {inputFilePath}...");

var content = File.ReadAllText(inputFilePath);
Console.WriteLine("Read input: ");
Console.WriteLine("-----------");

Console.WriteLine(content);