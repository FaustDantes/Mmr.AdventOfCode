namespace Mmr.Aoc2024;

public class Day01A : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var rows = reader.ReadAndGetLines()
            .Select(line =>
            {
                var numbers = line.Split(" ").Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray(); 
                return (numbers[0], numbers[1]);
            });
        
        var firstColumn = rows.Select(x=> int.Parse(x.Item1)).Order().ToArray();
        var secondColumn = rows.Select(x=> int.Parse(x.Item2)).Order().ToArray();
        
        Result = firstColumn.Zip(secondColumn, (x, y) => Math.Abs(x - y)).Sum();
    }
}