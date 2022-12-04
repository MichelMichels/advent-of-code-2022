using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var result = overlapChecker.IsOverlapping(new ElfPair()
            {
                One = new Range(0, 1),
                Two = new Range(1, 2),
            });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsNotOverlappingTest()
        {
            // Arrange
            var overlapChecker = new OverlapChecker();

            // Act
            var result = overlapChecker.IsOverlapping(new ElfPair()
            {
                One = new Range(0, 1),
                Two = new Range(7, 8),
            });

            // Assert
            Assert.IsFalse(result);
        }
    }
}