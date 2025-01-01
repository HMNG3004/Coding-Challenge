public class Program
{
    public static void Main()
    {
        TestCase([9], 2, 3, "Test case 1:");
        TestCase([2, 4, 8, 2], 4, 2, "Test case 2:");
    }

    public static void TestCase(int[] nums, int maxOperation, int expected, string description)
    {
        var result = MinimumSize(nums, maxOperation);
        Console.WriteLine($"{description} {(result == expected ? "Passed" : "Failed")}");
    }


    public static int MinimumSize(int[] nums, int maxOperations)
    {
        int left = 1;
        int right = int.MinValue;
        foreach (var num in nums)
        {
            right = Math.Max(right, num);
        }

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (CanDistribute(nums, mid, maxOperations))
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }

    private static bool CanDistribute(int[] nums, int penalty, int maxOperations)
    {
        int operations = 0;
        foreach (var num in nums)
        {
            operations += (num - 1) / penalty;
            if (operations > maxOperations)
            {
                return false;
            }
        }
        return true;
    }
}