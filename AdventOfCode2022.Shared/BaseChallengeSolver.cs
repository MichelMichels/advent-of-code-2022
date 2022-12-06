using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Shared
{
    public abstract class BaseChallengeSolver : IChallengeSolver
    {
        protected readonly IMessageWriter messageWriter;
        protected readonly IInputParser inputParser;

        protected string[] parsed = Array.Empty<string>();

        protected BaseChallengeSolver(IMessageWriter messageWriter, IInputParser inputParser)
        {
            this.messageWriter = messageWriter ?? throw new ArgumentNullException(nameof(messageWriter));
            this.inputParser = inputParser ?? throw new ArgumentNullException(nameof(inputParser));
        }
        public abstract int DayNumber { get; }

        public void Solve(string filePath)
        {
            messageWriter.WriteBanner();
            messageWriter.WriteDayBanner(DayNumber);

            ParseFile(filePath);
            AfterParsing();

            messageWriter.WritePartBanner(1);
            SolvePartOne();

            messageWriter.WritePartBanner(2);
            SolvePartTwo();
        }

        protected virtual void AfterParsing()
        {
            messageWriter.WriteNewLine();
        }
        protected abstract void SolvePartOne();
        protected abstract void SolvePartTwo();

        private void ParseFile(string filePath)
        {
            messageWriter.WriteMessage($"Parsing {filePath}...");
            parsed = inputParser.ParseTextFile(filePath);
        }
    }
}
