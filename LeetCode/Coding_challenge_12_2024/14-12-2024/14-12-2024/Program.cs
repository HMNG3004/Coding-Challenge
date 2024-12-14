public class Program
{
    public static void Main()
    {
        TestCase([5, 4, 2, 4], 8, "Test Case 1");
        TestCase([1, 2, 3], 6, "Test Case 2");

        //Case 100000 elements in array
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(currentDirectory, "input.txt");

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: Could not find file '{filePath}'. Ensure the file exists in the output directory.");
            return;
        }

        string mapInput = File.ReadAllText(filePath);
        int[] nums = mapInput.Split(',').Select(int.Parse).ToArray();
        TestCase(nums, 5000050000, "Test Case 3");
    }

    public static void TestCase(int[] nums, long expectation, string description)
    {
        var result = ContinuousSubarrays(nums);
        Console.WriteLine($"{description} {(result == expectation ? "Passed" : "Failed")}");
    }

    public static long ContinuousSubarrays(int[] nums)
    {
        long total = 0;
        int start = 0;

        var maxDeque = new LinkedList<int>();
        var minDeque = new LinkedList<int>();

        for (int end = 0; end < nums.Length; end++)
        {
            while (maxDeque.Count > 0 && nums[maxDeque.Last.Value] <= nums[end])
            {
                maxDeque.RemoveLast();
            }
            maxDeque.AddLast(end);

            while (minDeque.Count > 0 && nums[minDeque.Last.Value] >= nums[end])
            {
                minDeque.RemoveLast();
            }
            minDeque.AddLast(end);

            while (nums[maxDeque.First.Value] - nums[minDeque.First.Value] > 2)
            {
                start++;
                if (maxDeque.First.Value < start)
                {
                    maxDeque.RemoveFirst();
                }
                if (minDeque.First.Value < start)
                {
                    minDeque.RemoveFirst();
                }
            }

            total += end - start + 1;
        }

        return total;
    }
}