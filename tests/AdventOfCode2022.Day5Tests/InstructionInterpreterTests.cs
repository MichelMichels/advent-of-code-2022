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
    public class InstructionInterpreterTests
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

                move 1 from 2 to 1
                move 3 from 1 to 3
                move 2 from 2 to 1
                move 1 from 1 to 2
                """;

            // Act
            var parser = new InputParser(new NewLineSplitter());
            var lines = parser.ParseString(input);

            var interpreter = new InstructionInterpreter(new CrateStackInterpreter(), new RearrangementProcedureInterpreter());
            var result = interpreter.Interpret(lines);

            // Assert
            Assert.AreEqual(3, result.CrateStacks.Length);
            Assert.AreEqual(4, result.RearrangementProcedures.Length);
        }
    }
}