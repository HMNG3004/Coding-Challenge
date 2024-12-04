using Day_4_Ceres_Search;
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

    public static void ProcessParts(string filePath)
    {
        var s = ReadFile.Instance.ReadFileAsString(filePath);
        string[] lines = s.Split(new[] { '\n' }, StringSplitOptions.None);
        Part1.ProcessString(lines);
        Part2.ProcessString(lines);
    }
}