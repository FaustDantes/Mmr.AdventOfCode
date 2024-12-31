using System.Text.RegularExpressions;

namespace Mmr.Aoc2024.Days.D3;

public class Day03B : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var memory = reader.ReadAll();
        var pattern = @"(?<NumPattern>mul\((\d{1,3}),(\d{1,3})\))|(?<DontPattern>don't())|(?<DoPattern>do())";
        var sums = Regex.Matches(memory, pattern);

        var res = 0;
        var isEnabled = true;
        foreach (Match match in sums)
        {
            if (!match.Success) continue;

            if (match.Groups["NumPattern"].Success && isEnabled)
            {
                var firstNumber = int.Parse(match.Groups[1].Value);
                var secondNumber = int.Parse(match.Groups[2].Value);
                res += firstNumber * secondNumber;
            }
            else if (match.Groups["DoPattern"].Success)
            {
                isEnabled = true;
            }
            else if (match.Groups["DontPattern"].Success)
            {
                isEnabled = false;
            }
        }

        Result = res.ToString();
    }
}