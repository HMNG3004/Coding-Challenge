using System;

public class Solution
{
    public long MinOperations(int[][] queries)
    {
        long totalResult = 0;

        foreach (var query in queries)
        {
            int l = query[0], r = query[1];
            long totalSteps = GetStepsSum(l, r);
            // ceil(totalSteps / 2)
            long operations = (totalSteps + 1) / 2;
            totalResult += operations;
        }

        return totalResult;
    }

    // Tính tổng số "steps" cần cho đoạn [l, r]
    private long GetStepsSum(int l, int r)
    {
        long total = 0;
        int k = 0;
        long rangeL = 1, rangeR = 3;

        while (rangeL <= r)
        {
            long left = Math.Max(l, rangeL);
            long right = Math.Min(r, rangeR);

            if (left <= right)
            {
                long count = right - left + 1;
                total += count * (k + 1);
            }

            rangeL *= 4;
            rangeR = rangeR * 4 + 3;
            k++;
        }

        return total;
    }
}

public class Program
{
    public static void Main()
    {
        TestCase([[1, 2], [2, 4]], 3, "Test Case 1"); 
        TestCase([[2, 6]], 4, "Test Case 2"); 
        TestCase([[5, 8]], 4, "Test Case 3");
    }

    public static void TestCase(int[][] queries, int expectation, string description)
    {
        var sol = new Solution();
        var result = sol.MinOperations(queries);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : $"Failed (Got {result}, Expected {expectation})")}");
    }
}
