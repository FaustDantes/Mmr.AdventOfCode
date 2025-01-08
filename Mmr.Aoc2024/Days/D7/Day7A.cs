namespace Mmr.Aoc2024.Days;

public class Day07A : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var inputRows = reader.ReadAndGetLines()
            .Select(x => x.Split(":"))
            .Select(s => (
                ExpectedResult: long.Parse(s[0]), 
                Values: s[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(v =>  long.Parse(v)).ToArray()
                )
            );

        long sum = 0;
        foreach (var row in inputRows)
        {
            if (!row.Values.Any()) continue;
        
            var calibrationResult = row.ExpectedResult;
            if (calibrationResult == row.Values.Sum())
            {
                sum += calibrationResult;
                continue;
            }
        
            if (calibrationResult == row.Values.Multiply())
            {
                sum += calibrationResult;
                continue;
            }
        
            List<long> tempResults = [row.Values.First()];
            foreach (var nextValue in row.Values.Skip(1))
            {
                var tmpList = new List<long>();
                foreach (var tempResult in tempResults)
                {
                    tmpList.Add(tempResult * nextValue);
                    tmpList.Add(tempResult + nextValue);
                }
                tempResults = tmpList;
            }
        
            if (tempResults.Contains(calibrationResult))
            {
                sum += calibrationResult;
            }
        }

        Result = sum;
    }
}