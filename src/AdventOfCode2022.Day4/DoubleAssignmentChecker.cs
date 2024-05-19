using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day4
{
    public class DoubleAssignmentChecker : IDoubleAssignmentChecker
    {
        public bool IsDoubleAssigned(ElfPair pair)
        {
            return DoesRangeContainSecondRange(pair.First, pair.Second) || DoesRangeContainSecondRange(pair.Second, pair.First);
        }

        private bool DoesRangeContainSecondRange(Range one, Range two)
        {
            return one.Start.Value <= two.Start.Value && one.End.Value >= two.End.Value;
        }
    }
}
