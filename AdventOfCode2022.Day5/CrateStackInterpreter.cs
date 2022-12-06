using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day5
{
    public class CrateStackInterpreter : IInterpreter<CrateStack[]>
    {
        public CrateStack[] Interpret(string[] content)
        {            
            var stackCount = (content.First().Length + 1) / 4;
            var result = new CrateStack[stackCount];
            for(int i = 0; i < stackCount; i++)
            {
                result[i] = new CrateStack();
            }

            Array.Reverse(content);           
            for(int i = 0; i < content.Length; i++)
            {
                var currentLine = content[i];
                for(int j = 0; j < stackCount; j++)
                {
                    int crateNumberIndex = (j * 4) + 1;
                    char crateNumber = currentLine[crateNumberIndex];

                    if(Char.IsLetter(crateNumber))
                    {
                        result[j].Push(crateNumber);
                    } else if(Char.IsWhiteSpace(crateNumber))
                    {
                        continue;
                    } else
                    {
                        break;
                    }
                }
            }

            return result;
        }
    }
}
