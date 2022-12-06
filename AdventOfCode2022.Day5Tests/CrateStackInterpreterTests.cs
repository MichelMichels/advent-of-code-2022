using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day5.Tests
{
    [TestClass()]
    public class CrateStackInterpreterTests
    {
        [TestMethod()]
        public void InterpretTest()
        {
            // Arrange
            var input = """
                    [D]    
                [N] [C]    
                [Z] [M] [P]
                 1   2   3 
                """;

            var inputParser = new InputParser(new NewLineSplitter());
            var content = inputParser.ParseString(input);

            var crateStackInterpreter = new CrateStackInterpreter();

            // Act
            var stacks = crateStackInterpreter.Interpret(content);

            // Assert
            Assert.AreEqual(3, stacks.Length);
            Assert.AreEqual('N', stacks[0].Peek());
            Assert.AreEqual('D', stacks[1].Peek());
            Assert.AreEqual('P', stacks[2].Peek());
        }
    }
}