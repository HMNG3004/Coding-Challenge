public class Program
{
    public static void Main()
    {
        var result = LongestSubarray2(new int[] { 0, 1, 1, 1, 0, 1, 1, 0, 1 });
        Console.WriteLine(result);
    }

    public static void TestCase()
    {

    }

    public static int LongestSubarray(int[] nums)
    {
        int left = 0;
        int zeroCount = 0;
        int max = 0;
        for(int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
            {
                zeroCount++;
            }
                        

            while(zeroCount > 1)
            {
                if (nums[left] == 0)
                {
                    zeroCount--;
                }
                left++;
            }

            max = Math.Max(max, right - left);
        }

        return max;
    }

    public static int LongestSubarray2(int[] nums)
    {
        int left = 0;
        int lastZero = -1;
        int max = 0;
        for(int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
            {
                left = lastZero + 1;
                lastZero = right;
            }
            
            max = Math.Max(max, right - left);
        }

        return max;
    }
}