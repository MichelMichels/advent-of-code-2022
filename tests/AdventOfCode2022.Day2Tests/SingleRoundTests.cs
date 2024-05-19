using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2022.Day2.Tests
{
    [TestClass()]
    public class SingleRoundTests
    {
        [TestMethod()]
        [DataRow(HandShape.Rock, HandShape.Paper, 8)]
        [DataRow(HandShape.Paper, HandShape.Rock, 1)]
        [DataRow(HandShape.Scissors, HandShape.Scissors, 6)]
        public void SingleRoundTest(HandShape opponent, HandShape you, int expectedScore)
        {
            ISingleRound round = new SingleRound(opponent, you);

            var score = round.GetScore();

            Assert.AreEqual(expectedScore, score);
        }
    }
}