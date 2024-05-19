using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Shared
{
    public class ConsoleWriter : IConsoleWriter
    {
        private ConsoleColor defaultForeground;

        public ConsoleWriter() : this(ConsoleColor.White) { }
        public ConsoleWriter(ConsoleColor defaultForeground)
        {
            this.defaultForeground = defaultForeground;
        }

        public void Write(string content)
        {
            GenericWrite(Console.Write, content, defaultForeground);
        }
        public void Write(string content, ConsoleColor foreground)
        {
            GenericWrite(Console.Write, content, foreground);
        }

        public void WriteLine(string content = "")
        {
            GenericWrite(Console.WriteLine, content, defaultForeground);
        }
        public void WriteLine(string content, ConsoleColor foreground)
        {
            GenericWrite(Console.WriteLine, content, foreground);
        }

        private void GenericWrite(Action<string?> writeAction, string content, ConsoleColor foreground)
        {
            Console.ForegroundColor = foreground;
            writeAction(content);
            Console.ForegroundColor = defaultForeground;
        }
    }
}
