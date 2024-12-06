public class Program
{
    public static void Main()
    {
        TestCase([1, 6, 5], 5, 6, 2, "Test case 1:");
        TestCase([1, 2, 3, 4, 5, 6, 7], 8, 1, 0, "Test case 2:");
        TestCase([11], 7, 50, 7, "Test case 3:");
    }

    public static void TestCase(int[] banned, int n, int maxSum, int expected, string description)
    {
        var result = MaxCount(banned, n, maxSum);
        Console.WriteLine($"{description} {(result == expected ? "Passed" : "Failed")}");
    }

    public static int MaxCount(int[] banned, int n, int maxSum)
    {
        int count = 0;
        for (int i = 1; i <= n; i++)
        {
            if (!banned.Contains(i))
            {
                if (maxSum - i >= 0)
                {
                    maxSum -= i;
                    count++;
                }
                else
                {
                    break;
                }
            }
        }
        return count;
    }
}