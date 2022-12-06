using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day5
{
    public class GiantCargoCrane : IGiantCargoCrane
    {
        public void Rearrange(Instruction instruction)
        {
            for(int i = 0; i < instruction.RearrangementProcedures.Length; i++)
            {
                var procedure = instruction.RearrangementProcedures[i];
                var source = instruction.CrateStacks[procedure.Source - 1];
                var destination = instruction.CrateStacks[procedure.Destination - 1];

                for(int j = 0; j < procedure.Quantity; j++)
                {
                    destination.Push(source.Pop());
                }
            }
        }
    }
}
