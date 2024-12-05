using Day_5_Print_Queue;
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
        // Initialize arrays
        List<string> pipeSeparated = new List<string>();
        List<string> commaSeparated = new List<string>();

        // Separate lines into respective arrays
        foreach (string line in lines)
        {
            if (line.Contains("|"))
            {
                pipeSeparated.Add(line);
            }
            else if (line.Contains(","))
            {
                commaSeparated.Add(line);
            }
        }

        // Convert to arrays and print the results
        string[] array1 = pipeSeparated.ToArray();
        string[] array2 = commaSeparated.ToArray();

        var orderRules = new Dictionary<int, HashSet<int>>();
        foreach (var rule in pipeSeparated)
        {
            var parts = rule.Split('|').Select(int.Parse).ToArray();
            if (!orderRules.ContainsKey(parts[0]))
                orderRules[parts[0]] = new HashSet<int>();
            orderRules[parts[0]].Add(parts[1]);
        }

        Part1.ProceesString(orderRules, array2);
        Part2.ProceesString(orderRules, array2);
    }

}