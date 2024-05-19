namespace AdventOfCode2022.Day2
{
    public class RockPaperScissorParser : IRockPaperScissorParser
    {
        protected HandShape opponent;

        public ISingleRound? Parse(string input)
        {
            var letters = new String(input.Where(Char.IsLetter).ToArray());

            switch(letters.FirstOrDefault())
            {
                case 'A':                    
                case 'B':                    
                case 'C':
                    return ParseValidatedInput(letters);
                default:
                    return null;
            }            
        }

        private ISingleRound? ParseValidatedInput(string input)
        {
            opponent = GetOpponent(input[0]);
            
            return new SingleRound(opponent, GetYou(input[1]));
        }

        protected HandShape GetOpponent(char c)
        {
            return c switch
            {
                'A' => HandShape.Rock,
                'B' => HandShape.Paper,
                'C' => HandShape.Scissors,
                _ => throw new NotSupportedException(),
            };
        }
        protected virtual HandShape GetYou(char c)
        {
            return c switch
            {
                'X' => HandShape.Rock,
                'Y' => HandShape.Paper,
                'Z' => HandShape.Scissors,
                _ => throw new NotSupportedException(),
            };
        }
    }
}
