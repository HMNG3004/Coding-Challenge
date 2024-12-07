using Day_7_Bridge_Repair;
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
        var lines = s.Split("\n");
        Part1_SolutionOne.ProcessString(lines);
        Part1_SolutionTwo.ProcessString(lines);
        Part2_SolutionOne.ProcessString(lines);
        Part2_SolutionTwo.ProcessString(lines);
    }
}