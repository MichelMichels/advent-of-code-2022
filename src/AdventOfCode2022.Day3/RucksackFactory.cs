using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
    public class RucksackFactory : IRucksackFactory
    {
        private readonly IStringIntersecter stringIntersecter;

        public RucksackFactory(IStringIntersecter stringIntersecter)
        {
            this.stringIntersecter = stringIntersecter ?? throw new ArgumentNullException(nameof(stringIntersecter));
        }

        public IRucksack Create(string content, int compartmentCount)
        {
            var rucksack = new Rucksack(stringIntersecter, compartmentCount);
            rucksack.Fill(content);
            return rucksack;
        }
    }
}
