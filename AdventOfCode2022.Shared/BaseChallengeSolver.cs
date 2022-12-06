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
        protected BaseChallengeSolver(IMessageWriter messageWriter)
        {
            this.messageWriter = messageWriter ?? throw new ArgumentNullException(nameof(messageWriter));
        }
        public abstract int DayNumber { get; }

        public void Solve()
        {
            messageWriter.WriteBanner();
            messageWriter.WriteDayBanner(DayNumber);

            BeforeSolvingParts();

            messageWriter.WritePartBanner(1);
            SolvePartOne();

            messageWriter.WritePartBanner(2);
            SolvePartTwo();
        }

        protected virtual void BeforeSolvingParts() { }
        protected abstract void SolvePartOne();
        protected abstract void SolvePartTwo();
    }

}
