using System.Collections.Immutable;
using System.ComponentModel;
using System.Numerics;
using Mmr.Aoc.Common.Models;
using System.Drawing;

namespace Mmr.Aoc.Common;

public class Reader
{
    public string _filePath;

    public string FilePath
    {
        get { return _filePath; }
        set { _filePath = value; }
    }

    private string Content = null;
    private string[] ContentLines = null;

    public Reader(string filePath, bool readOnInit = true)
    {
        this.FilePath = filePath;
        if (readOnInit)
        {
            ReadAndGetLines();
        }
    }

    public char[][] ReadAsMatrix()
    {
        return ReadAndGetLines().Select(x => x.ToCharArray()).ToArray();
    }
    
    public ImmutableSortedDictionary<Coordinate, MetrixCell<T>>? ReadAsMetrix<T>(IEnumerable<T>? ignoreItems = null) where T : IComparable
    {
        var inputMap = ReadAndGetLines().Select(x => x.ToCharArray()).ToArray();
        var map = Enumerable.Range(0, inputMap[0].Length)
            .SelectMany(x => Enumerable.Range(0, inputMap.Length),
                (column, row) =>
                {
                    var cell = new MetrixCell<T>(row, column, ConvertOrDefault<T>(inputMap[column][row].ToString()));
                    return new KeyValuePair<Coordinate, MetrixCell<T>>(cell.Coordinate, cell);
                });

        if (ignoreItems?.Any() == true)
        {
            map = map.Where(kvp => !ignoreItems.Contains(kvp.Value.Value));
        }

        return map.ToImmutableSortedDictionary();
    }
    
    
    /// <summary>
    /// The key represent coordinates of the cell.
    /// Real value == X and imaginary is Y
    /// </summary>
    public ImmutableDictionary<Complex, ComplexCell<T>> ReadAsComplex<T>(IEnumerable<T>? ignoreItems = null, IComparer<Complex> comparer = null)
        where T : IComparable
    {
        var inputMap = ReadAndGetLines().Select(x => x.ToCharArray()).ToArray();
        var map = Enumerable.Range(0, inputMap[0].Length)
            .SelectMany(x => Enumerable.Range(0, inputMap.Length),
                (column, row) =>
                {
                    var cell = new ComplexCell<T>(row, column, ConvertOrDefault<T>(inputMap[column][row].ToString()));
                    return new KeyValuePair<Complex, ComplexCell<T>>(cell.Coordinate, cell);
                });

        if (ignoreItems?.Any() == true)
        {
            map = map.Where(kvp => !ignoreItems.Contains(kvp.Value.Value));
        }

        return map.ToImmutableDictionary();
    }

    public string ReadAll()
    {
        if (Content == null)
            Content = File.ReadAllText(_filePath);
        return Content;
    }

    public string ReadAllWithoutR()
    {
        return ReadAll().Replace("\r", "");
    }

    public string GetContent()
    {
        return Content;
    }

    public string[] ReadAndGetLines()
    {
        if (ContentLines == null)
        {
            Content = File.ReadAllText(_filePath);
            ContentLines = Content.Replace("\r", "").Split('\n');
        }

        return ContentLines;
    }

    public T[] ReadAndGetLines<T>(bool removeEmpty = true)
    {
        if (ContentLines == null)
        {
            Content = File.ReadAllText(_filePath);
            ContentLines = Content.Replace("\r", "").Split('\n');
        }

        T[] contentAsT = new T[ContentLines.Length];
        for (int i = 0; i < ContentLines.Length; i++)
        {
            if (ContentLines[i] == "" && removeEmpty) continue;
            contentAsT[i] = ConvertOrDefault<T>(ContentLines[i]);
        }

        return contentAsT;
    }

    private T? ConvertOrDefault<T>(string input)
    {
        try
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T?)converter.ConvertFromString(input);
        }
        catch (NotSupportedException)
        {
            return default;
        }
    }

    public void Clear()
    {
        Content = null;
        ContentLines = null;
    }

    public static string CurrentDir(string append = "")
    {
        append = (
            append.StartsWith("/") || append.StartsWith("\\") || append == ""
                ? append
                : Path.DirectorySeparatorChar + append
        );
        return Directory.GetCurrentDirectory() + append;
    }
}