using System.Numerics;

namespace Mmr.Aoc2024.Days;

public class Day08B : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var inputMap = reader.ReadAsComplex<char>();
        var debugMap = reader.ReadAsComplex<char>().ToDictionary();
        
        var calculatedPoints = new HashSet<Complex>();

        var antenaGroups = inputMap.Where(kvp => kvp.Value.Value != '.')
            .GroupBy(x => x.Value.Value)
            .Select(g => g.Select(s => s.Value)
                .ToArray());
    
        debugMap.PrintMatrix();
        
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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    var antinode = sourceAntena.Coordinate - delta; 
                    do
                    {
                        if (antinode.IsInMatrix(inputMap))
                        {
                            calculatedPoints.Add(antinode);
                            if (debugMap[antinode].Value == '.' )
                            {
                                debugMap[antinode].Value = '#';
                                Console.Clear();
                                debugMap.PrintMatrix();
                                Thread.Sleep(500);
                            }
                        }
                        antinode = antinode - delta;
                    } while (antinode.IsInMatrix(inputMap));

                    antinode = destinationAntena.Coordinate + delta; 
                    do
                    {
                        if (antinode.IsInMatrix(inputMap))
                        {
                            calculatedPoints.Add(antinode);
                            if (debugMap[antinode].Value == '.' )
                            {
                                debugMap[antinode].Value = '#';
                                Console.Clear();
                                debugMap.PrintMatrix();
                                Thread.Sleep(500);
                            }
                        }
                        antinode = antinode + delta;
                    } while (antinode.IsInMatrix(inputMap));
                }

                i++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            debugMap.PrintMatrix();
            Thread.Sleep(1000);
        }

        Result = calculatedPoints.Count();
    }
}