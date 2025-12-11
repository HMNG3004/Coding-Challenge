using Day_07_Laboratories;
using LibraryHelper;
using System.Diagnostics;
using System.IO;

public class Program
{
    public static void Main()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(currentDirectory, "input.txt");

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: Could not find file '{filePath}'. Ensure the file exists in the output directory.");
            return;
        }

        ProcessParts(filePath);
    }

    public static void ProcessParts(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        long part1Result = 0;
        long part2Result = 0;

        var swTotal = Stopwatch.StartNew();

        Task t1 = Task.Run(() =>
        {
            part1Result = Utils.Measure("Part 1", () =>
            {
                long total = 0;
                total = Part1.CountSplits(lines);
                return total;
            });
        });

        Task t2 = Task.Run(() =>
        {
            part2Result = Utils.Measure("Part 2", () =>
            {
                long total = 0;
                total = Part2.CountTimelines(lines);
                return total;
            });
        });

        Task.WaitAll(t1, t2);

        swTotal.Stop();

        Console.WriteLine("\n=== FINAL RESULTS ===");
        Console.WriteLine($"Part 1 result = {part1Result}");
        Console.WriteLine($"Part 2 result = {part2Result}");
        Console.WriteLine($"Total wall time = {swTotal.ElapsedMilliseconds} ms");

    }
}