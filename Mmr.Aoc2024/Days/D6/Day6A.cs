namespace Mmr.Aoc2024.Days;

public class Day06A : DayAbstract
{   
    protected override void Runner(Reader reader)
    {
        var res = 0;
        var input = reader.ReadAndGetLines();

        var orderingRules = input.Where(x => x.Contains("|"))
            .Select(x => x.Split("|"))
            .Select(x => Array.ConvertAll(x, int.Parse))
            .GroupBy(x => x[0])
            .ToDictionary(
                group => group.Key,
                group => group.SelectMany(arr => arr.Skip(1)).ToArray()
            );

        var pages = input.Where(x => x.Contains(","))
            .Select(x => x.Split(","))
            .Select(x => Array.ConvertAll(x, int.Parse))
            .ToList();

        var checkedPageNumbers = 0;
        foreach (var page in pages)
        {
            for (var i = 0; i < page.Length; i++)
            {
                if (orderingRules.Keys.Contains(page[i]))
                {
                    _ = orderingRules.TryGetValue(page[i], out var rules);
                    checkedPageNumbers += CheckPreviousNumbers(page, i, rules!);
                }
                else
                {
                    // no need to check
                    checkedPageNumbers++;
                }
            }

            if (checkedPageNumbers == page.Length)
            {
                res += GetMiddleNumber(page);
            }
            
            checkedPageNumbers = 0;
        }

        Result = res.ToString();
    }

    private int CheckPreviousNumbers(int[] page, int currentIndex, int[] rules)
    {
        if (currentIndex == 0) return 1;
        var specificRules = rules.Where(page.Contains).ToArray();
        var indexes = specificRules.Select(rule => Array.IndexOf(page, rule)).ToArray();
        return indexes.All(x => x > currentIndex) ? 1 : 0;
    }

    private int GetMiddleNumber(int[] page)
    {
        var middle = page.Length / 2;
        return page[middle];
    }
}