using Day_2_Red_Nosed_Reports;
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
        var rows = ReadFile.Instance.ReadAndSplitFile(filePath);
        Part1.ProcessList(rows);
        Part2.ProcessList(rows);
    }
}