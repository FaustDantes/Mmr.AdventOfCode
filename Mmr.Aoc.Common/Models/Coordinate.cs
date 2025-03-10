namespace Mmr.Aoc.Common.Models;


// TODO delete 
public class Coordinate : IEquatable<Coordinate>, IComparable
{
    public int X { get; set; }
    public int Y { get; set; }
 
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Equals(Coordinate other)
    {
        if (other is null) return false;
        return X == other.X && Y == other.Y;
    }
    public override bool Equals(object obj)
    {
        return obj is Coordinate coordinate && Equals(coordinate);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
    public static bool operator ==(Coordinate a, Coordinate b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }
    public static bool operator !=(Coordinate a, Coordinate b)
    {
        return !(a == b);
    }
    
    /// <summary>
    /// First compare X values if they are equal than compare Y.
    /// </summary>
    public int CompareTo(object? obj)
    {
        var coordinate = obj as Coordinate;
        if (coordinate is null) return 1;
        if (X < coordinate.X ) return -1;
        if (X > coordinate.X ) return 1;

        if (X == coordinate.X )
        {
            if (Y < coordinate.Y ) return -1;
            if (Y > coordinate.Y ) return 1;
        }

        return 0;
    }
}