public class Program
{
    public static void Main()
    {
        TestCase([1, 4, 3, 3, 2], 2, "Test case 1");
        TestCase([3, 3, 3, 3], 1, "Test case 2");
        TestCase([3, 2, 1], 3, "Test case 3");
    }

    public static void TestCase(int[] nums, int expectation, string description)
    {
        var result = LongestMonotonicSubarray(nums);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int LongestMonotonicSubarray(int[] nums)
    {
        int inc = 1, dec = 1, maxLen = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                inc++;
                dec = 1;
            }
            else if (nums[i] < nums[i - 1])
            {
                dec++;
                inc = 1;
            }
            else
            {
                inc = 1;
                dec = 1;
            }
            maxLen = Math.Max(maxLen, Math.Max(inc, dec));
        }

        return maxLen;
    }
}