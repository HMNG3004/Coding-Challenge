//You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.

//Return true if you can reach the last index, or false otherwise.

public class Program
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    public static void TestCase1()
    {
        int[] nums = [2, 3, 1, 1, 4];
        bool result = CanJump(nums);
        Console.WriteLine(result);
    }

    public static void TestCase2()
    {
        int[] nums = [3, 2, 1, 0, 4];
        bool result = CanJump(nums);
        Console.WriteLine(result);
    }

    public static bool CanJump(int[] nums)
    {
        int lastPos = nums.Length - 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if(i + nums[i] >= lastPos)
            {
                lastPos = i;
                if (lastPos == 0)
                {
                    return true;
                }
            }            
        }
        return false;
    }
}