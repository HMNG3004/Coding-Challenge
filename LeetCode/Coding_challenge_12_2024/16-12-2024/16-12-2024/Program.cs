public class Program
{
    public static void Main()
    {
        TestCase([2, 1, 3, 5, 6], 5, 2, [8, 4, 6, 5, 6], "Test case 1");
    }

    public static void TestCase(int[] nums, int k, int multiplier, int[] expectation, string description)
    {
        var result = GetFinalState(nums, k, multiplier);
        var hasDuplicates = result.Intersect(expectation).Any();
        Console.WriteLine($"{description} {(hasDuplicates ? "Passed" : "Failed")}");
    }

    public static int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        for (int i = 0; i < k; i++)
        {
            var min = int.MaxValue;
            var minIndex = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] < min)
                {
                    min = nums[j];
                    minIndex = j;
                }
            }

            nums[minIndex] *= multiplier;
        }
        return nums;
    }
}