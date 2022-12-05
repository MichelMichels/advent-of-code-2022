namespace AdventOfCode2022.Day4
{
    public class ElfPairParser : IElfPairParser
    {
        private const char rangeSeparator = ',';
        private const char indexSeparator = '-';

        public ElfPair Parse(string input)
        {
            var ranges = input.Split(rangeSeparator);                                   
            return new ElfPair(ParseRange(ranges[0]), ParseRange(ranges[1]));            
        }

        private Range ParseRange(string range)
        {
            var parts = range.Split(indexSeparator);
            return new Range(int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
}
