using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day6
{
    public class Day6Solver : BaseChallengeSolver
    {
        private readonly IDatastreamDecoder datastreamDecoder;

        private string stream = string.Empty;

        public Day6Solver(
            IInputParser inputParser,
            IDatastreamDecoder datastreamDecoder,
            IMessageWriter messageWriter) : base(messageWriter, inputParser)
        {
            this.datastreamDecoder = datastreamDecoder ?? throw new ArgumentNullException(nameof(datastreamDecoder));
        }

        public override int DayNumber => 6;

        protected override void AfterParsing()
        {
            stream = parsed.First();
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
