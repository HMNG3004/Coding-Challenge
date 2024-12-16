public class Program
{
    public static void Main()
    {
        TestCase([1, 2, 3, 4, 5], true, "Test Case 1");
        TestCase([5, 4, 3, 2, 1], false, "Test Case 2");
        TestCase([2, 1, 5, 0, 4, 6], true, "Test Case 3");
    }

    public static void TestCase(int[] nums, bool expectation, string description)
    {
        var result = IncreasingTriplet(nums);
        Console.WriteLine($"{description} : {(result == expectation ? "Passed" : "Failed")}");
    }

    public static bool IncreasingTriplet(int[] nums)
    {
        if (nums.Length < 3)
            return false;

        int first = int.MaxValue;
        int second = int.MaxValue;

        foreach (int num in nums)
        {
            if (num <= first)
            {
                first = num;
            }
            else if (num <= second)
            {
                second = num;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}