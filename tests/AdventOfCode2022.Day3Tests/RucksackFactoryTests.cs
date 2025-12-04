namespace AdventOfCode2022.Day3.Tests
{
    [TestClass()]
    public class RucksackFactoryTests
    {
        [TestMethod()]
        public void ThrowsArgumentNullException_StringIntersecter()
        {
            Assert.Throws<ArgumentNullException>(() => new RucksackFactory(null!));
        }
    }
}