namespace AdventOfCode2022.Day7
{
    public class TerminalOutputLine : ITerminalLine
    {
        public TerminalOutputLine(string output)
        {
            Output = output;
        }
        public string Output { get; set; }
    }
}
