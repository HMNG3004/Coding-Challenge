public class Program
{
    public static void Main()
    {
        TestCase([1, 2, 3], [2, 4, 6], "Test case 1:");
        TestCase([1, 2, 3, 3], [1, 1, 2, 2], "Test case 2:");
    }

    public static void TestCase(int[] nums1, int[] nums, string description)
    {
        Console.WriteLine(description);
        var result = FindDifference(nums1, nums);
        foreach (var item in result)
        {
            Console.WriteLine(string.Join(",", item));
        }
    }

    public static IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        var result = new List<IList<int>>();
        var listNums1 = Different(nums2, nums1);
        var listNums2 = Different(nums1, nums2);
        result.Add(listNums1);
        result.Add(listNums2);

        return result;
    }

    public static List<int> Different(int[] source, int[] target)
    {
        var targetSet = new HashSet<int>(target);

        foreach (var num in source)
        {
            if (targetSet.Contains(num))
            {
                targetSet.Remove(num);
            }
        }

        return targetSet.ToList();
    }
}