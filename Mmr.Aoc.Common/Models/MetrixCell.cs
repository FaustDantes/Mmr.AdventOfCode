using System.Drawing;
using System.Numerics;

namespace Mmr.Aoc.Common.Models;

public class MetrixCell<T>
{
    public Point Coordinate { get; }
    public T Value { get; }

    public MetrixCell(int x, int y, T value)
    {
        Coordinate = new Point(x, y);
        Value = value;
    }
    
    /// <summary>
    /// Distance between two points calculated with Pythagorean Theorem.
    /// </summary>
    public double DistanceTo(MetrixCell<T> destination)
    {
        return Math.Round(
            Math.Sqrt(Math.Pow((destination.Coordinate.X - Coordinate.X), 2) +
                      Math.Pow((destination.Coordinate.Y - Coordinate.Y), 2))
            , 1);
    }

    public (int xDelta, int yDelta) CalculateCoordinateDelta(MetrixCell<T> destination)
    {
        return (Math.Abs(Coordinate.X - destination.Coordinate.X), Math.Abs(Coordinate.Y - destination.Coordinate.Y));
    }

    /// <summary>
    /// Integer distance between two points. For example between point A[6,5] and B[9,9] is distance 5 but metrix distance is 3.
    /// This is basically length of side a of triangle with 90-degree angle and two equal sides (a, a, c). Equation is than c = a * sqrt(2)  
    /// </summary>
    public int MetrixDistanceTo(MetrixCell<T> destination)
    {
        return (int)Math.Round(DistanceTo(destination) / Math.Sqrt(2), 0);
    }

    public override string ToString()
    {
        return $"Cell: '{Value}' on coordinate [{Coordinate.X}, {Coordinate.Y}]";
    }
}

public class ComplexCell<T>
{
    public Complex Coordinate { get; }
    public T Value { get; set; }

    /// <summary>
    /// Define complex metrix
    /// </summary>
    /// <param name="x">real part</param>
    /// <param name="y">imaginary</param>
    /// <param name="value"></param>
    public ComplexCell(int x, int y, T value)
    {
        Coordinate = new Complex(x, y);
        Value = value;
    }
    
    /// <summary>
    /// Define complex metrix
    /// </summary>
    public ComplexCell(Complex coordinate, T value)
    {
        Coordinate = coordinate;
        Value = value;
    }
    
    /// <summary>
    /// Distance between two points
    /// </summary>
    public Complex DistanceTo(ComplexCell<T> destination)
    {
        return Coordinate - destination.Coordinate;
    }
    
    public override string ToString()
    {
        return $"Cell: '{Value}' on coordinate [{Coordinate.Real}, {Coordinate.Imaginary}]";
    }
}
