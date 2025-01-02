using System.Collections.Immutable;
using System.Numerics;
using Map = System.Collections.Immutable.ImmutableDictionary<System.Numerics.Complex, char>;

namespace Mmr.Aoc2024.Days;

public class Day06B : DayAbstract
{
    Complex Up = Complex.ImaginaryOne;
    Complex TurnRight = -Complex.ImaginaryOne;

    protected override void Runner(Reader reader)
    {
        var (map, start) = Parse(reader.ReadAndGetLines());

        Result = Walk(map, start).positions.Count();
        return;
        // try a blocker in each locations visited by the guard counting the loops
        Result = Walk(map, start).positions
            .AsParallel()
            .Count(pos => Walk(map.SetItem(pos, '#'), start).isLoop);
    }

    // returns the positions visited when starting from 'pos', isLoop is set if the 
    // guard enters a cycle.
    (IEnumerable<Complex> positions, bool isLoop) Walk(Map map, Complex pos)
    {
        var seen = new HashSet<(Complex pos, Complex dir)>();
        var dir = Up;
        while (map.ContainsKey(pos) && !seen.Contains((pos, dir)))
        {
            seen.Add((pos, dir));
            if (map.GetValueOrDefault(pos + dir) == '#')
            {
                dir *= TurnRight;
            }
            else
            {
                pos += dir;
            }
        }

        return (
            positions: seen.Select(s => s.pos).Distinct(),
            isLoop: seen.Contains((pos, dir))
        );
    }

    // store the grid in a dictionary, to make bounds checks and navigation simple
    // start represents the starting postion of the guard
    (Map map, Complex start) Parse(string[] input)
    {
        var lines = input;
        var map = (
            from y in Enumerable.Range(0, lines.Length)
            from x in Enumerable.Range(0, lines[0].Length)
            select new KeyValuePair<Complex, char>(-Up * y + x, lines[y][x])
        ).ToImmutableDictionary();

        var start = map.First(x => x.Value == '^').Key;

        return (map, start);
    }
}