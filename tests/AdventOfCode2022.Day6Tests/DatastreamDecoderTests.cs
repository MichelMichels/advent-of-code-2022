using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2022.Day6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day6.Tests
{
    [TestClass()]
    public class DatastreamDecoderTests
    {
        [TestMethod()]
        [DataRow("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7, "jpqm")]
        [DataRow("bvwbjplbgvbhsrlpgdmjqwftvncz", 5, "vwbj")]
        [DataRow("nppdvjthqldpwncqszvftbrmjlhg", 6, "pdvj")]
        [DataRow("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10, "rfnt")]
        [DataRow("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11, "zqfr")]
        public void DecodeStartOfPacket(string input, int numberOfCharactersBeforeMarker, string marker)
        {
            // Arrange
            var decoder = new DatastreamDecoder();

            // Act 
            var result = decoder.DecodeStartOfPacket(input);

            // Assert
            Assert.AreEqual(marker, result.Marker);
            Assert.AreEqual(numberOfCharactersBeforeMarker, result.NumberOfCharactersBeforeMarker);
        }

        [TestMethod()]
        [DataRow("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [DataRow("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [DataRow("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [DataRow("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [DataRow("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void DecodeStartOfMessage(string input, int numberOfCharactersBeforeMarker)
        {
            // Arrange
            var decoder = new DatastreamDecoder();

            // Act 
            var result = decoder.DecodeStartOfMessage(input);

            // Assert
            Assert.AreEqual(numberOfCharactersBeforeMarker, result.NumberOfCharactersBeforeMarker);
        }
    }
}