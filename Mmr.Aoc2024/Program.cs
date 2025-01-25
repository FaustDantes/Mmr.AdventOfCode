using System.Diagnostics;
namespace Mmr.Aoc2024;

public class Program
{
    public static void Main(string[] args)
    {
        RunYear2024("Day09");
    }

    private static void RunYear2024(string dayCode)
    {
        var onlySpecificPart = dayCode.EndsWith("A") || dayCode.EndsWith("B");  
        
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => (typeof(DayAbstract)).IsAssignableFrom(p))
            .Where(x => onlySpecificPart ? x.Name == dayCode : x.Name.Contains(dayCode));

        foreach (var dayType in types)
        {
            try
            {
                var reader = new Reader(@"C:\Users\m_mar\Documents\repos\MMr\Mmr.AdventOfCode\Mmr.Aoc2024\input.txt"); 
                var res = ((DayAbstract)Activator.CreateInstance(dayType)!).MainMethod(reader);
                PrintDayResult(res, dayType.Name);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Unexpected error or the input is in incorrect format: \n" );
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(e);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------------------------------");
            }
        }
    }

    private static void PrintDayResult((string output, Stopwatch sw) res, string day)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("------------------------------");
        Console.WriteLine("Day is: " + day);
        Console.WriteLine("Result is: " + res.output);
        Console.WriteLine("Time is: " + res.sw.Elapsed.TotalSeconds + "s");
        Console.WriteLine("------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
    }
}