using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day3
{
    public class ElfStorageRoom : IElfStorageRoom
    {
        private readonly IPriorityCalculator priorityCalculator;
        private readonly IRucksackFactory rucksackFactory;
        private readonly IStringIntersecter stringIntersecter;
        private readonly IStringSplitter stringSplitter;

        public ElfStorageRoom(
            IPriorityCalculator priorityCalculator,
            IRucksackFactory rucksackFactory,
            IStringIntersecter stringIntersecter,
            IStringSplitter stringSplitter)
        {
            this.priorityCalculator = priorityCalculator ?? throw new ArgumentNullException(nameof(priorityCalculator));
            this.rucksackFactory = rucksackFactory ?? throw new ArgumentNullException(nameof(rucksackFactory));
            this.stringIntersecter = stringIntersecter ?? throw new ArgumentNullException(nameof(stringIntersecter));
            this.stringSplitter = stringSplitter ?? throw new ArgumentNullException(nameof(stringSplitter));
        }

        public int CalculatePriorityOfSingleRucksacks(string content)
        {
            return ParseRucksacks(content)
                .Select(x => x.GetSharedItemTypes())
                .Select(priorityCalculator.CalculatePriority)
                .Sum();
        }

        public int CalculatePriorityOfThreeElfGroupRucksacks(string content)
        {
            int score = 0;
            var rucksacks = ParseRucksacks(content);

            var chunkedRucksacks = rucksacks.Chunk(3);
            foreach (var group in chunkedRucksacks)
            {
                var groupContent = group
                    .Select(x => string.Join("", x.Compartments))
                    .ToArray();

                var sharedItemTypePerGroup = stringIntersecter.Intersect(groupContent);
                if (!string.IsNullOrEmpty(sharedItemTypePerGroup))
                {
                    score += priorityCalculator.CalculatePriority(sharedItemTypePerGroup);
                }
            }

            return score;
        }

        private List<IRucksack> ParseRucksacks(string content)
        {
            List<IRucksack>? result = new List<IRucksack>();

            var lines = stringSplitter.Split(content);
            foreach (var line in lines)
            {
                var rucksack = rucksackFactory.Create(line, 2);
                result.Add(rucksack);
            }

            return result;
        }
    }
}
