public class Solution
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    public static void TestCase1()
    {
        int[] nums = { 1, 2, 3, 3, 2, 2 };
        int result = LongestSubarray(nums);
        Console.WriteLine(result);
    }

    public static void TestCase2()
    {
        int[] nums = { 1, 2, 3, 4 };
        int result = LongestSubarray(nums);
        Console.WriteLine(result);
    }

    public static int LongestSubarray(int[] nums)
    {
        int maximumElement = nums.Max(x => x);
        int maxLength = 0;
        int currentLength = 0;

        foreach (int num in nums)
        {
            if (num == maximumElement)
            {
                currentLength++;
            }
            else
            {
                maxLength = Math.Max(maxLength, currentLength);
                currentLength = 0;
            }
        }

        maxLength = Math.Max(maxLength, currentLength);
        return maxLength;
    }
}