using System.Diagnostics;
using System.IO;
using Day_2_Gift_Shop;
using LibraryHelper;

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

    public static List<(long L, long R)> ReadFile(string filePath)
    {
        var ranges = new List<(long L, long R)>();

        foreach (var line in File.ReadLines(filePath))
        {
            foreach (var part in line.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                var lr = part.Split('-');
                long L = long.Parse(lr[0]);
                long R = long.Parse(lr[1]);
                ranges.Add((L, R));
            }
        }

        return ranges;
    }

    public static long Pow10(int exp)
    {
        long res = 1;
        for (int i = 0; i < exp; i++) res *= 10;
        return res;
    }

    public static void ProcessParts(string filePath)
    {
        var ranges = ReadFile(filePath);
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
                foreach (var (L, R) in ranges)
                    total += Part1.SumRepeatedInRange(L, R);
                return total;
            });
        });

        Task t2 = Task.Run(() =>
        {
            part2Result = Utils.Measure("Part 2", () =>
            {
                long total = 0;
                foreach (var (L, R) in ranges)
                    total += Part2.SumRepeatedAtLeastTwice(L, R);
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