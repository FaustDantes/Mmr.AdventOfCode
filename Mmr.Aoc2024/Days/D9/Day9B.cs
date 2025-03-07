using Mmr.Aoc.Common.Models;

namespace Mmr.Aoc2024.Days;

public class Day09B : DayAbstract
{
    // solution taken from https://github.com/tmbarker/advent-of-code/tree/main/Solutions/Y2024/D09
    
    protected override void Runner(Reader reader)
    {
        var d = Disk.Parse(reader.ReadAll());
        Result = DefragmentFiles(d);
    }
    
    private static long DefragmentFiles(Disk disk)
    {
        for (var fileId = disk.Allocated.Count - 1; fileId >= 0; fileId--)
        {
            var file = disk.Allocated[fileId];
            for (var j = 0; j < disk.Free.Count; j++)
            {
                var free = disk.Free[j];
                if (free.Min >= file.Min) break;
                if (free.Length < file.Length) continue;

                for (var k = 0; k < file.Length; k++)
                {
                    disk.Blocks[free.Min + k] = fileId;
                    disk.Blocks[file.Min + k] = null;
                }

                disk.Free.RemoveAt(index: j);
                if (free.Length > file.Length)
                {
                    disk.Free.Insert(index: j, new Range<int>(min: free.Min + file.Length, max: free.Max));
                }

                break;
            }
        }

        return disk.Checksum();
    }

}