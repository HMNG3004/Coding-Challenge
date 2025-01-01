public class Program
{
    public static void Main()
    {
        TestCase([4, 6, 1, 2], 2, 3, "Test Case 1");
    }

    public static void TestCase(int[] nums, int k, int expected, string description)
    {
        var result = Solution(nums, k);
        Console.WriteLine($"{description} {(result == expected ? "Passed" : "Failed")}");
    }

    //Approach 1: Binary Search
    public static int MaximumBeauty(int[] nums, int k)
    {
        Array.Sort(nums);
        int maxBeauty = 0;

        for(int i = 0; i < nums.Length; i++)
        {
            int upperBound = FindUpperBound(nums, nums[i] + 2 * k);

            maxBeauty = Math.Max(maxBeauty, upperBound - i + 1);
        }
        
        return maxBeauty;
    }

    public static int FindUpperBound(int[] nums, int k)
    {
        int left = 0;
        int right = nums.Length - 1;
        int upperBound = 0;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] <= k)
            {
                upperBound = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return upperBound;
    }

    //Approach 2: Sliding Window
    public static int Solution(int[] nums, int k)
    {
        Array.Sort(nums);
        int right = 0;
        int maxBeauty = 0;

        for(int left = 0; left < nums.Length; left++)
        {
            while(right < nums.Length && nums[right] - nums[left] <= 2 * k)
            {
                right++;
            }

            maxBeauty = Math.Max(maxBeauty, right - left);
        }
        return maxBeauty;
    }
}