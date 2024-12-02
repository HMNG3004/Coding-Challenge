public class Program
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    private static int MajorityElement(int[] nums)
    {
        int count = 0;
        int candidate = 0;

        foreach (int num in nums)
        {
            if (count == 0)
            {
                candidate = num;
            }

            count += (num == candidate) ? 1 : -1;
        }
        return candidate;
    }

    private static int MajorityElement2(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, int> map = new Dictionary<int, int>();

        foreach (int val in nums)
        {
            if (map.ContainsKey(val))
                map[val]++;
            else
                map[val] = 1;
        }

        foreach (var pair in map)
        {
            int freq = pair.Value;
            if (freq > n / 2)
            {
                return pair.Key;
            }
        }
        return -1;
    }

    private static void TestCase1()
    {
        int[] nums = { 3, 2, 3 };
        Console.WriteLine(MajorityElement(nums));
    }

    private static void TestCase2()
    {
        int[] nums = { 2, 2, 1, 1, 1, 2, 2 };
        Console.WriteLine(MajorityElement2(nums));
    }
}