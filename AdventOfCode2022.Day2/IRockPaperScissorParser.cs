﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day2
{
    public interface IRockPaperScissorParser
    {
        ISingleRound? Parse(string input);
    }
}
