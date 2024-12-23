public class Program
{
    public static void Main()
    {
        TestCase([1, 2, 3, 4], [24, 12, 8, 6], "Test case 1");
    }

    public static void TestCase(int[] nums, int[] expectation, string description)
    {
        var result = ProductExceptSelf(nums);
        string resultString = string.Join(", ", result);
        string expectationString = string.Join(", ", expectation);
        Console.WriteLine($"{description} {(resultString == expectationString ? "Passed" : "Failed")}");
    }

    public static int[] ProductExceptSelf(int[] nums)
    {
        var n = nums.Length;
        var output = new int[n];
        output[0] = 1;
        for (var i = 1; i < n; i++)
        {
            output[i] = output[i - 1] * nums[i - 1];
        }

        int suffix = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            output[i] *= suffix;
            suffix *= nums[i];
        }

        return output;
    }
}