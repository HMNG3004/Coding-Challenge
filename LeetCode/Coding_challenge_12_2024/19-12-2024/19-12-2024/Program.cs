public class Program
{
    public static void Main()
    {
        TestCase([1, 0, 2, 3, 4], 4, "Test Case 1");
        TestCase([4, 3, 2, 1, 0], 1, "Test Case 2");
    }

    public static void TestCase(int[] arr, int expectation, string description)
    {
        var result = MaxChunksToSorted(arr);
        Console.WriteLine($"{description} : {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int MaxChunksToSorted(int[] arr)
    {
        int n = arr.Length;
        int[] max = arr.Clone() as int[];
        int[] min = arr.Clone() as int[];

        for(int i = 1; i < n; i++)
        {
            max[i] = Math.Max(max[i - 1], max[i]);
        }

        for (int i = n - 2; i >= 0; i--)
        {
            min[i] = Math.Min(min[i + 1], min[i]);
        }

        int chunks = 0;
        for (int i = 0; i < n; i++)
        {
            if (i == 0 || min[i] > max[i - 1])
            {
                chunks++;
            }
        }

        return chunks;
    }
}