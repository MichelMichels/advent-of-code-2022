using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7
{
    public interface IFileSystemEntry
    {
        string Name { get; }
        int Size { get; }
    }
}
