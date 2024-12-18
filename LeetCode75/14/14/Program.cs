public class Program
{
    public static void Main()
    {
        TestCase([0, 4, 0, 3, 2], 1, 4.00000, "Test Case 1");
        TestCase([5], 1, 5.00000, "Test Case 2");
    }

    public static void TestCase(int[] nums, int k, double expectation, string description)
    {
        var result = FindMaxAverage(nums, k);
        result = Math.Round(result, 5);
        Console.WriteLine($"{description} : {(result == expectation ? "Passed" : "Failed")}");
    }

    public static double FindMaxAverage(int[] nums, int k)
    {
        double max = 0;
        for (int i = 0; i < k; i++)
        {
            max += nums[i];
        }
        double window_sum = max;
        for (int i = k; i < nums.Length; i++)
        {
            window_sum += nums[i] - nums[i - k];
            max = Math.Max(max, window_sum);
        }

        return max / k;
    }
}