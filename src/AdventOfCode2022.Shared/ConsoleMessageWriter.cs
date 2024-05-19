namespace AdventOfCode2022.Shared
{
    public class ConsoleMessageWriter : IMessageWriter
    {
        private readonly IConsoleWriter consoleWriter;

        public ConsoleMessageWriter(IConsoleWriter consoleWriter)
        {
            this.consoleWriter = consoleWriter ?? throw new ArgumentNullException(nameof(consoleWriter));
        }

        public void WriteAnswer(string answer)
        {
            consoleWriter.WriteLine($"[\u2713] {answer}", ConsoleColor.Green);
            consoleWriter.WriteLine();
        }

        public void WriteBanner()
        {
            consoleWriter.WriteLine("[*] Advent of Code 2022", ConsoleColor.DarkBlue);
        }

        public void WriteDayBanner(int day)
        {
            consoleWriter.WriteLine($"[*] Day {day}", ConsoleColor.Blue);
            consoleWriter.WriteLine();
        }

        public void WriteMessage(string message)
        {
            consoleWriter.WriteLine($"[i] {message}");
        }

        public void WritePartBanner(int part)
        {
            consoleWriter.WriteLine($"[*] Part {part}", ConsoleColor.Cyan);
        }
        public void WriteNewLine() => consoleWriter.WriteLine();

        public void WriteError(string message)
        {
            consoleWriter.WriteLine($"[!] {message}", ConsoleColor.DarkRed);
            consoleWriter.WriteLine();
        }
    }

}
