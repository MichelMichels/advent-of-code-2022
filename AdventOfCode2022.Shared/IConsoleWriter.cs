namespace AdventOfCode2022.Shared
{
    public interface IConsoleWriter
    {
        void WriteLine(string content = "");
        void WriteLine(string content, ConsoleColor foreground);
        void Write(string content);
        void Write(string content, ConsoleColor foreground);
    }
}