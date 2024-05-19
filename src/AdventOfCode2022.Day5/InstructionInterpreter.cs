using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day5
{
    public class InstructionInterpreter : IInterpreter<Instruction>
    {
        private readonly IInterpreter<CrateStack[]> crateStackInterpreter;
        private readonly IInterpreter<RearrangementProcedure[]> rearrangementProcedureInterpreter;

        public InstructionInterpreter(IInterpreter<CrateStack[]> crateStackInterpreter, IInterpreter<RearrangementProcedure[]> rearrangementProcedureInterpreter)
        {
            this.crateStackInterpreter = crateStackInterpreter ?? throw new ArgumentNullException(nameof(crateStackInterpreter));
            this.rearrangementProcedureInterpreter = rearrangementProcedureInterpreter ?? throw new ArgumentNullException(nameof(rearrangementProcedureInterpreter));
        }

        public Instruction Interpret(string[] content)
        {
            var separatorLineIndex = Array.IndexOf(content, string.Empty);

            var stacks = crateStackInterpreter.Interpret(content.Take(separatorLineIndex).ToArray());
            var rearrangementProcedures = rearrangementProcedureInterpreter.Interpret(content.Skip(separatorLineIndex + 1).ToArray());

            return new Instruction(stacks, rearrangementProcedures);
        }
    }
}
