using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
    public class PriorityCalculator : IPriorityCalculator
    {
        public int CalculatePriority(string input)
        {
            int priority = 0;

            foreach(var c in input)
            {
                if(Char.IsLower(c))
                {
                    priority += c - 'a' + 1;
                } else if(Char.IsUpper(c))
                {
                    priority += c - 'A' + 27;
                }
            }

            return priority;            
        }
    }
}
