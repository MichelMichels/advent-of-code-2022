using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2022.Day4.Tests
{
    [TestClass()]
    public class OverlapCheckerTests
    {
        [TestMethod()]
        public void IsOverlappingTest()
        {
            // Arrange
            var overlapChecker = new OverlapChecker();

            // Act
            ElfPair pair = new(new Range(0, 1), new Range(1, 2));
            var result = overlapChecker.IsOverlapping(pair);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsNotOverlappingTest()
        {
            // Arrange
            var overlapChecker = new OverlapChecker();

            // Act
            ElfPair pair = new(new Range(0, 1), new Range(7, 8));
            var result = overlapChecker.IsOverlapping(pair);

            // Assert
            Assert.IsFalse(result);
        }
    }
}