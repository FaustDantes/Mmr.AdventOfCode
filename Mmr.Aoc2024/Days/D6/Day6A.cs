namespace Mmr.Aoc2024.Days;

public class Day06A : DayAbstract
{
    public const char Obsticle = '#';
    public const char EmptySpace = '.';

    protected override void Runner(Reader reader)
    {
        var input = reader.ReadAsMatrix();
        var guard = Guard.CreateFromMatrix(input);

        PlayGame(input, guard);
        Result = guard.StepCount;
    }

    private void PlayGame(char[][] input, Guard guard)
    {
        var xMaxBoundary = input[0].Length;
        var yMaxBoundary = input.Length;

        var iteration = 0;
        while (xMaxBoundary > guard.PositionX
               || yMaxBoundary > guard.PositionY
               || guard.PositionX <= 0
               || guard.PositionY <= 0)
        {
            var isDone = MakeStep(input, guard, iteration);
            if (isDone) break;

            iteration++;
        }
    }

    private bool MakeStep(char[][] map, Guard guard, int iteration)
    {
        var xCurrent = guard.PositionX;
        var yCurrent = guard.PositionY;
        map[xCurrent][yCurrent] = 'X';

        var xNew = guard.Orientation switch
        {
            Orientations.Up => xCurrent - 1,
            Orientations.Right => xCurrent,
            Orientations.Down => xCurrent + 1,
            Orientations.Left => xCurrent,
            _ => throw new ArgumentOutOfRangeException()
        };

        var yNew = guard.Orientation switch
        {
            Orientations.Up => yCurrent,
            Orientations.Right => yCurrent + 1,
            Orientations.Down => yCurrent,
            Orientations.Left => yCurrent - 1,
            _ => throw new ArgumentOutOfRangeException()
        };

        var isOutOfBounds = xNew < 0 || xNew >= map[0].Length || yNew < 0 || yNew >= map.Length;
        if (isOutOfBounds) return true;

        if (map[xNew][yNew] != Obsticle)
        {
            guard.PositionX = xNew;
            guard.PositionY = yNew;
            if (map[xNew][yNew] == EmptySpace)
            {
                guard.StepCount++;
            }

            map[xNew][yNew] = guard.Marker;
            return false;
        }

        if (map[xNew][yNew] == Obsticle)
        {
            guard.Rotate();
        }

        return false;
    }

    private void PrintPlan(char[][] matrix, int iteration)
    {
        int rows = matrix[0].Length;
        int cols = matrix.Length;

        Console.ForegroundColor = ConsoleColor.DarkRed;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (matrix[row][col] == '#')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(matrix[row][col] + "");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.Write(matrix[row][col] + "");
                }
            }

            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
}