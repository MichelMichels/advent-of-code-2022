using AdventOfCode2022.Day8.Models;
using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day8;

public class Day8Solver(IMessageWriter messageWriter, IInputParser inputParser) : BaseChallengeSolver(messageWriter, inputParser)
{
    public override int DayNumber => 8;

    protected override void SolvePartOne()
    {
        int width = parsed.First().Length;
        int height = parsed.Length;

        Forest forest = new(width, height);

        for (int y = 0; y < height; y++)
        {
            string line = parsed[y];

            for (int x = 0; x < width; x++)
            {
                forest.Set(x, y, int.Parse(line[x].ToString()));
            }
        }

        int visibleCounter = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (IsTreeVisible(forest, x, y))
                {
                    visibleCounter++;
                }
            }
        }

        messageWriter.WriteAnswer($"Visible trees: {visibleCounter}");
    }

    protected override void SolvePartTwo()
    {
        int width = parsed.First().Length;
        int height = parsed.Length;

        Forest forest = new(width, height);

        for (int y = 0; y < height; y++)
        {
            string line = parsed[y];

            for (int x = 0; x < width; x++)
            {
                forest.Set(x, y, int.Parse(line[x].ToString()));
            }
        }

        List<int> scenicScores = [];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int score = CalculateScenicScore(forest, x, y);
                scenicScores.Add(score);
            }
        }

        messageWriter.WriteAnswer($"Max scenic score: {scenicScores.Max()}");
    }

    private bool IsTreeVisible(Forest forest, int x, int y)
    {
        List<int> row = [];
        List<int> column = [];

        for (int i = 0; i < forest.Width; i++)
        {
            row.Add(forest.Get(i, y));
        }
        for (int i = 0; i < forest.Height; i++)
        {
            column.Add(forest.Get(x, i));
        }

        if (x == 0 || y == 0 || x == forest.Width - 1 || y == forest.Height - 1)
        {
            return true;
        }

        // Look up
        List<int> up = [];
        for (int i = 0; i < y; i++)
        {
            up.Add(forest.Get(x, i));
        }
        if (up.Max() < forest.Get(x, y))
        {
            return true;
        }

        // Look down
        List<int> down = [];
        for (int i = forest.Height - 1; i > y; i--)
        {
            down.Add(forest.Get(x, i));
        }
        if (down.Max() < forest.Get(x, y))
        {
            return true;
        }

        // Look right
        List<int> right = [];
        for (int i = forest.Width - 1; i > x; i--)
        {
            right.Add(forest.Get(i, y));
        }
        if (right.Max() < forest.Get(x, y))
        {
            return true;
        }

        // Look left
        List<int> left = [];
        for (int i = 0; i < x; i++)
        {
            left.Add(forest.Get(i, y));
        }
        if (left.Max() < forest.Get(x, y))
        {
            return true;
        }

        return false;
    }
    private int CalculateScenicScore(Forest forest, int x, int y)
    {
        List<int> row = [];
        List<int> column = [];

        int currentTreeHeight = forest.Get(x, y);

        for (int i = 0; i < forest.Width; i++)
        {
            row.Add(forest.Get(i, y));
        }
        for (int i = 0; i < forest.Height; i++)
        {
            column.Add(forest.Get(x, i));
        }

        // Look up
        int visibleUp = 0;
        List<int> up = [];
        for (int i = 0; i < y; i++)
        {
            up.Add(forest.Get(x, i));
        }
        up.Reverse();
        int maxUp = 0;
        foreach (int treeHeight in up)
        {
            visibleUp++;

            if (treeHeight >= currentTreeHeight)
            {
                break;
            }
        }

        // Look down
        int visibleDown = 0;
        List<int> down = [];
        for (int i = forest.Height - 1; i > y; i--)
        {
            down.Add(forest.Get(x, i));
        }
        down.Reverse();
        int maxDown = 0;
        foreach (int treeHeight in down)
        {
            visibleDown++;

            if (treeHeight >= currentTreeHeight)
            {
                break;
            }
        }

        // Look right
        int visibleRight = 0;
        List<int> right = [];
        for (int i = forest.Width - 1; i > x; i--)
        {
            right.Add(forest.Get(i, y));
        }
        right.Reverse();
        foreach (int treeHeight in right)
        {
            visibleRight++;

            if (treeHeight >= currentTreeHeight)
            {
                break;
            }
        }

        // Look left
        int visibleLeft = 0;
        List<int> left = [];
        for (int i = 0; i < x; i++)
        {
            left.Add(forest.Get(i, y));
        }
        left.Reverse();
        int maxLeft = 0;
        foreach (int treeHeight in left)
        {
            visibleLeft++;

            if (treeHeight >= currentTreeHeight)
            {
                break;
            }
        }

        return visibleUp * visibleDown * visibleLeft * visibleRight;
    }
}
