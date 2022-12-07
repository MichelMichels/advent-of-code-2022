using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7
{
    public class Directory : IFileSystemEntry
    {
        private readonly List<IFileSystemEntry> children = new();

        public Directory(string name)
        {
            Name = name;            
        }
        public Directory(string name, Directory parent) : this(name)
        {
            Parent = parent;
        }

        public string Name { get; }
        public List<IFileSystemEntry> Children => children;
        public Directory? Parent { get; set; }
        public int Size => children.Sum(x => x.Size);   

        public void Add(IFileSystemEntry entry)
        {
            children.Add(entry);
        }

        public Directory? FindDirectory(string name)
        {
            if (this.Name == name)
            {
                return this;
            }
            else
            {
                foreach (var directory in Children.OfType<Directory>())
                {
                    var result = directory.FindDirectory(name);
                    if(result != null)
                    {
                        return result;
                    }
                }

                return null;
            }
        }
        public List<Directory> GetDirectoriesOfMaximumSize(int maximumSize, List<Directory> directories = null)
        {
            directories ??= new List<Directory>();

            if(Size <= maximumSize)
            {
                directories.Add(this);
            }

            foreach(var directory in children.OfType<Directory>())
            {
                directory.GetDirectoriesOfMaximumSize(maximumSize, directories);
            }

            return directories;
        }
        public List<Directory> GetAllDirectories()
        {
            var directories = new List<Directory>();
            directories.Add(this);

            foreach (var directory in children.OfType<Directory>())
            {
                directories.AddRange(directory.GetAllDirectories());
            }

            return directories;

        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"- {Name} (dir)");
            foreach(var child in children)
            {
                builder.AppendLine("  " + child.ToString());
            }            

            return builder.ToString().Trim();
        }
    }
}
