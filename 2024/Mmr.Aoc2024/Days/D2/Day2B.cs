namespace Mmr.Main2024.Inputs.D2;

public class Day02B : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var levelsPerRow = reader.ReadAndGetLines()
            .Select(line =>
                line.Split(" ").Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => int.Parse(x)).ToList()
            );

        var tolerance = 3;
        var safeRows = 0;
        
        foreach (var levels in levelsPerRow)
        {
            if (levels.Count() == 1)
            {
                safeRows++;
                continue;
            }

            if (AreLevelsSafe(levels, tolerance))
            {
                safeRows++;
                continue;
            }

            var isOk = RemoveItems(tolerance, levels);
            if (isOk == 1) safeRows++;
        }

        Result = safeRows;
    }

    private static int RemoveItems(int tolerance, List<int>? levels)
    {
        List<int> newLevels = new();
        for (int i = 0; i < levels.Count; i++)
        {
            newLevels = levels.ToList();
            newLevels.RemoveAt(i);

            if (AreLevelsSafe(newLevels, tolerance))
                return 1;
        }
        return 0;
    }

    private static bool AreLevelsSafe(List<int> levels, int tolerance)
    {
        bool isSafe = false;
        var isDecreasing = levels[0] - levels[1] > 0;
        for (int i = 0; i < levels.Count - 1; i++)
        {
            var isDirectionOk = isDecreasing ? levels[i] - levels[i + 1] : levels[i + 1] - levels[i];
            if ( isDirectionOk < 0 )
            {
                isSafe = false;
                break;
            }
            var diff = Math.Abs(levels[i] - levels[i+1]);
            if ( diff > tolerance || diff == 0)
            {
                isSafe = false;
                break;
            } 
                
            isSafe = true;
        }

        return isSafe;
    }
}