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
    public class CrateMover9001Tests
    {
        [TestMethod()]
        public void RearrangeTest()
        {
            // Arrange
            var crane = new CrateMover9001();

            var crateStacks = new CrateStack[]
            {
                new CrateStack(),
                new CrateStack(),
            };
            crateStacks[0].Push('B');
            crateStacks[0].Push('A');

            var procedures = new RearrangementProcedure[]
            {
                new RearrangementProcedure(2, 1, 2),
            };
            var instruction = new Instruction(crateStacks, procedures);

            // Act
            crane.Rearrange(instruction);

            // Assert
            Assert.AreEqual('A', crateStacks[1].Pop());
            Assert.AreEqual('B', crateStacks[1].Pop());            
        }
    }
}