using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day7.Tests
{
    [TestClass()]
    public class TerminalParserTests
    {
        private readonly IInputParser inputParser = new InputParser(new NewLineSplitter());

        private string input = """
            $ cd /
            $ ls
            dir a
            14848514 b.txt
            8504156 c.dat
            dir d
            $ cd a
            $ ls
            dir e
            29116 f
            2557 g
            62596 h.lst
            $ cd e
            $ ls
            584 i
            $ cd ..
            $ cd ..
            $ cd d
            $ ls
            4060174 j
            8033020 d.log
            5626152 d.ext
            7214296 k
            """;        

        [TestMethod()]
        public void ParseTest()
        {
            // Arrange
            ITerminalParser parser = new TerminalParser();
            var parsed = GetParsedInput();

            // Act
            var terminalLines = parser.Parse(parsed);

            // Assert
            Assert.AreEqual(23, terminalLines.Count);
            Assert.AreEqual(10, terminalLines.OfType<TerminalCommandLine>().Count());
            Assert.AreEqual(13, terminalLines.OfType<TerminalOutputLine>().Count());
        }

        [TestMethod()]
        public void ParseCommandTest()
        {
            // Arrange
            ITerminalParser parser = new TerminalParser();
            var parsed = new string[]
            {
                "$ cd /",
                "$ ls",
            };

            // Act
            var terminalLines = parser.Parse(parsed);

            // Assert
            Assert.AreEqual(2, terminalLines.Count);
            Assert.AreEqual(TerminalCommand.ChangeDirectory, terminalLines.OfType<TerminalCommandLine>().First().Command);
            Assert.AreEqual("/", terminalLines.OfType<TerminalCommandLine>().First().Arguments);
            Assert.AreEqual(TerminalCommand.List, terminalLines.OfType<TerminalCommandLine>().Skip(1).First().Command);
            Assert.AreEqual(string.Empty, terminalLines.OfType<TerminalCommandLine>().Skip(1).First().Arguments);
        }

        [TestMethod()]
        public void ParseOutputTest()
        {
            // Arrange
            ITerminalParser parser = new TerminalParser();
            var parsed = new string[]
            {
                "14848514 b.txt",
                "8504156 c.dat"
            };

            // Act
            var terminalLines = parser.Parse(parsed);

            // Assert
            Assert.AreEqual(2, terminalLines.Count);
            Assert.AreEqual("14848514 b.txt", terminalLines.OfType<TerminalOutputLine>().First().Output);
            Assert.AreEqual("8504156 c.dat", terminalLines.OfType<TerminalOutputLine>().Skip(1).First().Output);
        }


        private string[] GetParsedInput() => inputParser.ParseString(input);
    }
}