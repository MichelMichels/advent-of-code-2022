using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day4
{
    public class ElfPairParser : IElfPairParser
    {
        public ElfPair Parse(string raw)
        {
            var pair = new ElfPair();
            var parts = raw.Split(',');

            var rangeOne = parts[0].Split('-');
            var rangeTwo = parts[1].Split('-');
            pair.One = new SectionIdRange(int.Parse(rangeOne[0]), int.Parse(rangeOne[1]));
            pair.Two = new SectionIdRange(int.Parse(rangeTwo[0]), int.Parse(rangeTwo[1]));

            return pair;
        }
    }
}
