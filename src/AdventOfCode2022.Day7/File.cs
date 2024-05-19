namespace AdventOfCode2022.Day7
{
    public class File : IFileSystemEntry
    {
        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public string Name { get; }
        public int Size { get; }

        public override string ToString()
        {
            return $"- {Name} (file, size={Size})";
        }
    }
}
