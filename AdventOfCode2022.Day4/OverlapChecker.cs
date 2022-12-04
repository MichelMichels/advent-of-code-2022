using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day4
{
    public class OverlapChecker : IOverlapChecker
    {
        public bool IsOverlapping(ElfPair elfPair)
        {
            return DoesRangeOverlap(elfPair.One, elfPair.Two);
        }

        private bool DoesRangeOverlap(SectionIdRange one, SectionIdRange two)
        {
            var rangeOne = Enumerable.Range(one.Start, one.End - one.Start + 1);
            var rangeTwo = Enumerable.Range(two.Start, two.End - two.Start + 1);

            return rangeOne.Intersect(rangeTwo).Any();
        }
    }
}
