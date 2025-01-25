using System.Collections.Immutable;
using System.Drawing;
using Mmr.Aoc.Common.Models;

namespace Mmr.Aoc2024.Days;

public class Day09A : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var inputMap = reader.ReadAsMatrix();
        var calculatedPoints = new List<Point>();

        var rows = inputMap.Length;
        var columns = inputMap[0].Length;

        var map = Enumerable.Range(0, columns)
            .SelectMany(x => Enumerable.Range(0, rows),
                (column, row) =>
                {
                    var cell = Utils.CreateCell(row, column, inputMap[column][row]);
                    return new KeyValuePair<Point, MetrixCell<char>>(cell.Coordinate, cell);
                })
            .Where(kvp => kvp.Value.Value != '.')
            .ToImmutableDictionary();

        Console.WriteLine("---------------------");
        
        var localC = new List<Point>(); 
        var antenaGroups = map.GroupBy(x => x.Value.Value).Select(g => g.Select(s => s.Value).ToArray());
        foreach (var antenas in antenaGroups)
        {
            // Console.WriteLine($"--------antenas {antenas.First().Value}-------------");
            if (antenas.Count() == 1) continue;
            int i = 1;
            foreach (var antena in antenas)
            {
                //  Console.WriteLine("Comparing with N: " + (antenas.Length - i));
                for (int idx = i; idx < antenas.Length; idx++)
                {
                    var delta = antena.CalculateCoordinateDelta(antenas[idx]);
//                    Console.WriteLine($"Comparing: \n{antena}\n{antenas[idx]}");
                    Point topNode;
                    Point bottomNode;

                    if (antena.Coordinate.X < antenas[idx].Coordinate.X)
                    {
                        topNode = new Point(antena.Coordinate.X - delta.xDelta, 0);
                        bottomNode = new Point(antenas[idx].Coordinate.X + delta.xDelta, 0);
                    }
                    else
                    {
                        topNode = new Point(antenas[idx].Coordinate.X - delta.xDelta, 0);
                        bottomNode = new Point(antena.Coordinate.X + delta.xDelta, 0);
                    }

                    if (antena.Coordinate.Y < antenas[idx].Coordinate.Y)
                    {
                        topNode.Y = antena.Coordinate.Y - delta.yDelta;
                        bottomNode.Y = antenas[idx].Coordinate.Y + delta.yDelta;
                    }
                    else
                    {
                        topNode.Y = antenas[idx].Coordinate.Y - delta.yDelta;
                        bottomNode.Y = antena.Coordinate.Y + delta.yDelta;
                    }

                    if (!map.Where(x => x.Key == topNode && x.Value.Value == antena.Value).Any())
                    {
                        localC.Add(topNode);
                    }
                    if (!map.Where(x => x.Key == bottomNode && x.Value.Value == antena.Value).Any())
                    {
                        localC.Add(bottomNode);
                    }
                }

                i++;
            }
            calculatedPoints.AddRange(localC.Distinct());
            localC.Clear();
        }

        Result = calculatedPoints.Count(cp => cp.X >= 0 && cp.X < columns && cp.Y >= 0 && cp.Y < rows);
    }
}