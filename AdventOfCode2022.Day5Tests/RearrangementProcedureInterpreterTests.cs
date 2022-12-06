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
    public class RearrangementProcedureInterpreterTests
    {
        [TestMethod()]
        public void InterpretTest()
        {
            // Arrange
            var input = """
                move 1 from 2 to 1
                move 3 from 1 to 3
                move 2 from 2 to 1
                move 1 from 1 to 2
                """;

            var inputParser = new InputParser(new NewLineSplitter());
            var content = inputParser.ParseString(input);
            var interpreter = new RearrangementProcedureInterpreter();

            // Act
            var procedures = interpreter.Interpret(content);

            // Assert
            Assert.AreEqual(4, procedures.Length);
            Assert.AreEqual(1, procedures[0].Quantity);
            Assert.AreEqual(3, procedures[1].Quantity);
            Assert.AreEqual(2, procedures[2].Quantity);
            Assert.AreEqual(1, procedures[3].Quantity);
            Assert.AreEqual(2, procedures[0].Source);
            Assert.AreEqual(1, procedures[1].Source);
            Assert.AreEqual(2, procedures[2].Source);
            Assert.AreEqual(1, procedures[3].Source);
            Assert.AreEqual(1, procedures[0].Destination);
            Assert.AreEqual(3, procedures[1].Destination);
            Assert.AreEqual(1, procedures[2].Destination);
            Assert.AreEqual(2, procedures[3].Destination);
        }
    }
}