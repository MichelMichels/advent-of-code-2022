using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3.Tests
{
    [TestClass()]
    public class RucksackFactoryTests
    {
        [TestMethod()]
        public void ThrowsArgumentNullException_StringIntersecter()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new RucksackFactory(null));
        }
    }
}