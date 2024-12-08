public class Program
{
    public static void Main()
    {
        TestCase([[1, 3, 2], [4, 5, 2], [2, 4, 3]], 4, "Test Case 1");
        TestCase([[1, 3, 2], [4, 5, 2], [1, 5, 5]], 5, "Test Case 2");
        TestCase([[1, 5, 3], [1, 5, 1], [6, 6, 5]], 8, "Test Case 3");
    }

    public static void TestCase(int[][] events, int expected, string description)
    {
        var result = maxTwoEvents(events);
        Console.WriteLine($"{description} {(result == expected ? "Passed" : "Failed")}");
    }

    public static int maxTwoEvents(int[][] events)
    {
        var pq = new SortedSet<(int end, int value)>(Comparer<(int end, int value)>.Create((a, b) =>
        {
            if (a.end != b.end)
                return a.end - b.end;
            return a.value - b.value;
        }));

        Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));

        int maxVal = 0, maxSum = 0;

        foreach (var eventItem in events)
        {
            while (pq.Count > 0 && pq.Min.end < eventItem[0])
            {
                maxVal = Math.Max(maxVal, pq.Min.value);
                pq.Remove(pq.Min);
            }

            maxSum = Math.Max(maxSum, maxVal + eventItem[2]);
            pq.Add((eventItem[1], eventItem[2]));
        }

        return maxSum;
    }
}