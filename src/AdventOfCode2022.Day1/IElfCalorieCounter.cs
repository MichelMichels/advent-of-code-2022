using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day1
{
    public interface IElfCalorieCounter
    {
        int GetMaxCalorieCountOfSingleElf(string input);
        int GetSumCaloriesOfTopElves(string input, int elfCount);
    }
}
