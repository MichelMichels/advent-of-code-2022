using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Shared
{
    public interface IChallengeSolver
    {
        int DayNumber { get; }

        void Solve(string filePath);
    }
}
