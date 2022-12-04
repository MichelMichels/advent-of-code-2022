using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
    public interface IRucksack
    {
        string[] Compartments { get; }
        void Fill(string content);
        string GetSharedItemTypes();
    }
}
