namespace AdventOfCode2022.Shared
{
    public class InputParser : IInputParser
    {
        private readonly IStringSplitter stringSplitter;

        public InputParser(IStringSplitter stringSplitter)
        {
            this.stringSplitter = stringSplitter ?? throw new ArgumentNullException(nameof(stringSplitter));
        }

        public string[] ParseString(string content)
        {
            return stringSplitter.Split(content);
        }

        public string[] ParseTextFile(string inputFilePath)
        {
            if (string.IsNullOrEmpty(inputFilePath))
            {
                throw new ArgumentException("Can't process empty file path.", nameof(inputFilePath));
            }

            var text = File.ReadAllText(inputFilePath);
            return stringSplitter.Split(text);
        }
    }
}
