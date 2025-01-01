public class Program
{
    public static void Main()
    {
        TestCase([1, 2, 1, 2, 6, 7, 5, 1], 2, [0, 3, 5], "Test case 1");
        TestCase([1, 2, 1, 2, 1, 2, 1, 2, 1], 2, [0, 2, 4], "Test case 2");
    }

    public static void TestCase(int[] nums, int k, int[] expectation, string description)
    {
        var result = MaxSumOfThreeSubarrays(nums, k);
        var resultString = string.Join(",", result);
        var expectationString = string.Join(",", expectation);
        Console.WriteLine($"{description}: {(resultString == expectationString ? "Passed" : "Failed")}");
    }

    public static int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        var lefts = CaculateLeftMaxs(nums, k);
        var rights = CaculateRightMaxs(nums, k);
        var mids = CalculateMidSums(nums, k);
        var index1 = -1;
        var max = 0;
        for (int i = k; i <= nums.Length - k - k; i++)
        {
            var max0 = lefts[i - 1] + mids[i] + rights[i + k];
            if (max < max0)
            {
                max = max0;
                index1 = i;
            }
        }
        var index0 = CalculateIndex0(lefts[index1 - 1], nums, k);
        var index2 = CalculateIndex2(rights[index1 + k], index1 + k, nums, k);
        var rs = new[] { index0, index1, index2 };
        return rs;
    }
    private static int CalculateIndex2(int rightSum, int startIndex, int[] nums, int k)
    {
        var sum = 0;
        for (int i = startIndex; i < startIndex + k; i++)
        {
            sum += nums[i];
        }
        if (sum == rightSum) return startIndex;
        for (int i = startIndex + 1; i < nums.Length + 1 - k; i++)
        {
            sum += -nums[i - 1] + nums[i + k - 1];
            if (sum == rightSum) return i;
        }
        return -1;
    }
    private static int CalculateIndex0(int leftSum, int[] nums, int k)
    {
        var sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += nums[i];
        }
        if (sum == leftSum) return 0;
        for (int i = 1; i < nums.Length; i++)
        {
            sum += -nums[i - 1] + nums[i + k - 1];
            if (sum == leftSum) return i;
        }
        return -1;
    }
    private static int[] CalculateMidSums(int[] nums, int k)
    {
        var rs = new int[nums.Length];
        var sum = 0;
        for (int i = k; i < k + k; i++)
        {
            sum += nums[i];
        }
        rs[k] = sum;
        for (int i = k + k; i < nums.Length - k; i++)
        {
            sum += -nums[i - k] + nums[i];
            rs[i - k + 1] = sum;
        }
        return rs;
    }
    private static int[] CaculateLeftMaxs(int[] nums, int k)
    {
        var rs = new int[nums.Length];
        var sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += nums[i];
        }
        rs[k - 1] = sum;
        for (int i = k; i < nums.Length - k * 2; i++)
        {
            sum += -nums[i - k] + nums[i];
            rs[i] = Math.Max(sum, rs[i - 1]);
        }
        return rs;
    }
    private static int[] CaculateRightMaxs(int[] nums, int k)
    {
        var rs = new int[nums.Length];
        var sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += nums[nums.Length - 1 - i];
        }
        rs[rs.Length - k] = sum;
        for (int i = nums.Length - 1 - k; i >= k * 2; i--)
        {
            sum += -nums[i + k] + nums[i];
            rs[i] = Math.Max(sum, rs[i + 1]);
        }
        return rs;
    }
}