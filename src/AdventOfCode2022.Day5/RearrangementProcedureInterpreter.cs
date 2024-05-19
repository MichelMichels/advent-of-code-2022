using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace AdventOfCode2022.Day5
{
    public class RearrangementProcedureInterpreter : IInterpreter<RearrangementProcedure[]>
    {
        public RearrangementProcedure[] Interpret(string[] content)
        {
            var result = new RearrangementProcedure[content.Where(x => !string.IsNullOrEmpty(x)).Count()];

            for(int i = 0; i < content.Length; i++) 
            {
                if (string.IsNullOrEmpty(content[i]))
                {
                    continue;
                }

                var line = new String(content[i].Where(c => Char.IsNumber(c) || Char.IsWhiteSpace(c)).ToArray()).Trim();
                var values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                result[i] = new RearrangementProcedure(values[0], values[1], values[2]);
            }

            return result;
        }
    }
}
