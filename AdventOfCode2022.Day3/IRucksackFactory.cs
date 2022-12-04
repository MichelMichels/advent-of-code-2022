using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
    public interface IRucksackFactory
    {
        IRucksack Create(string content, int compartmentCount);
    }
}
