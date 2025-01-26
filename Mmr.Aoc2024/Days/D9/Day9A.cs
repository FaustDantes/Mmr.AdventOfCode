using System.Collections.Immutable;
using System.Drawing;
using Mmr.Aoc.Common.Models;

namespace Mmr.Aoc2024.Days;

public class Day09A : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var input = reader.ReadAll().ToCharArray();
        var space = '.';
        var blocks = string.Concat(input.Where((_, i) => i % 2 == 0)
            .Select((c, i) =>
                string.Concat(Enumerable.Repeat(i, int.Parse(c.ToString())))
                + (i * 2 + 1 < input.Length ? new(space, int.Parse(input[i * 2 + 1].ToString())) : string.Empty))
        );

        var workBlock = blocks.Select(x => x).ToList();
        var blockIds = new LinkedList<char>(
            string.Concat(
                input.Where((_, i) => i % 2 == 0)
                    .Select((c, i) => string.Concat(Enumerable.Repeat(i, int.Parse(c.ToString()))))
            ).ToCharArray().Skip(workBlock.Count(c => c == space)).Reverse().ToList()
        );

        // Console.WriteLine(string.Concat(blockIds));
        // Console.WriteLine("------------------------------");

        while (workBlock.Contains(space))
        {
            var replace =  workBlock.Select((c,i) => (c,i) ).Where(x => x.c == space).First();
            workBlock[replace.i] = blockIds.First.Value;
            blockIds.RemoveFirst();
        }

        var sorted = string.Concat(workBlock.Where(x => char.IsNumber(x)).Select(x => x).ToList());
        //     Console.WriteLine(sorted);

        var res = workBlock.Where(x => char.IsNumber(x)).Select((c, j) => long.Parse(c.ToString()) * j).Sum();
        Result = res;
    }
}