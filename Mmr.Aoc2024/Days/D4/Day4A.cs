namespace Mmr.Aoc2024.Days;

public class Day04A : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var res = 0;
        var text = reader.ReadAll();

        var horizont = Regex.Matches(text, "XMAS");
        res += horizont.Select(x => x.Success).Count();

        var horizontBack = Regex.Matches(text, "SAMX");
        res += horizontBack.Select(x => x.Success).Count();

        var metrix = reader.ReadAndGetLines().Select(x => x.ToCharArray()).ToArray();
        var rowLength = metrix[0].Length;
        var columnLength = metrix.Length;

        for (var i = 0; i < rowLength; i++)
        {
            for (var j = 0; j < columnLength; j++)
            {
                // direction top to bottom  
                if (metrix[i][j] == 'X' && i + 3 < rowLength)
                {
                    // in the same column
                    if (metrix[i + 1][j] == 'M' && metrix[i + 2][j] == 'A' && metrix[i + 3][j] == 'S')
                    {
                        res++;
                    }
                    // diagonal right
                    if (j + 3 < columnLength &&
                        metrix[i + 1][j + 1] == 'M' && metrix[i + 2][j + 2] == 'A' && metrix[i + 3][j + 3] == 'S')
                    {
                        res++;
                    }
                    // diagonal left
                    if (j - 3 < columnLength && j - 3 >= 0 &&
                        metrix[i + 1][j - 1] == 'M' && metrix[i + 2][j - 2] == 'A' && metrix[i + 3][j - 3] == 'S')
                    {
                        res++;
                    }
                }

                // direction bottom to top   
                if (metrix[i][j] == 'X' && i - 3 < rowLength && i - 3 >= 0)
                {
                    // in the same column
                    if (metrix[i - 1][j] == 'M' && metrix[i - 2][j] == 'A' && metrix[i - 3][j] == 'S')
                    {
                        res++;
                    }
                    // diagonal right
                    if (j + 3 < columnLength &&
                        metrix[i - 1][j + 1] == 'M' && metrix[i - 2][j + 2] == 'A' && metrix[i - 3][j + 3] == 'S')
                    {
                        res++;
                    }
                    // diagonal left
                    if (j - 3 < columnLength && j - 3 >= 0 &&
                        metrix[i - 1][j - 1] == 'M' && metrix[i - 2][j - 2] == 'A' && metrix[i - 3][j - 3] == 'S')
                    {
                        res++;
                    }
                }
            }
        }

        Result = res.ToString();
    }
}