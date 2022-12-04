using 
    System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
    public class Rucksack : IRucksack
    {
        private readonly IStringIntersecter stringIntersecter;
        private readonly string[] compartments;

        public Rucksack(IStringIntersecter stringIntersecter, int size)
        {
            this.stringIntersecter = stringIntersecter ?? throw new ArgumentNullException(nameof(stringIntersecter));
            
            compartments = new string[size];
        }

        public string[] Compartments => compartments;

        public void Fill(string content)
        {
            if (content == null)
            {
                throw new NullReferenceException();
            }

            var partCharacterCount = content.Length / compartments.Length;
            for (int i = 0; i < compartments.Length; i++)
            {
                compartments[i] = content.Substring(i * partCharacterCount, partCharacterCount);
            }
        }

        public string GetSharedItemTypes() => stringIntersecter.Intersect(Compartments);
    }
}
