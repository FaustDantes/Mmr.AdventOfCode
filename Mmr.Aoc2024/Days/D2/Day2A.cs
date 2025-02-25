﻿namespace Mmr.Aoc2024.Days;

public class Day02A : DayAbstract {
    protected override void Runner(Reader reader) {
        var levelsPerRow = reader.ReadAndGetLines()
            .Select(line =>
                line.Split(" ").Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => int.Parse(x)).ToArray()
            );

        var tolerance = 3;
        var safeRows = 0;
        foreach (var levels in levelsPerRow) {
            var isSafe = false;
            if (levels.Count() == 1) {
                safeRows++;
                continue;
            }

            var invalidLevel = Math.Abs(levels[0] - levels[1]) > tolerance;
            if (invalidLevel) continue;

            if (AreLevelsSafe(levels, tolerance)) safeRows++;
        }

        Result = safeRows;
    }

    private static bool AreLevelsSafe(int[] levels, int tolerance) {
        bool isSafe = false;
        var isDecreasing = levels[0] - levels[1] > 0;
        for (int i = 0; i < levels.Length - 1; i++) {
            var isDirectionOk = isDecreasing ? levels[i] - levels[i + 1] : levels[i + 1] - levels[i];
            if (isDirectionOk < 0) {
                isSafe = false;
                break;
            }
            
            var diff = Math.Abs(levels[i] - levels[i + 1]);
            if (diff > tolerance || diff == 0) {
                isSafe = false;
                break;
            }

            isSafe = true;
        }

        return isSafe;
    }
}