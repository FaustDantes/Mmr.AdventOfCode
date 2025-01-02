namespace Mmr.Aoc2024.Days;

public class Guard
{
    private Guard(int xStart, int yStart)
    {
        PositionX = xStart;
        PositionY = yStart;
        StartPositionX = xStart;
        StartPositionY = yStart;
        StepCount = 0;
    }

    private const char InitialMarker = '^';
    public char Marker { get; set;} = InitialMarker;
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public Orientations Orientation { get; set; }
    public int StepCount { get; set; }
    public int StartPositionX { get; }
    public int StartPositionY { get; }

    public bool IsAtStartPosition()
    {
        return PositionX == StartPositionX && PositionY == StartPositionY;
    }
    
    public static Guard CreateFromMatrix(char[][] map)
    {
        var xStart = 0;
        var yStart = 0;

        for (var x = 0; x < map[0].Length; x++)
        {
            for (var y = 0; y < map.Length; y++)
            {
                if (map[x][y] != InitialMarker) continue;

                xStart = x;
                yStart = y;
                break;
            }
        }

        Console.WriteLine($"Guard position: {xStart}, {yStart}");
        var guard = new Guard(xStart, yStart);
        guard.Orientation = Orientations.Up;
        return guard;
    }

    public void Rotate()
    {
        switch (Orientation)
        {
            case Orientations.Up:
                Orientation = Orientations.Right;
                Marker = '>';
                break;
            case Orientations.Right:
                Orientation = Orientations.Down;
                Marker = 'v';
                break;
            case Orientations.Down:
                Orientation = Orientations.Left;
                Marker = '<';
                break;
            case Orientations.Left:
                Orientation = Orientations.Up;
                Marker = '^';
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum Orientations
{
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3
}