using System.Text.RegularExpressions;

namespace Mmr.Main2024.Inputs.D4;

public class Day04B : DayAbstract
{
    protected override void Runner(Reader reader)
    {
        var res = 0;
        var metrix = reader.ReadAndGetLines().Select(x => x.ToCharArray()).ToArray();

        var rowLength = metrix[0].Length;
        var columnLength = metrix.Length;

        for (var i = 0; i < rowLength; i++)
        {
            for (var j = 0; j < columnLength; j++)
            {
                // direction top to bottom  
                if (metrix[i][j] == 'M' && i + 3 < rowLength)
                {
                    // diagonal right
                    if (j + 3 < columnLength &&
                        metrix[i + 1][j + 1] == 'A' && metrix[i + 2][j + 2] == 'S')
                    {
                        // diagonal left
                        if (j - 3 < columnLength && j - 3 >= 0 &&
                            metrix[i + 1][j - 1] == 'A' && metrix[i + 2][j - 2] == 'S')
                        {
                            res++;
                        }
                    }
                }

                // direction bottom to top   
                if (metrix[i][j] == 'M' && i - 3 < rowLength && i - 3 >= 0)
                {
                    // diagonal right
                    if (j + 3 < columnLength &&
                        metrix[i - 1][j + 1] == 'A' && metrix[i - 2][j + 2] == 'S')
                    {
                        // diagonal left
                        if (j - 3 < columnLength && j - 3 >= 0 &&
                            metrix[i - 1][j - 1] == 'A' && metrix[i - 2][j - 2] == 'S')
                        {
                            res++;
                        }
                    }
                }
            }
        }

        Result = res.ToString();
    }
}