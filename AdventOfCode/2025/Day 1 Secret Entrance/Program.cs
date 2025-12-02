using System.IO;
using Day_1_Secret_Entrance;
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

        Part1.CountReachZero(row);
        Part2.CountReachZero(row);
    }
}