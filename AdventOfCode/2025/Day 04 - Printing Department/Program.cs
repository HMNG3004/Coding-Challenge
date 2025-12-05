using Day_04_Printing_Department;
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

    public static List<string> ReadFile(string filePath)
    {
        List<string> result = new List<string>();

        foreach (var line in File.ReadLines(filePath))
        {
            string trimmed = line.Trim();

            if (!string.IsNullOrWhiteSpace(trimmed))
            {
                result.Add(trimmed);
            }
        }

        return result;
    }

    public static void ProcessParts(string filePath)
    {
        var row = ReadFile(filePath);

        Console.WriteLine("Running Part 1 + Part 2 in parallel...\n");

        long part1Result = 0;
        long part2Result = 0;

        var swTotal = Stopwatch.StartNew();

        // Chạy song song cả hai phần
        Task t1 = Task.Run(() =>
        {
            part1Result = Utils.Measure("Part 1", () =>
            {
                long total = 0;
                total += Part1.SolvePart1(row);
                return total;
            });
        });

        Task t2 = Task.Run(() =>
        {
            part2Result = Utils.Measure("Part 2", () =>
            {
                long total = 0;
                total += Part2.SolvePart2(row);
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