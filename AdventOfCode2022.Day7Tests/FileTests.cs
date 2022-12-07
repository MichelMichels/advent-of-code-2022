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
    public class FileTests
    {
        [TestMethod()]
        public void FileToString()
        {
            // Arrange
            var file = new File("input.txt", 1024);

            // Act
            var toString = file.ToString();

            // Assert
            Assert.AreEqual("- input.txt (file, size=1024)", toString);
        }
    }
}