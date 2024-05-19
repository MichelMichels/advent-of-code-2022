using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day4
{
    public interface IElfPairParser
    {
        ElfPair Parse(string raw);
    }
}
