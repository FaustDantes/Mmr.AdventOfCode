namespace Mmr.Aoc2024.Days;

public class Day10A : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var input = reader.ReadAsMetrix<int>();
        var edge = input.Keys.Last();
        
        var startingCells = input
            .Where(x=> x.Key.X == 0 || x.Key.Y == 0 || x.Key.X == edge.X || x.Key.Y == edge.Y)
            .Where(x=> x.Value.Value == 0)
            .Select(x => x.Value)
            .ToList();
        
        var endCells = input
            .Where(x=> x.Key.X == 0 || x.Key.Y == 0 || x.Key.X == edge.X || x.Key.Y == edge.Y)
            .Where(x=> x.Value.Value == 9)
            .Select(x => x.Value)
            .ToList();
        
        Result = 0;
    }
}