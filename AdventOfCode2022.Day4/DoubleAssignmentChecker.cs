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
            return DoesRangeContainSecondRange(pair.One, pair.Two) || DoesRangeContainSecondRange(pair.Two, pair.One);
        }

        private bool DoesRangeContainSecondRange(SectionIdRange one, SectionIdRange two)
        {
            return one.Start <= two.Start && one.End >= two.End;
        }
    }
}
