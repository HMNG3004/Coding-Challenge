public class Program
{
    public static void Main()
    {
        TestCase([10, 4, -8, 7], 2, "Test case 1");
        TestCase([2, 3, 1, 0], 2, "Test case 2");
    }

    public static void TestCase(int[] nums, int expectation, string description)
    {
        var result = WaysToSplitArray(nums);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int WaysToSplitArray(int[] nums)
    {
        long totalSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            totalSum += nums[i];
        }

        long prefixSum = 0;
        int totalWays = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            prefixSum += nums[i];
            long suffixSum = totalSum - prefixSum;

            if (prefixSum >= suffixSum)
            {
                totalWays++;
            }
        }

        return totalWays;
    }
}