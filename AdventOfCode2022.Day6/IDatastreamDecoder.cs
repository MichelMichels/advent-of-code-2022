using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day6
{
    public interface IDatastreamDecoder
    {
        DecodedData DecodeStartOfPacket(string datastream);
        DecodedData DecodeStartOfMessage(string datastream);
    }
}
