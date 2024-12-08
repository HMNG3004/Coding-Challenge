using Day_8_Resonant_Collinearity;
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

        string input = File.ReadAllText(filePath);
        var data = HelperClass.ParseData(input);

        ProcessParts(filePath);
    }

    public static void ProcessParts(string filePath)
    {
        string input = ReadFile.Instance.ReadFileAsString(filePath);
        var data = HelperClass.ParseData(input);
        Part1.ProcessString(data);
        Part2.ProcessString(data);
    }
}