public class Program
{
    public static void Main()
    {
        TestCase([10, 20, 30, 5, 10, 50], 65, "Test Case 1");
        TestCase([10, 20, 30, 40, 50], 150, "Test Case 2");
        TestCase([12, 17, 15, 13, 10, 11, 12], 33, "Test Case 3");
    }

    public static void TestCase(int[] nums, int expectation, string description)
    {
        var result = MaxAscendingSum(nums);
        Console.WriteLine($"{description} : {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int MaxAscendingSum(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int maxSum = nums[0], currentSum = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                currentSum += nums[i];
            }
            else
            {
                maxSum = Math.Max(maxSum, currentSum);
                currentSum = nums[i];
            }
        }

        return Math.Max(maxSum, currentSum);
    }
}