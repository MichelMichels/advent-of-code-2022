using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day1
{
    public class ElfCalorieCounter : IElfCalorieCounter
    {
        public ElfCalorieCounter() { }

        public int GetMaxCalorieCountOfSingleElf(string input)
        {                        
            return ParseInput(input).Max();            
        }

        public int GetSumCaloriesOfTopElves(string input, int elfCount)
        {
            return ParseInput(input).OrderDescending().Take(elfCount).Sum();
        }

        private List<int> ParseInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Can't handle null or empty input", nameof(input));
            }

            List<int> result = new();
            var splittedInput = input.Split(Environment.NewLine);
            int currentCount = 0;
            foreach (var line in splittedInput)
            {
                if (string.IsNullOrEmpty(line))
                {
                    result.Add(currentCount);
                    currentCount = 0;
                    continue;
                }

                currentCount += int.Parse(line);
            }

            if(currentCount != 0)
            {
                result.Add(currentCount);
            }

            Debug.WriteLine($"Counts: {string.Join(',', result)}");

            return result;
        }
    }
}
