using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day4.Tests
{
    [TestClass()]
    public class DoubleAssignmentCheckerTests
    {
        [TestMethod()]
        [DataRow(5, 5, 4, 6)]
        [DataRow(4, 6, 5, 5)]
        public void IsDoubleAssignedTest(int startOne, int endOne, int startTwo, int endTwo)
        {
            var pair = new ElfPair(new Range(startOne, endOne), new Range(startTwo, endTwo));

            var checker = new DoubleAssignmentChecker();
            var result = checker.IsDoubleAssigned(pair);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        [DataRow(2, 3, 7, 9)]
        [DataRow(1, 1, 5, 5)]
        public void IsNotDoubleAssignedTest(int startOne, int endOne, int startTwo, int endTwo)
        {
            var pair = new ElfPair(new Range(startOne, endOne), new Range(startTwo, endTwo));

            var checker = new DoubleAssignmentChecker();
            var result = checker.IsDoubleAssigned(pair);

            Assert.IsFalse(result);
        }
    }
}