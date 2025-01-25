using System.Collections.Immutable;
using System.Drawing;
using Mmr.Aoc.Common.Models;

namespace Mmr.Aoc2024.Days;

public class Day09A : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var input = reader.ReadAll().ToCharArray(); //.Select(x=> int.Parse(x.ToString())).ToArray();
        var space = '.';

        var emptySpace = new List<int>();
        int index = 0;
        var blocks = string.Concat( 
            input.Where((_, i) => i % 2 == 0).Select(
                (c, i) => new string(char.Parse(i.ToString()), int.Parse(c.ToString())) + (i * 2 + 1 < input.Length ? new (space, int.Parse(input[i * 2 + 1].ToString())) : string.Empty)));
        
      // blocks.Select((c, i) => c == space ?  ).ToString();
        
        Console.WriteLine(blocks);
        
        //Console.WriteLine(Enumerable.Range(0, input.Length).Where(i => i % 2 == 0));
        Result = 11;
    }
}