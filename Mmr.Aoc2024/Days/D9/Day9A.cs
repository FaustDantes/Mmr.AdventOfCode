using Mmr.Aoc.Common.Models;

namespace Mmr.Aoc2024.Days;

public class Day09A : DayAbstract
{
    // solution taken from https://github.com/tmbarker/advent-of-code/tree/main/Solutions/Y2024/D09
    protected override void Runner(Reader reader)
    {
        var d = Disk.Parse(reader.ReadAll());
        Result = DefragmentBlocks(d);
    }

    private static long DefragmentBlocks(Disk disk)
    {
        var head = 0;
        var tail = disk.Blocks.Length - 1;

        while (head < tail)
        {
            if (disk.Blocks[head] != null)
            {
                head++;
                continue;
            }

            while (disk.Blocks[tail] == null) tail--;
            disk.Blocks[head++] = disk.Blocks[tail];
            disk.Blocks[tail--] = null;
        }

        return disk.Checksum();
    }
}

