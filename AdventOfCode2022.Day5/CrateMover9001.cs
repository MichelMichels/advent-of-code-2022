using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day5
{
    public class CrateMover9001 : ICrateMover9001
    {
        public void Rearrange(Instruction instruction)
        {
            for (int i = 0; i < instruction.RearrangementProcedures.Length; i++)
            {
                var procedure = instruction.RearrangementProcedures[i];
                var source = instruction.CrateStacks[procedure.Source - 1];
                var destination = instruction.CrateStacks[procedure.Destination - 1];

                var crates = new List<char>();                
                for (int j = 0; j < procedure.Quantity; j++)
                {
                    crates.Add(source.Pop());
                }

                crates.Reverse();
                foreach(var crate in crates)
                {
                    destination.Push(crate);
                }
            }
        }
    }
}
