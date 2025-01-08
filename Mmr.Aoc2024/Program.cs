using System.Diagnostics;
using Mmr.Aoc2024.Days;


namespace Mmr.Aoc2024;

public class Program
{
    public static void Main(string[] args)
    {
        RunYear2024("8");
    }

    private static void RunYear2024(string dayCode)
    {
        switch (dayCode)
        {
            case "1":
                var res1A = new Day01A().MainMethod(new Reader(
                    AbsolutePath(1)));
                PrintDayResult(res1A, "1A");

                var res1B = new Day01B().MainMethod(new Reader(
                    AbsolutePath(1)));
                PrintDayResult(res1B, "1B");
                break;

            case "2":
                var res2A = new Day02A().MainMethod(new Reader(
                    AbsolutePath(2)));
                PrintDayResult(res2A, "2A");

                var res2B = new Day02B().MainMethod(new Reader(
                    AbsolutePath(2)));
                PrintDayResult(res2B, "2B");
                break;

            case "3":
                var res3A = new Day03A().MainMethod(new Reader(
                    AbsolutePath(3)));
                PrintDayResult(res3A, "3A");

                var res3B = new Day03B().MainMethod(new Reader(
                    AbsolutePath(3)));
                PrintDayResult(res3B, "3B");
                break;

            case "4":
                var res4A = new Day04A().MainMethod(new Reader(
                    AbsolutePath(4)));
                PrintDayResult(res4A, "4A");

                var res4B = new Day04B().MainMethod(new Reader(
                    AbsolutePath(4)));
                PrintDayResult(res4B, "4B");
                break;

            case "5":
                var res5A = new Day05A().MainMethod(new Reader(
                    AbsolutePath(5)));
                PrintDayResult(res5A, "5A");

                var res5B = new Day05B().MainMethod(new Reader(
                    AbsolutePath(5)));
                PrintDayResult(res5B, "5B");
                break;
            
            case "6":
                var res6A = new Day06A().MainMethod(new Reader(
                    AbsolutePath(6)));
                PrintDayResult(res6A, "6A");
            
                var res6B = new Day06B().MainMethod(new Reader(
                    AbsolutePath(6)));
                PrintDayResult(res6B, "6B");
                break;
            
            case "7":
                var res = new Day07A().MainMethod(new Reader(
                    AbsolutePath(7)));
                PrintDayResult(res, "7A");
            
                res = new Day07B().MainMethod(new Reader(
                    AbsolutePath(7)));
                PrintDayResult(res, "7B");
                break;
            
            case "8":
                res = new Day08A().MainMethod(new Reader(
                    AbsolutePath(8)));
                PrintDayResult(res, "8A");
            
                res = new Day08B().MainMethod(new Reader(
                    AbsolutePath(8)));
                PrintDayResult(res, "8B");
                break;
                

            default:
                PrintDayResult(new ValueTuple<string, Stopwatch>(), "XY");
                break;
        }
    }

    private static string AbsolutePath(int day)
    {
        return @"C:\Users\m_mar\Documents\repos\MMr\Mmr.AdventOfCode\Mmr.Aoc2024\Days\D"+day+@"\input.txt"; 
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