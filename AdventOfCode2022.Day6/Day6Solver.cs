using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day6
{
    public class Day6Solver : BaseChallengeSolver
    {
        private readonly IInputParser inputParser;
        private readonly IDatastreamDecoder datastreamDecoder;

        private string stream = string.Empty;

        public Day6Solver(
            IInputParser inputParser,
            IDatastreamDecoder datastreamDecoder,
            IMessageWriter messageWriter) : base(messageWriter)
        {
            this.inputParser = inputParser ?? throw new ArgumentNullException(nameof(inputParser));
            this.datastreamDecoder = datastreamDecoder ?? throw new ArgumentNullException(nameof(datastreamDecoder));
        }

        public override int DayNumber => 6;

        protected override void BeforeSolvingParts(string filePath)
        {
            messageWriter.WriteMessage($"Parsing {filePath}...");
            stream = inputParser.ParseTextFile(filePath).First();

            messageWriter.WriteNewLine();
        }

        protected override void SolvePartOne()
        {           
            messageWriter.WriteMessage("Decoding stream...");
            var data = datastreamDecoder.DecodeStartOfPacket(stream);

            messageWriter.WriteAnswer($"The answer is {data.NumberOfCharactersBeforeMarker}.");                     
        }

        protected override void SolvePartTwo()
        {
            messageWriter.WriteMessage("Decoding stream...");
            var dataMessage = datastreamDecoder.DecodeStartOfMessage(stream);

            messageWriter.WriteAnswer($"The answer is {dataMessage.NumberOfCharactersBeforeMarker}.");
        }
    }
}
