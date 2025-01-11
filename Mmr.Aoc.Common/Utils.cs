using Mmr.Aoc.Common.Models;

namespace Mmr.Aoc.Common;

public static class Utils
{
    public static readonly double Sqrt2 = Math.Sqrt(2);
    
    public static long Multiply(this IEnumerable<long> list)
    {
        return list.Aggregate((a, x) => a * x);
    }
    
    public static long Concate(this long a, long b)
    {
        return long.Parse(a+""+b);
    }
    
    public static MetrixCell<string> CreateCell(int x, int y, string value)
    {
        return new MetrixCell<string>(x, y, value);
    }
    
    public static MetrixCell<char> CreateCell(int x, int y, char value)
    {
        return new MetrixCell<char>(x, y, value);
    }
    
    public static MetrixCell<int> CreateCell(int x, int y, int value)
    {
        return new MetrixCell<int>(x, y, value);
    }
    
    /// <summary>
    /// Changes both coordinates of cell.
    /// </summary>
    public static MetrixCell<T> CreateShiftCell<T>(MetrixCell<T> cell, (int xDelta, int yDelta) delta)
    {
        return new MetrixCell<T>(cell.Coordinate.X + delta.xDelta, cell.Coordinate.Y + delta.yDelta, cell.Value);
    }
}