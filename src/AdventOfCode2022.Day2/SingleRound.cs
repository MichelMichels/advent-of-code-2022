using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day2
{
    public class SingleRound : ISingleRound
    {
        public SingleRound(HandShape opponent, HandShape you)
        {
            Opponent = opponent;
            You = you;
        }

        public HandShape Opponent { get; set; }
        public HandShape You { get; set; }

        public int GetScore()
        {
            int score = GetYourScore();
            
            if(Opponent == You)
            {
                score += 3;
            } else
            {
                if(
                    (Opponent == HandShape.Rock && You == HandShape.Paper) ||
                    (Opponent == HandShape.Paper && You == HandShape.Scissors) ||
                    (Opponent == HandShape.Scissors && You == HandShape.Rock)
                    )
                {
                    score += 6;
                }               
            }           

            return score;
        }

        private int GetYourScore() 
        {
            return You switch
            {
                HandShape.Rock => 1,
                HandShape.Paper => 2,
                HandShape.Scissors => 3,
                _ => throw new NotSupportedException(),
            };
        }
    }
}
