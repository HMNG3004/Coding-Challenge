public class Program
{
    public static void Main()
    {
        TestCase([3, 4, 5, 1, 2], true, "Test Case 1");
        TestCase([2, 1, 3, 4], false, "Test Case 2");
        TestCase([1, 2, 3], true, "Test Case 3");
    }

    public static void TestCase(int[] nums, bool expectation, string description)
    {
        var result = Check(nums);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static bool Check(int[] nums)
    {
        int count = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] > nums[i + 1])
            {
                count++;
            }

            if (count > 1)
                return false;
        }

        if (count == 1)
        {
            if (nums[nums.Length - 1] > nums[0])
                return false;
        }

        return true;
    }
}