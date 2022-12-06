namespace AdventOfCode2022.Day6
{
    public class DatastreamDecoder : IDatastreamDecoder
    {
        public DecodedData DecodeStartOfPacket(string datastream) => Decode(datastream, 4);
        public DecodedData DecodeStartOfMessage(string datastream) => Decode(datastream, 14);

        private DecodedData Decode(string datastream, int markerCount)
        {
            var chars = new HashSet<char>();
            int currentStartIndex = 0;
            for (int i = 0; i < datastream.Length; i++)
            {
                var currentCharCount = chars.Count;

                char c = datastream[i];
                chars.Add(c);

                if (chars.Count == currentCharCount)
                {
                    chars.Clear();
                    i = currentStartIndex;
                    currentStartIndex++;
                    continue;
                }

                if (chars.Count == markerCount)
                {
                    break;
                }
            }

            return new DecodedData(currentStartIndex + markerCount, new string(chars.ToArray()));
        }
    }
}
