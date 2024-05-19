using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7.Tests
{
    [TestClass()]
    public class DirectoryTests
    {
        [TestMethod()]
        public void DirectoryTest()
        {
            // Arrange
            var directory = new Directory("dir");

            // Act
            var name = directory.Name;

            // Assert
            Assert.AreEqual("dir", name);
        }

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var directory = new Directory("test");

            // Act
            directory.Add(new File("test.txt", 1024));

            // Assert
            Assert.AreEqual(1, directory.Children.Count);
            Assert.AreEqual(1024, directory.Size);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            var directory = new Directory("test");
            directory.Add(new File("test.txt", 1024));

            // Act
            var toString = directory.ToString();

            var expected = """
                - test (dir)
                  - test.txt (file, size=1024)
                """;

            // Assert
            Assert.AreEqual(expected, toString);
        }
    }
}