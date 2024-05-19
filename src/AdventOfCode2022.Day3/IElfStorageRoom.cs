using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
    public interface IElfStorageRoom
    {
        int CalculatePriorityOfSingleRucksacks(string content);
        int CalculatePriorityOfThreeElfGroupRucksacks(string content);
    }
}
