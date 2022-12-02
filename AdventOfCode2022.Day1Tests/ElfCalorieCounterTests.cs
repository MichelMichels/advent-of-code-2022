using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day1.Tests
{
    [TestClass()]
    public class ElfCalorieCounterTests
    {
        [TestMethod]
        public void ThrowsArgumentException()
        {
            // Arrange
            var counter = new ElfCalorieCounter();

            // Act
            Assert.ThrowsException<ArgumentException>(() => counter.GetMaxCalorieCountOfSingleElf(null));
        }

        [TestMethod()]
        public void GetMaxCalorieCountOfSingleElfTest()
        {
            // Arrange
            var content = """
                1000
                2000
                3000

                4000

                5000
                6000

                7000
                8000
                9000

                10000
                """;
            var counter = new ElfCalorieCounter();

            // Act
            int maxCount = counter.GetMaxCalorieCountOfSingleElf(content);

            // Assert
            Assert.AreEqual(24000, maxCount);
        }
    }
}