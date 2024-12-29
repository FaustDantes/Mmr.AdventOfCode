using System.Diagnostics;
using Mmr.Main2024;
using Mmr.Main2024.Inputs.D1;
using Mmr.Main2024.Inputs.D2;
using Mmr.Main2024.Inputs.D3;
using Mmr.Main2024.Inputs.D4;
using Mmr.Main2024.Inputs.D5;

public class Program
{
    public static void Main(string[] args)
    {
        RunDay("5");
    }

    private static void RunDay(string dayCode)
    {
        switch (dayCode)
        {
            case "1":
                var res1A = new Day01A().MainMethod(new Reader(
                    "C:\\Users\\m_mar\\Documents\\repos\\MMr\\Mmr.AdventOfCode\\2024\\Mmr.Main2024\\Inputs\\D1\\input.txt"));
                PrintDayResult(res1A, "1A");
                var res1B = new Day01B().MainMethod(new Reader(
                    "C:\\Users\\m_mar\\Documents\\repos\\MMr\\Mmr.AdventOfCode\\2024\\Mmr.Main2024\\Inputs\\D1\\input.txt"));
                PrintDayResult(res1B, "1B");
                break;

            case "2":
                var res2A = new Day02A().MainMethod(new Reader(
                    "C:\\Users\\m_mar\\Documents\\repos\\MMr\\Mmr.AdventOfCode\\2024\\Mmr.Main2024\\Inputs\\D2\\input.txt"));
                PrintDayResult(res2A, "2A");
                var res2B = new Day02B().MainMethod(new Reader(
                    @"C:\Users\m_mar\Documents\repos\Mmr.AdventOfCode\2024\Mmr.Main2024\Inputs\D2\input.txt"));
                PrintDayResult(res2B, "2B");
                break;

            case "3":
                var res3A = new Day03A().MainMethod(new Reader(
                     @"C:\Users\m_mar\Documents\repos\Mmr.AdventOfCode\2024\Mmr.Main2024\Inputs\D3\input.txt"));
                PrintDayResult(res3A, "3A");

                var res3B = new Day03B().MainMethod(new Reader(
                    @"C:\Users\m_mar\Documents\repos\Mmr.AdventOfCode\2024\Mmr.Main2024\Inputs\D3\input.txt"));
                PrintDayResult(res3B, "3B");
                break;

            case "4":
                var res4A = new Day04A().MainMethod(new Reader(
                     @"C:\Users\m_mar\Documents\repos\Mmr.AdventOfCode\2024\Mmr.Main2024\Inputs\D4\input.txt"));
               PrintDayResult(res4A, "4A");

                var res4B = new Day04B().MainMethod(new Reader(
                    @"C:\Users\m_mar\Documents\repos\Mmr.AdventOfCode\2024\Mmr.Main2024\Inputs\D4\input.txt"));
                PrintDayResult(res4B, "4B");
                break;
            
            case "5":
                var res5A = new Day05A().MainMethod(new Reader(
                     @"C:\Users\m_mar\Documents\repos\Mmr.AdventOfCode\2024\Mmr.Main2024\Inputs\D5\input.txt"));
               PrintDayResult(res5A, "5A");

                var res5B = new Day05B().MainMethod(new Reader(
                    @"C:\Users\m_mar\Documents\repos\Mmr.AdventOfCode\2024\Mmr.Main2024\Inputs\D5\input.txt"));
                PrintDayResult(res5B, "5B");
                break;

            default:
                break;
        }
    }

    private static void PrintDayResult((string output, Stopwatch sw) res, string day)
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine("Day is: " + day);
        Console.WriteLine("Result is: " + res.output);
        Console.WriteLine("Time is: " + res.sw.Elapsed.TotalSeconds + "s");
        Console.WriteLine("------------------------------");
    }
}