using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day5
{
    public class Day5Solver : BaseChallengeSolver
    {
        private readonly IInterpreter<Instruction> instructionInterpreter;
        private readonly ICrateMover9000 crateMover9000;
        private readonly ICrateMover9001 crateMover9001;

        public Day5Solver(
            IInterpreter<Instruction> instructionInterpreter,
            ICrateMover9000 crateMover9000,
            ICrateMover9001 crateMover9001,
            IMessageWriter messageWriter, 
            IInputParser inputParser) : base(messageWriter,inputParser) 
        {
            this.instructionInterpreter = instructionInterpreter ?? throw new ArgumentNullException(nameof(instructionInterpreter));
            this.crateMover9000 = crateMover9000 ?? throw new ArgumentNullException(nameof(crateMover9000));
            this.crateMover9001 = crateMover9001 ?? throw new ArgumentNullException(nameof(crateMover9001));
        }

        public override int DayNumber => 5;

        protected override void SolvePartOne()
        {
            var instruction = GetInstruction();

            messageWriter.WriteMessage("Rearranging crates with CrateMover9000...");
            crateMover9000.Rearrange(instruction);

            var answer = GetTopOfEachStack(instruction.CrateStacks);
            messageWriter.WriteAnswer($"The answer is {answer}.");
        }

        protected override void SolvePartTwo()
        {
            var instruction = GetInstruction();

            messageWriter.WriteMessage("Rearranging crates with CrateMover9001...");
            crateMover9001.Rearrange(instruction);

            var answer = GetTopOfEachStack(instruction.CrateStacks);
            messageWriter.WriteAnswer($"The answer is {answer}.");
        }

        private Instruction GetInstruction()
        {
            messageWriter.WriteMessage("Interpreting input...");
            return instructionInterpreter.Interpret(parsed);
        }

        private string GetTopOfEachStack(IEnumerable<Stack<char>> stacks) => new string(stacks.Select(x => x.Peek()).ToArray());        
    }
}
