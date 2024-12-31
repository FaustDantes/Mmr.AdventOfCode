using System.Text.RegularExpressions;

namespace Mmr.Aoc2024.Days.D4;

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
                /*
             -1   M . S       S . M
              0   . A .       . A .
             +1   M . S       S . M
                */

                if (metrix[i][j] == 'A'
                    && i + 1 < rowLength && j + 1 < columnLength
                    && i - 1 >= 0 && j - 1 >= 0)
                {
                    // M on the left
                    if (metrix[i - 1][j - 1] == 'M' && metrix[i + 1][j - 1] == 'M')
                        if (metrix[i - 1][j + 1] == 'S' && metrix[i + 1][j + 1] == 'S')
                        {
                            res++;
                            continue;
                        }

                    // S on the left
                    if (metrix[i - 1][j - 1] == 'S' && metrix[i + 1][j - 1] == 'S')
                        if (metrix[i - 1][j + 1] == 'M' && metrix[i + 1][j + 1] == 'M')
                        {
                            res++;
                            continue;
                        }

                    /*
                     -1   S . S       M . M
                      0   . A .       . A .
                     +1   M . M       S . S
                     */

                    // S on the bottom
                    if (metrix[i - 1][j - 1] == 'S' && metrix[i - 1][j + 1] == 'S')
                        if (metrix[i + 1][j - 1] == 'M' && metrix[i + 1][j + 1] == 'M')
                        {
                            res++;
                            continue;
                        }

                    // M on the bottom
                    if (metrix[i - 1][j - 1] == 'M' && metrix[i - 1][j + 1] == 'M')
                        if (metrix[i + 1][j - 1] == 'S' && metrix[i + 1][j + 1] == 'S')
                        {
                            res++;
                            continue;
                        }
                }
            }
        }

        Result = res.ToString();
    }
}