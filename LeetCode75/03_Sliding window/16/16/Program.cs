public class Program
{
    public static void Main()
    {
        TestCase([1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0], 2, 6, "Test case 1");
        TestCase([0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1], 3, 10, "Test case 2");
    }

    public static void TestCase(int[] nums, int k, int expectation, string description)
    {
        var result = LongestOnes(nums, k);
        Console.WriteLine($"{description} : {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int LongestOnes(int[] nums, int k)
    {
        int left = 0;
        int maxLength = 0;
        int zeroCount = 0;

        for(int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
            {
                zeroCount++;
            }

            while(zeroCount > k)
            {
                if (nums[left] == 0)
                {
                    zeroCount--;
                }
                left++;
            }
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        return maxLength;
    }
}