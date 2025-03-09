using Mmr.Aoc.Common.Models;

namespace Mmr.Aoc2024.Days;

public class Day10A : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var input = reader.ReadAsComplex<int>();
        var max = input.Max().Key;
        
        var startingCells = input
            .Where(x=> x.Key.Real == 0 || x.Key.Imaginary == 0 || x.Key.Real == max.Real || x.Key.Imaginary == max.Imaginary)
            .Select(x => x.Value)
            .Where(x=>x.Value == '0')
            .ToList();
        var starters = new List<ComplexCell<int>>();
        
        
        Result = 0;
    }
}