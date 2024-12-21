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
            Console.WriteLine("levels: "+string.Join(",", levels));
            if (levels.Count() == 1)
            {
                safeRows++;
                continue;
            }
            
            // invalid level
            if (Math.Abs(levels.First() - levels[1]) > tolerance) continue;

            if (AreLevelsSafe(levels, tolerance))
            {
                safeRows++;
                Console.WriteLine("imidiate safe!");
                Console.WriteLine("-----------------");
                continue;
            }
            
            // try to remove each item and check if it is safe
            var safeWithout = 0;
            List<int> newLevels = new();
            for (int i = 0; i < levels.Count; i++)
            {
                Console.WriteLine("removing "+i);
                newLevels = levels.ToList();
                newLevels.RemoveAt(i);
                
                Console.WriteLine("new levels: " + string.Join(",", newLevels));

                if (AreLevelsSafe(newLevels, tolerance))
                {
                    safeWithout++;
                }
                Console.WriteLine("safeWithout: "+safeWithout);
            }
            
            if (safeWithout == 1) safeRows++;
            
            Console.WriteLine("-----------------");
        }

        Result = safeRows;
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
            // Console.WriteLine("diff "+levels[i] +" - "+  levels[i+1]+ " = "+ Math.Abs(levels[i] - levels[i+1]));
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