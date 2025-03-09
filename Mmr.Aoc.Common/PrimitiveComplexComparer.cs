using System.Numerics;

namespace Mmr.Aoc.Common;

public class PrimitiveComplexComparer : IEqualityComparer<Complex>, IComparer<Complex>
{
    public bool Equals(Complex x, Complex y)
    {
        if (Math.Abs(x.Real - y.Real) < 0)
        {
            return Math.Abs(x.Imaginary - y.Imaginary) < 0;
        }

        return Math.Abs(x.Real - y.Real) < 0;
    }

    public int GetHashCode(Complex obj)
    {
        return obj.Real.GetHashCode() ^ obj.Imaginary.GetHashCode();
    }

    public int Compare(Complex x, Complex y)
    {
        if (x.Real > y.Real && x.Imaginary > y.Imaginary)
        {
            return 1;
        }

        if (x.Real < y.Real && x.Imaginary < y.Imaginary)
        {
            return -1;
        }
        return 0;
    }
}