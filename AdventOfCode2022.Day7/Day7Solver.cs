using AdventOfCode2022.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7
{
    public class Day7Solver : BaseChallengeSolver
    {
        private readonly ITerminalEmulator terminalEmulator;
        private readonly ITerminalParser terminalParser;
        public Day7Solver(
            ITerminalEmulator terminalEmulator, 
            ITerminalParser terminalParser, 
            IMessageWriter messageWriter, 
            IInputParser inputParser) : base(messageWriter, inputParser) 
        {
            this.terminalEmulator = terminalEmulator ?? throw new ArgumentNullException(nameof(terminalEmulator));
            this.terminalParser = terminalParser ?? throw new ArgumentNullException(nameof(terminalParser));
        }

        public override int DayNumber => 7;

        protected override void SolvePartOne()
        {
            var lines = terminalParser.Parse(parsed);
            var fileSystem = terminalEmulator.ConstructFileSystem(lines);

            var size = fileSystem.GetDirectoriesOfMaximumSize(100000).Sum(x => x.Size);
            messageWriter.WriteAnswer($"The answer of part one is {size}.");
        }

        protected override void SolvePartTwo()
        {
            var lines = terminalParser.Parse(parsed);
            var fileSystem = terminalEmulator.ConstructFileSystem(lines);

            int sizeOfUsedSpace = fileSystem.Size;
            messageWriter.WriteMessage($"The used space is {sizeOfUsedSpace} of 70000000.");

            int sizeToClear = sizeOfUsedSpace - 40000000;
            messageWriter.WriteMessage($"We need at least 30000000 for the update, so we need to clear {sizeToClear}.");

            var directoryToDelete = fileSystem
                .GetAllDirectories()
                .Where(x => x.Size > sizeToClear)
                .OrderBy(x => x.Size)
                .First();

            messageWriter.WriteAnswer($"The answer for part two is {directoryToDelete.Size}");
        }
    }
}
