public class Program
{
    public static void Main()
    {
        TestCase([1, 2, 2, 1, 1, 3], true, "Test case 1");
        TestCase([1, 2], false, "Test case 2");
        TestCase([-3, 0, 1, -3, 1, 1, 1, -3, 10, 0], true, "Test case 3");
    }

    public static void TestCase(int[] arr, bool expectation, string description)
    {
        var result = UniqueOccurrences(arr);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static bool UniqueOccurrences(int[] arr)
    {
        var occur = new Dictionary<int, int>();
        foreach (var item in arr)
        {
            if (occur.ContainsKey(item))
            {
                occur[item]++;
            }
            else
            {
                occur.Add(item, 1);
            }
        }

        var set = new HashSet<int>();
        foreach (var count in occur)
        {
            if (!set.Add(count.Value)) return false;
        }
        return true;
    }
}