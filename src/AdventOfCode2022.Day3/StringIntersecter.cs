using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
    public class StringIntersecter : IStringIntersecter
    {
        public string Intersect(string[] input)
        {
            if (input.Length < 2)
            {
                return string.Empty;
            }

            string result = input[0];
            foreach (var item in input)
            {
                result = new String(result.Intersect(item).ToArray());
            }

            return result;
        }
    }
}
