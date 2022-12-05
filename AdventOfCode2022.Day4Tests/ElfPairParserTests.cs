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
    public class ElfPairParserTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            // Arrange
            IElfPairParser parser = new ElfPairParser();

            // Act
            var pair = parser.Parse("2-4,6-8");

            // Assert
            Assert.AreEqual(2, pair.First.Start);
            Assert.AreEqual(4, pair.First.End);
            Assert.AreEqual(6, pair.Second.Start);
            Assert.AreEqual(8, pair.Second.End);
        }
    }
}