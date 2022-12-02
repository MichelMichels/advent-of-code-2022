using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day2
{
    public class OutcomeRockPaperScissorParser : RockPaperScissorParser
    {
        protected override HandShape GetYou(char c)
        {
            return c switch
            {
                'X' => LosingShape(),
                'Y' => DrawShape(),
                'Z' => WinningShape(),
                _ => throw new NotSupportedException(),
            };
        }

        private HandShape LosingShape()
        {
            return opponent switch
            {
                HandShape.Rock => HandShape.Scissors,
                HandShape.Paper => HandShape.Rock,
                HandShape.Scissors => HandShape.Paper,
                _ => throw new NotSupportedException(),
            };
        }
        private HandShape WinningShape()
        {
            return opponent switch
            {
                HandShape.Rock => HandShape.Paper,
                HandShape.Paper => HandShape.Scissors,
                HandShape.Scissors => HandShape.Rock,
                _ => throw new NotSupportedException(),
            };
        }
        private HandShape DrawShape()
        {
            return opponent;
        }
    }
}
