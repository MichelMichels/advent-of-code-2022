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
            Assert.Throws<ArgumentException>(() => inputParser.ParseTextFile(null!));
        }

        [TestMethod()]
        public void ParseTextFile_Emtpty_Test()
        {
            // Arrange
            IInputParser inputParser = new InputParser(new Mock<IStringSplitter>().Object);

            // Act
            Assert.Throws<ArgumentException>(() => inputParser.ParseTextFile(string.Empty));
        }
    }
}