using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day2
{
    public class RockPaperScissorEngine : IRockPaperScissorEngine
    {
        private readonly IRockPaperScissorParser rockPaperScissorParser;

        public RockPaperScissorEngine(IRockPaperScissorParser rockPaperScissorParser)
        {
            this.rockPaperScissorParser = rockPaperScissorParser ?? throw new ArgumentNullException(nameof(rockPaperScissorParser));
        }

        public int GetTotalScore(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Can't process empty input.", nameof(input));
            }

            var splitInput = input.Split('\n');
            return splitInput
                .Select(rockPaperScissorParser.Parse)
                .Where(x => x != null)
                .Sum(x => x.GetScore());            
        }
    }
}
