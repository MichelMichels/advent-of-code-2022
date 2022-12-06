using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day5.Tests
{
    [TestClass()]
    public class GiantCargoCraneTests
    {
        [TestMethod()]
        public void RearrangeTest()
        {
            // Arrange
            var crane = new GiantCargoCrane();

            var crateStacks = new CrateStack[]
            {
                new CrateStack(),
                new CrateStack(),
            };
            crateStacks[0].Push('B');
            crateStacks[0].Push('A');
            crateStacks[1].Push('C');

            var procedures = new RearrangementProcedure[]
            {
                new RearrangementProcedure(1, 2, 1),
            };
            var instruction = new Instruction(crateStacks, procedures);

            // Act
            crane.Rearrange(instruction);

            // Assert
            Assert.AreEqual('C', crateStacks[0].Pop());
            Assert.AreEqual('A', crateStacks[0].Pop());
            Assert.AreEqual('B', crateStacks[0].Pop());
        }
    }
}