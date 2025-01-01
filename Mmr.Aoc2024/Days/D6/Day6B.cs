namespace Mmr.Aoc2024.Days;

public class Day06B : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var input = reader.ReadAndGetLines();
        var orderingRules = input.Where(x => x.Contains("|"));
        var pages = input.Where(x => x.Contains(","));

        var (updates, comparer) = Parse(orderingRules, pages);

        Result = updates
            .Where(pages => !Sorted(pages, comparer))
            .Select(pages => pages.OrderBy(p => p, comparer).ToArray())
            .Sum(GetMiddleNumber);
    }

    private (string[][] updates, Comparer<string>) Parse(IEnumerable<string> orderingRules, IEnumerable<string> pages)
    {
        var comparer =
            Comparer<string>.Create((p1, p2) => orderingRules.Contains(p1 + "|" + p2) ? -1 : 1);

        var updates = pages.Select(line => line.Split(",")).ToArray();
        return (updates, comparer);
    }

    private int GetMiddleNumber(string[] page)
    {
        var middle = page.Length / 2;
        return int.Parse(page[middle]);
    }

    private bool Sorted(string[] pages, Comparer<string> comparer)
    {
        return Enumerable.SequenceEqual(pages, pages.OrderBy(x => x, comparer));
    }
}