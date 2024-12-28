public class Program
{
    public static void Main()
    {
        TestCase([1, 7, 3, 6, 5, 6], 3, "Test case 1");
        TestCase([1, 2, 3], -1, "Test case 2");
        TestCase([2, 1, -1], 0, "Test case 3");
    }

    public static void TestCase(int[] nums, int expectation, string description)
    {
        var result = PivotIndex2(nums);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int PivotIndex(int[] nums)
    {
        int result = -1;
        int start = 0;
        int[] prefixSum = new int[nums.Length + 1];
        int[] suffixSum = new int[nums.Length + 1];
        prefixSum[0] = 0;
        suffixSum[nums.Length - 1] = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
            suffixSum[nums.Length - 1 - i] = suffixSum[nums.Length - i] + nums[nums.Length - 1 - i];
        }

        while (start < suffixSum.Length - 1)
        {
            if (prefixSum[start] == suffixSum[start + 1])
            {
                result = start;
                break;
            }
            start++;
        }

        return result;
    }

    public static int PivotIndex2(int[] nums)
    {
        int totalSum = 0;
        int leftSum = 0;

        foreach (int num in nums)
        {
            totalSum += num;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (leftSum == totalSum - leftSum - nums[i])
            {
                return i;
            }
            leftSum += nums[i];
        }

        return -1;
    }
}