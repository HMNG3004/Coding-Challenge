using Day_5_Cafeteria;
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

    // ------------------------- //
    //     READ INPUT ONLY       //
    // ------------------------- //
    static (List<(long start, long end)> ranges, List<long> ids)
        ReadInput(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var ranges = new List<(long, long)>();
        var ids = new List<long>();

        int i = 0;

        // Read ranges
        for (; i < lines.Length && lines[i].Trim() != ""; i++)
        {
            var parts = lines[i].Split('-');
            ranges.Add((long.Parse(parts[0]), long.Parse(parts[1])));
        }

        // Skip blank line
        i++;
        ranges.Sort();
        // Read IDs
        for (; i < lines.Length; i++)
            ids.Add(long.Parse(lines[i]));

        return (ranges, ids);
    }

    public static List<(long start, long end)> MergeRanges(List<(long start, long end)> ranges)
    {
        var sorted = ranges.OrderBy(r => r.start).ToList();
        var merged = new List<(long start, long end)>();

        var current = sorted[0];

        for (int i = 1; i < sorted.Count; i++)
        {
            var next = sorted[i];

            if (next.start <= current.end)
            {
                current.end = Math.Max(current.end, next.end);
            }
            else
            {
                merged.Add(current);
                current = next;
            }
        }

        merged.Add(current);
        return merged;
    }

    public static void ProcessParts(string filePath)
    {
        var (ranges, ids) = ReadInput(filePath);
        Console.WriteLine("Running Part 1 + Part 2 in parallel...\n");

        long part1Result = 0;
        long part2Result = 0;

        var swTotal = Stopwatch.StartNew();

        Task t1 = Task.Run(() =>
        {
            part1Result = Utils.Measure("Part 1", () =>
            {
                long total = 0;
                total += Part1.SolvePart1(ranges, ids);
                return total;
            });
        });

        Task t2 = Task.Run(() =>
        {
            part2Result = Utils.Measure("Part 2", () =>
            {
                long total = 0;
                total += Part2.SolvePart2(ranges);
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