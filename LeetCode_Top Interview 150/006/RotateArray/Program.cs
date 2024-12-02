//Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.

public class Program
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    private static void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            int temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;
            start++;
            end--;
        }
    }

    public static void Rotate(int[] nums, int k)
    {
        int n = nums.Length;
        if (k < 0)
        {
            return;
        }

        Reverse(nums, 0, n - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, n - 1);
    }

    public static void TestCase1()
    {
        int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
        int k = 3;
        Rotate(nums, k);
        Console.WriteLine(string.Join(",", nums));
    }

    public static void TestCase2()
    {
        int[] nums = { -1, -100, 3, 99 };
        int k = 3;
        Rotate(nums, k);
        Console.WriteLine(string.Join(",", nums));
    }
}

//The approach to solve this question is:
//Step 1: to reverse the array
//Step 2: reverse the first k elements
//Step 3: reverse the remaining elements.