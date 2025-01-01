namespace Mmr.Aoc2024.Days;

public class Day01B : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var rows = reader.ReadAndGetLines()
            .Select(line =>
            {
                var numbers = line.Split(" ").Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                return (numbers[0], numbers[1]);
            });

        var firstColumn = rows.Select(x => int.Parse(x.Item1)).Order().ToArray();
        var secondColumn = rows.Select(x => int.Parse(x.Item2)).Order().GroupBy(x => x).ToArray();

        var res = firstColumn.Where(item => secondColumn.Any(k => k.Key == item))
            .Sum(item => item * secondColumn.Where(k => k.Key == item)
                .Select(x => x.Count())
                .First());

        Result = res;
    }
}