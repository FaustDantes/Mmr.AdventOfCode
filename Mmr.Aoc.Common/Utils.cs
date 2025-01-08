namespace Mmr.Aoc.Common;

public static class Utils
{
    public static long Multiply(this IEnumerable<long> list)
    {
        return list.Aggregate((a, x) => a * x);
    }
    
    public static long Concate(this long a, long b)
    {
        return long.Parse(a+""+b);
    }
}