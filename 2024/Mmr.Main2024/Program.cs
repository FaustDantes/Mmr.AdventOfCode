using System.Diagnostics;
using Mmr.Main2024;
using Mmr.Main2024.Inputs.D1;
using Mmr.Main2024.Inputs.D2;

public class Program
{
    public static void Main(string[] args)
    {
        var res1A = new Day01A().MainMethod(new Reader(
            "C:\\Users\\m_mar\\Documents\\repos\\MMr\\Mmr.AdventOfCode\\2024\\Mmr.Main2024\\Inputs\\D1\\input.txt"));
       PrintDayResult(res1A, "1A");
        var res1B = new Day01B().MainMethod(new Reader(
            "C:\\Users\\m_mar\\Documents\\repos\\MMr\\Mmr.AdventOfCode\\2024\\Mmr.Main2024\\Inputs\\D1\\input.txt"));
        PrintDayResult(res1B, "1B");

        // ------------------------------
        
        var res2A = new Day02A().MainMethod(new Reader(
            "C:\\Users\\m_mar\\Documents\\repos\\MMr\\Mmr.AdventOfCode\\2024\\Mmr.Main2024\\Inputs\\D2\\input.txt"));
        PrintDayResult(res2A, "2A");
        var res2B = new Day02B().MainMethod(new Reader(
            "C:\\Users\\m_mar\\Documents\\repos\\MMr\\Mmr.AdventOfCode\\2024\\Mmr.Main2024\\Inputs\\D2\\input.txt"));
        PrintDayResult(res2B, "2B");
    }
    
    private static void PrintDayResult((string output, Stopwatch sw) res, string day)
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine("Day is: "+day);
        Console.WriteLine("Result is: " + res.output);
        Console.WriteLine("Time is: " + res.sw.Elapsed.TotalSeconds+"s");
        Console.WriteLine("------------------------------");
    }
}