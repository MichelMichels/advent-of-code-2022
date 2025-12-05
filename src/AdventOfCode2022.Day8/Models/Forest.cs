namespace AdventOfCode2022.Day8.Models;

public struct Forest(int width, int height)
{
    private readonly int[,] _layout = new int[width, height];
    private readonly int _width = width;
    private readonly int _height = height;

    public readonly int Width => _width;
    public readonly int Height => _height;

    public readonly int Get(int x, int y)
    {
        return _layout[x, y];
    }
    public readonly void Set(int x, int y, int value)
    {
        _layout[x, y] = value;
    }
}
