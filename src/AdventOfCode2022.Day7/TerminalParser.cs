using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7
{
    public class TerminalParser : ITerminalParser
    {
        public List<ITerminalLine> Parse(string[] content)
        {
            var result = new List<ITerminalLine>();
            foreach(var line in content.Where(x => !string.IsNullOrEmpty(x)))
            {
                if(IsCommand(line))
                {
                    var commandParts = new string(line.Skip(2).ToArray()).Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var arguments = commandParts.Length > 1 ? string.Join(' ', commandParts.Skip(1)) : string.Empty;

                    result.Add(new TerminalCommandLine(GetTerminalCommand(commandParts[0]), arguments));
                } else
                {
                    result.Add(new TerminalOutputLine(line));
                }
            }

            return result;
        }

        private bool IsCommand(string line) => line.Trim().StartsWith("$");
        private TerminalCommand GetTerminalCommand(string name)
        {
            return name switch
            {
                "cd" => TerminalCommand.ChangeDirectory,
                "ls" => TerminalCommand.List,
                _ => throw new NotSupportedException(),
            };
        }
    }
}
