using AdventOfCode2022.Day9.Models;

namespace AdventOfCode2022.Day9.Services;

public interface IRopeMover
{
    void Move(Rope rope, Motion motion);
}
