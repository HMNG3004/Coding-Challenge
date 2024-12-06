using Day_6_Guard_Gallivant;
using LibraryHelper;
using System.Drawing;

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
        var s = ReadFile.Instance.ReadFileAsString(filePath);
        var lines = s.Split("\n");
        char target = '^';
        var location = FindCharacter(lines, target);
        Part1.ProcessString(lines, location.Value);
        Part2.ProcessString(lines);
    }

    static (int, int)? FindCharacter(string[] array, char target)
    {
        for (int row = 0; row < array.Length; row++)
        {
            int col = array[row].IndexOf(target);
            if (col != -1)
            {
                return (row, col);
            }
        }
        return null;
    }
}