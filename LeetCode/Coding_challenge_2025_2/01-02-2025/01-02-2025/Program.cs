public class Program
{
    public static void Main()
    {
        TestCase([1], true, "Test Case 1");
        TestCase([2, 1, 4], true, "Test Case 2");
        TestCase([4, 3, 1, 6], false, "Test Case 3");
    }

    public static void TestCase(int[] nums, bool expectation, string description)
    {
        var result = IsArraySpecial(nums);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static bool IsArraySpecial(int[] nums)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if ((nums[i] % 2) == (nums[i + 1] % 2))
                return false;
        }

        return true;
    }
}