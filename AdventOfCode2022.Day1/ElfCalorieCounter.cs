using System;
using System.Collections.Generic;
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
            if(string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(nameof(input));
            }

            throw new NotImplementedException();
        }
    }
}
