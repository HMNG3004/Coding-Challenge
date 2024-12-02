using Day_1_Historian_Hysteria;
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
        var columns = ReadFile.Instance.ReadAndSplitFileByColumns(filePath);

        if (columns.Length < 2)
        {
            Console.WriteLine("Error: File must contain at least two columns of data.");
            return;
        }

        int[] array1 = columns[0];
        int[] array2 = columns[1];

        Part1.CalculateDistance(array1, array2);
        Part2.CalculateTotalSimilarity(array1, array2);
    }
}