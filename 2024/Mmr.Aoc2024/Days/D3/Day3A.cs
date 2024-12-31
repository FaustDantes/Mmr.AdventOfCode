using System.Text.RegularExpressions;

namespace Mmr.Main2024.Inputs.D3;

public class Day03A : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var memory = reader.ReadAll();
        var pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        var sums = Regex.Matches(memory, pattern);
        
        var res = 0;

        foreach (Match match in sums)
        {
            if (!match.Success) continue;

            var firstNumber = int.Parse(match.Groups[1].Value);
            var secondNumber = int.Parse(match.Groups[2].Value);
            res += firstNumber * secondNumber;
        }

        Result = res.ToString();
    }
}