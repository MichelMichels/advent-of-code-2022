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

        public string[] ParseTextFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Can't process empty file path.", nameof(filePath));
            }

            if(!File.Exists(filePath))
            {
                throw new ArgumentException("File does not exist.", nameof(filePath));
            }

            var text = File.ReadAllText(filePath);
            return stringSplitter.Split(text);
        }
    }
}
