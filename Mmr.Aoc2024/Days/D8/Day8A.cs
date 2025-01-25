using System.Numerics;

namespace Mmr.Aoc2024.Days;

public class Day08A : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var inputMap = reader.ReadAsComplex<char>();
        var calculatedPoints = new List<Complex>();

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
                for (int idx = i; idx < antenas.Length; idx++)
                {
                    var upDelta = sourceAntena.Coordinate - antenas[idx].Coordinate;
                    var upAntinode = sourceAntena.Coordinate + upDelta;
                    if (inputMap.Keys.Contains(upAntinode))
                    {
                        calculatedPoints.Add(upAntinode);
                    }

                    var downDelta = antenas[idx].Coordinate - sourceAntena.Coordinate;
                    var downAntinode = antenas[idx].Coordinate + downDelta;
                    if (inputMap.Keys.Contains(downAntinode))
                    {
                        calculatedPoints.Add(downAntinode);
                    }
                }

                i++;
            }
        }

        Result = calculatedPoints.Distinct().Count();
    }
}