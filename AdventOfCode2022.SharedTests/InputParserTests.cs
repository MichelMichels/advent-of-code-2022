using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace AdventOfCode2022.Shared.Tests
{
    [TestClass()]
    public class InputParserTests
    {
        [TestMethod()]
        public void ParseTextFile_Null_Test()
        {
            // Arrange
            IInputParser inputParser = new InputParser(new Mock<IStringSplitter>().Object);

            // Act
            Assert.ThrowsException<ArgumentException>(() => inputParser.ParseTextFile(null));
        }

        [TestMethod()]
        public void ParseTextFile_Emtpty_Test()
        {
            // Arrange
            IInputParser inputParser = new InputParser(new Mock<IStringSplitter>().Object);

            // Act
            Assert.ThrowsException<ArgumentException>(() => inputParser.ParseTextFile(string.Empty));
        }
    }
}