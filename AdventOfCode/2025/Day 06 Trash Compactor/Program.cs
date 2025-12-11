using System.Diagnostics;
using System.IO;
using Day_06_Trash_Compactor;
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

    public static (List<List<int>> matrix, List<char> operations) ParseMatrixWithOps(string filePath)
    {
        var lines = File.ReadAllLines(filePath)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .ToList();

        if (lines.Count < 2)
            throw new Exception("Input must have at least 1 matrix line and 1 operation line.");

        string opLine = lines[^1];
        lines.RemoveAt(lines.Count - 1);

        // Parse matrix
        List<List<int>> matrix = new List<List<int>>();
        foreach (var line in lines)
        {
            var parts = line
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            List<int> row = new List<int>();
            foreach (var p in parts)
            {
                if (int.TryParse(p, out int num))
                    row.Add(num);
                else
                    throw new Exception($"Invalid number '{p}' in line: {line}");
            }

            matrix.Add(row);
        }

        // Parse operations
        var opParts = opLine
            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        List<char> operations = opParts.Select(s => s[0]).ToList();

        return (matrix, operations);
    }


    public static void ProcessParts(string filePath)
    {
        var (matrix, operations) = ParseMatrixWithOps(filePath);

        long part1Result = 0;
        long part2Result = 0;

        var swTotal = Stopwatch.StartNew();

        Task t1 = Task.Run(() =>
        {
            part1Result = Utils.Measure("Part 1", () =>
            {
                long total = 0;
                total = Part1.SolvePart1(matrix, operations);
                return total;
            });
        });

        Task t2 = Task.Run(() =>
        {
            part2Result = Utils.Measure("Part 2", () =>
            {
                long total = 0;
                total = Part2.SolvePart2(filePath);
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