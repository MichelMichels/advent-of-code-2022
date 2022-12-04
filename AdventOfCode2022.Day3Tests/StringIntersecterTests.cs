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
    public class StringIntersecterTests
    {
        [TestMethod()]
        [DataRow("1234", "5671", "1")]
        public void IntersectTest(string one, string two, string expectedResult)
        {
            // Arrange
            var intersecter = new StringIntersecter();

            // Act
            var result = intersecter.Intersect(new[] { one, two });

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}