public class Program
{
    public static void Main()
    {
        TestCase([3, 4, 1, 2, 6], [[0, 4]], [false], "Test case 1");
        TestCase([4, 3, 1, 6], [[0, 2], [2, 3]], [false, true], "Test case 2");
    }

    public static void TestCase(int[] nums, int[][] queries, bool[] expected, string description)
    {
        var result = IsArraySpecial(nums, queries);
        Console.WriteLine($"result: {string.Join(", ", result)}");
        var hasDuplicates = expected.Intersect(result).Any();
        Console.WriteLine($"{description} {(hasDuplicates ? "Passed" : "Failed")}");
    }

    public static bool[] IsArraySpecial(int[] nums, int[][] queries)
    {
        bool[] ans = new bool[queries.Length];
        List<int> violatingIndices = new List<int>();

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] % 2 == nums[i - 1] % 2)
            {
                violatingIndices.Add(i);
            }
        }

        for (int i = 0; i < queries.Length; i++)
        {
            int[] query = queries[i];
            int start = query[0];
            int end = query[1];

            bool foundViolatingIndex = BinarySearch(start + 1, end, violatingIndices);

            ans[i] = !foundViolatingIndex;
        }

        return ans;
    }

    private static bool BinarySearch(int start, int end, List<int> violatingIndices)
    {
        int left = 0;
        int right = violatingIndices.Count() - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int violatingIndex = violatingIndices[mid];

            if (violatingIndex < start)
            {
                left = mid + 1;
            }
            else if (violatingIndex > end)
            {
                right = mid - 1;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}