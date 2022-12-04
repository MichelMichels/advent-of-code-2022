using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace AdventOfCode2022.Day3.Tests
{
    [TestClass()]
    public class ElfStorageRoomTests
    {
        [TestMethod]
        public void ThrowsArgumentNullExceptions()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ElfStorageRoom(null, new Mock<IRucksackFactory>().Object, new Mock<IStringIntersecter>().Object, new Mock<IStringSplitter>().Object));
            Assert.ThrowsException<ArgumentNullException>(() => new ElfStorageRoom(new Mock<IPriorityCalculator>().Object, null, new Mock<IStringIntersecter>().Object, new Mock<IStringSplitter>().Object));
            Assert.ThrowsException<ArgumentNullException>(() => new ElfStorageRoom(new Mock<IPriorityCalculator>().Object, new Mock<IRucksackFactory>().Object, null, new Mock<IStringSplitter>().Object));
            Assert.ThrowsException<ArgumentNullException>(() => new ElfStorageRoom(new Mock<IPriorityCalculator>().Object, new Mock<IRucksackFactory>().Object, new Mock<IStringIntersecter>().Object, null));
        }

        [TestMethod()]
        public void GetSumOfDuplicateItemTypesTest()
        {
            var input = """
                vJrwpWtwJgWrhcsFMMfFFhFp
                jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
                PmmdzqPrVvPwwTWBwg
                wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
                ttgJtRGJQctTZtZT
                CrZsJsPPZsGzwwsLwLmpwMDw
                """;

            var storageRoom = new ElfStorageRoom(new PriorityCalculator(), new RucksackFactory(new StringIntersecter()), new StringIntersecter(), new NewLineSplitter());
            var result = storageRoom.CalculatePriorityOfSingleRucksacks(input);

            Assert.AreEqual(157, result);
        }
        [TestMethod()]
        public void CalculatePriorityOfThreeElfGroupRucksacksTest()
        {
            var input = """
                vJrwpWtwJgWrhcsFMMfFFhFp
                jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
                PmmdzqPrVvPwwTWBwg
                wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
                ttgJtRGJQctTZtZT
                CrZsJsPPZsGzwwsLwLmpwMDw
                """;

            var storageRoom = new ElfStorageRoom(new PriorityCalculator(), new RucksackFactory(new StringIntersecter()), new StringIntersecter(), new NewLineSplitter());
            var result = storageRoom.CalculatePriorityOfThreeElfGroupRucksacks(input);

            Assert.AreEqual(70, result);
        }
    }
}