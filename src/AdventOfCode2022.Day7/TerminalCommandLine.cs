namespace AdventOfCode2022.Day7
{
    public class TerminalCommandLine : ITerminalLine
    {
        public TerminalCommandLine(TerminalCommand command) : this(command, string.Empty) { }
        public TerminalCommandLine(TerminalCommand command, string arguments)
        {
            Command = command;
            Arguments = arguments;
        }

        public TerminalCommand Command { get; set; }
        public string Arguments { get; set; } = string.Empty;
    }
}
