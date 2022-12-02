using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace AdventOfCode2022.Day2.Tests
{
    [TestClass()]
    public class RockPaperScissorsEngineTests
    {
        [TestMethod()]
        public void ThrowsArgumentException()
        {
            var mockedParser = new Mock<IRockPaperScissorParser>();
            IRockPaperScissorEngine engine = new RockPaperScissorEngine(mockedParser.Object);

            Assert.ThrowsException<ArgumentException>(() => engine.GetTotalScore(null));
            Assert.ThrowsException<ArgumentException>(() => engine.GetTotalScore(string.Empty));
        }

        [TestMethod]
        public void GetScore()
        {
            // Arrange            
            IRockPaperScissorEngine engine = new RockPaperScissorEngine(new RockPaperScissorParser());

            // Act
            int score = engine.GetTotalScore("""
                A Y
                B X
                C Z
                """);

            // Assert
            Assert.AreEqual(15, score);
        }

        [TestMethod]
        public void GetOutcomeScore()
        {
            // Arrange            
            IRockPaperScissorEngine engine = new RockPaperScissorEngine(new OutcomeRockPaperScissorParser());

            // Act
            int score = engine.GetTotalScore("""
                A Y
                B X
                C Z
                """);

            // Assert
            Assert.AreEqual(12, score);
        }
    }
}