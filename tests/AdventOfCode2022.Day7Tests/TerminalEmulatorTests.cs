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
    public class TerminalEmulatorTests
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
        public void ConstructFileSystemTest()
        {
            // Arrange
            var emulator = new TerminalEmulator();

            // Act 
            var fileSystem = emulator.ConstructFileSystem(new List<ITerminalLine>()
            {
                new TerminalCommandLine(TerminalCommand.ChangeDirectory, "/"),
                new TerminalCommandLine(TerminalCommand.List),
                new TerminalOutputLine("62596 h.lst"),
                new TerminalOutputLine("1024 test.txt"),
            });

            // Assert
            Assert.AreEqual(62596 + 1024, fileSystem.Size);
            Assert.AreEqual(2, fileSystem.Children.Count);
        }

        [TestMethod()]
        public void AdventOfCodeSampleTest()
        {
            // Arrange
            var parsed = inputParser.ParseString(input);
            var terminalParser = new TerminalParser();
            var terminalLines = terminalParser.Parse(parsed);
            var emulator = new TerminalEmulator();

            // Act
            var fileSystem = emulator.ConstructFileSystem(terminalLines);

            // Assert
            Assert.AreEqual(94853, fileSystem.FindDirectory("a")?.Size);
            Assert.AreEqual(584, fileSystem.FindDirectory("e")?.Size);
            Assert.AreEqual(24933642, fileSystem.FindDirectory("d")?.Size);
            Assert.AreEqual(48381165, fileSystem.FindDirectory("/")?.Size);
            Assert.AreEqual(95437, fileSystem.GetDirectoriesOfMaximumSize(100000).Sum(x => x.Size));
        }
    }
}