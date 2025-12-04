namespace AdventOfCode2022.Day1.Tests
{
    [TestClass()]
    public class ElfCalorieCounterTests
    {
        [TestMethod]
        public void ThrowsArgumentException_Single()
        {
            // Arrange
            var counter = new ElfCalorieCounter();

            // Act
            Assert.Throws<ArgumentException>(() => counter.GetMaxCalorieCountOfSingleElf(null!));
            Assert.Throws<ArgumentException>(() => counter.GetMaxCalorieCountOfSingleElf(string.Empty));
        }

        [TestMethod]
        public void ThrowsArgumentException_Top()
        {
            // Arrange
            var counter = new ElfCalorieCounter();

            // Act
            Assert.Throws<ArgumentException>(() => counter.GetSumCaloriesOfTopElves(null!, 3));
            Assert.Throws<ArgumentException>(() => counter.GetSumCaloriesOfTopElves(string.Empty, 3));
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

        [TestMethod]
        public void GetSumCaloriesOfTopElvesTest()
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
            int maxCount = counter.GetSumCaloriesOfTopElves(content, 3);

            // Assert
            Assert.AreEqual(45000, maxCount);
        }
    }
}