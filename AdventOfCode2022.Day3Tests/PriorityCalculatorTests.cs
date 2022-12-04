using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3.Tests
{
    [TestClass()]
    public class PriorityCalculatorTests
    {
        [TestMethod()]
        [DataRow("p", 16)]
        [DataRow("L", 38)]
        [DataRow("P", 42)]
        [DataRow("v", 22)]
        [DataRow("t", 20)]
        [DataRow("s", 19)]
        public void CalculatePriorityTest(string input, int expectedPriority)
        {
            // Arrange
            var calculator = new PriorityCalculator();

            // Act
            var result = calculator.CalculatePriority(input);

            // Assert
            Assert.AreEqual(expectedPriority, result);
        }
    }
}