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
    public class FileSystemTests
    { 
        [TestMethod()]
        public void AddDirectory()
        {
            // Arrange
            var fs = new FileSystem("/");

            // Act
            fs.Add(new Directory("path"));

            // Assert
            Assert.AreEqual(1, fs.Children.Count);
        }

        [TestMethod()]
        public void AddFile()
        {
            // Arrange
            var fs = new FileSystem("/");

            // Act
            fs.Add(new File("test.txt", 100));

            // Assert
            Assert.AreEqual(1, fs.Children.Count);
            Assert.AreEqual(100, fs.Size);
        }
    }
}