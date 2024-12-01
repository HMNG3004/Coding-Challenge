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

        var (array1, array2) = ReadAndSplitFile(filePath); 
        CalculateDistance(array1, array2);
        CalculateTotalSimilarity(array1, array2);
    }

    public static (int[], int[]) ReadAndSplitFile(string filePath)
    {
        List<int> column1 = new List<int>();
        List<int> column2 = new List<int>();

        foreach (var line in File.ReadLines(filePath))
        {
            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 2 && int.TryParse(parts[0], out int num1) && int.TryParse(parts[1], out int num2))
            {
                column1.Add(num1);
                column2.Add(num2);
            }
        }

        return (column1.ToArray(), column2.ToArray());
    }

    public static void CalculateDistance(int[] array1, int[] array2)
    {

        array1 = array1.OrderBy(x => x).ToArray();
        array2 = array2.OrderBy(x => x).ToArray();
        int length = array1.Length;
        int totalDistance = 0;
        for (int i = 0; i < length; i++)
        {
            int distance = Math.Abs(array1[i] - array2[i]);
            totalDistance += distance;
        }
        Console.WriteLine(totalDistance);
    }

    public static void CalculateTotalSimilarity(int[] array1, int[] array2)
    {
        int length = array1.Length;
        int totalScore = 0;
        for (int i = 0; i < length; i++)
        {
            int num = array1[i];
            int similarity = CalculateSimilarity(num, array2);
            totalScore += (similarity * num);
        }
        Console.WriteLine(totalScore);
    }

    public static int CalculateSimilarity(int num, int[] array2)
    {
        int totalApperance = 0;
        for(int i = 0; i < array2.Length; i++)
        {
            if (num == array2[i])
            {
                totalApperance++;
            }
        }
        return totalApperance;
    }
}