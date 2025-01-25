using System.Numerics;

namespace Mmr.Aoc2024.Days;

public class Day08B : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var inputMap = reader.ReadAsComplex<char>();
        var calculatedPoints = new HashSet<Complex>();

        var antenaGroups = inputMap.Where(kvp => kvp.Value.Value != '.')
            .GroupBy(x => x.Value.Value)
            .Select(g => g.Select(s => s.Value)
                .ToArray());

        foreach (var antenas in antenaGroups)
        {
            if (antenas.Count() == 1) continue;
            int i = 1;
            foreach (var sourceAntena in antenas)
            {
                calculatedPoints.Add(sourceAntena.Coordinate);
                for (int destIdx = i; destIdx < antenas.Length; destIdx++)
                {
                    var destinationAntena = antenas[destIdx];
                    var delta = sourceAntena.Coordinate - destinationAntena.Coordinate;

                    var antinode = sourceAntena.Coordinate - delta;
                    while (antinode.IsInMatrix(inputMap))
                    {
                        calculatedPoints.Add(antinode);
                        antinode = antinode - delta;
                    }

                    antinode = destinationAntena.Coordinate + delta;
                    while (antinode.IsInMatrix(inputMap))
                    {
                        calculatedPoints.Add(antinode);
                        antinode = antinode + delta;
                    }
                }

                i++;
            }
        }

        Result = calculatedPoints.Count();
    }
}