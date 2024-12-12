public class Program
{
    public static void Main()
    {
        TestCase([25, 64, 9, 4, 100], 4, 29, "Test Case 1");
        TestCase([1, 1, 1, 1], 4, 4, "Test Case 2");
    }

    public static void TestCase(int[] nums, int k, int expected, string description)
    {
        var result = PickGifts(nums, k);
        Console.WriteLine($"{description} {(result == expected ? "Passed" : "Failed")}");
    }

    public static long PickGifts(int[] gifts, int k)
    {
        for (int i = 0; i < k; ++i)
        {
            var maxGifts = 0;
            var pileIndex = 0;
            for (int j = 0; j < gifts.Length; ++j)
            {
                if (maxGifts < gifts[j])
                {
                    maxGifts = gifts[j];
                    pileIndex = j;
                }
            }

            gifts[pileIndex] = (int)Math.Sqrt(gifts[pileIndex]);
        }

        long remaining = 0;
        for (int i = 0; i < gifts.Length; ++i)
        {
            remaining += gifts[i];
        }

        return remaining;
    }
}