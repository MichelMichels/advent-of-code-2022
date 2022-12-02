using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day2
{
    public interface ISingleRound
    {
        HandShape You { get; set; }
        HandShape Opponent { get; set; }
        int GetScore();
    }
}
