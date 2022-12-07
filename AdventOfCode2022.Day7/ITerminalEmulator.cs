namespace AdventOfCode2022.Day7
{
    public interface ITerminalEmulator
    {
        FileSystem ConstructFileSystem(IEnumerable<ITerminalLine> lines);
    }
}
