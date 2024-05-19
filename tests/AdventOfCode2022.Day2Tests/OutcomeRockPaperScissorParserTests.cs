using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day2.Tests
{
    [TestClass()]
    public class OutcomeRockPaperScissorParserTests
    {
        [TestMethod()]
        [DataRow("A Y", HandShape.Rock, HandShape.Rock)]
        [DataRow("B X", HandShape.Paper, HandShape.Rock)]
        [DataRow("C Z", HandShape.Scissors, HandShape.Rock)]
        [DataRow("B.Z.", HandShape.Paper, HandShape.Scissors)]
        public void ParseTest(string input, HandShape opponent, HandShape you)
        {
            // Arrange
            var parser = new OutcomeRockPaperScissorParser();

            // Act
            var result = parser.Parse(input);

            // Assert
            Assert.AreEqual(opponent, result.Opponent);
            Assert.AreEqual(you, result.You);
        }

        [TestMethod]
        [DataRow("OH")]
        public void ParseNullTest(string input)
        {
            // Arrange
            var parser = new OutcomeRockPaperScissorParser();

            // Act
            var result = parser.Parse(input);

            // Assert
            Assert.IsNull(result);
        }
    }
}