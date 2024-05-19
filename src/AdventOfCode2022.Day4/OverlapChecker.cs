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
            return DoesRangeOverlap(elfPair.First, elfPair.Second);
        }

        private bool DoesRangeOverlap(Range one, Range two)
        {
            var rangeOne = Enumerable.Range(one.Start.Value, one.End.Value - one.Start.Value + 1);
            var rangeTwo = Enumerable.Range(two.Start.Value, two.End.Value - two.Start.Value + 1);
            return rangeOne.Intersect(rangeTwo).Any();
        }
    }
}
