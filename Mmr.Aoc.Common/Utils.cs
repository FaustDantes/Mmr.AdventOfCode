using System.Numerics;
using System.Text.RegularExpressions;
using Mmr.Aoc.Common.Models;

namespace Mmr.Aoc.Common;

public static class Utils
{
    private const RegexOptions Options = RegexOptions.Compiled;
    private static readonly Regex NumberRegex = new(pattern: @"(-?\d+)", Options);
    
    /// <summary>
    ///     Parse the provided string, returning the first found number.
    /// </summary>
    /// <param name="s">The string to parse</param>
    /// <typeparam name="T">The type of number to parse</typeparam>
    /// <returns>The first parsed number</returns>
    /// <exception cref="FormatException">When at least one number cannot be parsed</exception>
    public static T ParseNumber<T>(this string s) where T : INumber<T>
    {
        var numbers = ParseNumbers<T>(s);
        return numbers.Length != 0
            ? numbers[0]
            : throw new FormatException($"Invalid number format [{s}]");
    }
    public static T[] ParseNumbers<T>(this string s) where T : INumber<T>
    {
        return NumberRegex.Matches(s)
            .Select(m => T.Parse(s: m.Value.AsSpan(), provider: null))
            .ToArray();
    }
    
    public static int AsDigit(this char c)
    {
        return c - '0';
    }
    
    public static long Multiply(this IEnumerable<long> list)
    {
        return list.Aggregate((a, x) => a * x);
    }

    public static long Concate(this long a, long b)
    {
        return long.Parse(a + "" + b);
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

    public static bool IsInMatrix<T>(this ComplexCell<T> item, IDictionary<Complex, ComplexCell<T>>? matrix)
    {
        if (matrix == null)
        {
            return false;
        }

        return matrix.ContainsKey(item.Coordinate); 
    }
    
    public static bool IsInMatrix<T>(this Complex item, IDictionary<Complex, ComplexCell<T>>? matrix)
    {
        if (matrix == null)
        {
            return false;
        }

        return matrix.ContainsKey(item); 
    }

    public static void PrintMatrix<T>(this IDictionary<Complex, ComplexCell<T>>? matrix)
    {
        if (matrix == null)
        {
            Console.WriteLine("Matrix is null.");
            return;
        }

        var rows = matrix
            .GroupBy(item => item.Key.Imaginary)
            .OrderBy(group => group.Key);

        Console.WriteLine("---" + string.Join(" ", Enumerable.Range(0, rows.Count())));

        foreach (var group in rows)
        {
            var row = group.OrderBy(item => item.Key.Real)
                .Select(item => item.Value.Value);

            Console.Write((int)group.Key + "> ");
            foreach (var value in row)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Changes both coordinates of cell.
    /// </summary>
    public static MetrixCell<T> CreateShiftCell<T>(MetrixCell<T> cell, (int xDelta, int yDelta) delta)
    {
        return new MetrixCell<T>(cell.Coordinate.X + delta.xDelta, cell.Coordinate.Y + delta.yDelta, cell.Value);
    }
}