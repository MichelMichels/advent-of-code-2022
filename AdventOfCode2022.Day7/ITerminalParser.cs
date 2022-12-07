using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7
{
    public interface ITerminalParser
    {
        List<ITerminalLine> Parse(string[] content);
    }
}
