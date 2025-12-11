using Day_08_Playground;
using LibraryHelper;
using System.Diagnostics;
using System.IO;

public class Program
{
    private const int K = 1000;
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

    static List<Point> ReadPoints(string[] lines)
    {
        var points = new List<Point>();
        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            if (string.IsNullOrEmpty(trimmed)) continue;

            var parts = trimmed.Split(',');
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int z = int.Parse(parts[2]);
            points.Add(new Point(x, y, z));
        }
        return points;
    }

    static List<Edge> BuildEdges(List<Point> points)
    {
        int n = points.Count;
        var edges = new List<Edge>();

        for (int i = 0; i < n; i++)
        {
            var pi = points[i];
            for (int j = i + 1; j < n; j++)
            {
                var pj = points[j];
                long dx = (long)pi.X - pj.X;
                long dy = (long)pi.Y - pj.Y;
                long dz = (long)pi.Z - pj.Z;
                long dist2 = dx * dx + dy * dy + dz * dz;
                edges.Add(new Edge(i, j, dist2));
            }
        }

        return edges;
    }

    public static void ProcessParts(string filePath)
    {
        var lines = File.ReadLines(filePath);
        var points = ReadPoints(lines.ToArray());
        var edges = BuildEdges(points);

        edges.Sort((e1, e2) => e1.Dist2.CompareTo(e2.Dist2));
        long part1Result = 0;
        long part2Result = 0;

        var swTotal = Stopwatch.StartNew();

        Task t1 = Task.Run(() =>
        {
            part1Result = Utils.Measure("Part 1", () =>
            {
                long total = 0;
                total = Part1.SolvePart1(points.Count, edges, K);
                return total;
            });
        });

        Task t2 = Task.Run(() =>
        {
            part2Result = Utils.Measure("Part 2", () =>
            {
                long total = 0;
                total = Part2.SolvePart2(points, edges);
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