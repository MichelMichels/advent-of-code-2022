using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day3;
using System;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3.Tests
{
    [TestClass()]
    public class RucksackTests
    {
        private Mock<IStringIntersecter> mockedStringIntersecter = new();
        
        [TestInitialize]
        public void TestInitialize()
        {
            mockedStringIntersecter = new();
        }

        [TestMethod()]
        public void ThrowsNullreferenceException_Fill()
        {
            // Arrange
            var rucksack = new Rucksack(mockedStringIntersecter.Object, 0);

            // Act

            // Assert
            Assert.ThrowsException<NullReferenceException>(() => rucksack.Fill(null));
        }

        [TestMethod]
        public void ConstructorTest()
        {
            // Arrange
            var rucksack = new Rucksack(mockedStringIntersecter.Object, 2);

            // Act

            // Assert
            Assert.AreEqual(2, rucksack.Compartments.Length);
        }

        [TestMethod]
        [DataRow("1234", "12", "34")]
        [DataRow("vJrwpWtwJgWrhcsFMMfFFhFp", "vJrwpWtwJgWr", "hcsFMMfFFhFp")]
        public void Fill_Size_2_Test(string input, string one, string two)
        {
            // Arrange
            var rucksack = new Rucksack(mockedStringIntersecter.Object, 2);

            // Act
            rucksack.Fill(input);

            // Assert
            Assert.AreEqual(one, rucksack.Compartments[0]);
            Assert.AreEqual(two, rucksack.Compartments[1]);
        }

        [TestMethod]
        public void Fill_Size_3_Test()
        {
            // Arrange
            var rucksack = new Rucksack(mockedStringIntersecter.Object, 3);

            // Act
            rucksack.Fill("123456");

            // Assert
            Assert.AreEqual("12", rucksack.Compartments[0]);
            Assert.AreEqual("34", rucksack.Compartments[1]);
            Assert.AreEqual("56", rucksack.Compartments[2]);
        }

        [TestMethod]
        [DataRow("vJrwpWtwJgWrhcsFMMfFFhFp", "p")]
        [DataRow("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "L")]
        [DataRow("PmmdzqPrVvPwwTWBwg", "P")]
        [DataRow("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "v")]
        [DataRow("ttgJtRGJQctTZtZT", "t")]
        [DataRow("CrZsJsPPZsGzwwsLwLmpwMDw", "s")]
        public void GetSharedItemTypes_Test(string content, string sharedItemTypes)
        {
            // Arrange
            IRucksack rucksack = new Rucksack(new StringIntersecter(), 2);

            // Act
            rucksack.Fill(content);
            var result = rucksack.GetSharedItemTypes();

            // Assert
            Assert.AreEqual(sharedItemTypes, result);
        }
    }
}