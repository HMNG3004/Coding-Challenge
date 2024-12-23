public class Program
{
    public static void Main()
    {
        TestCase([6, 4, 8, 5, 2, 7], [[0, 1], [0, 3], [2, 4], [3, 4], [2, 2]], [2, 5, -1, 5, 2], "Test case 1");
        TestCase([5, 3, 8, 2, 6, 1, 4, 6], [[0, 7], [3, 5], [5, 2], [3, 0], [1, 6]], [7, 6, -1, 4, 6], "Test case 2");
    }

    public static void TestCase(int[] heights, int[][] queries, int[] expectation, string description)
    {
        var result = LeftmostBuildingQueries(heights, queries);
        var resultString = string.Join(",", result);
        var expectationString = string.Join(",", expectation);
        Console.WriteLine($"{description} : {(resultString == expectationString ? "Passed" : "Failed")}");
    }

    public static int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
    {
        int n = heights.Length;
        int[,] st = new int[n, 20];
        int[] log = new int[n + 1];
        log[0] = -1;

        for (int i = 1; i <= n; i++)
        {
            log[i] = log[i >> 1] + 1;
        }

        for (int i = 0; i < n; i++)
        {
            st[i, 0] = heights[i];
        }

        for (int i = 1; i < 20; i++)
        {
            for (int j = 0; j + (1 << i) <= n; j++)
            {
                st[j, i] = Math.Max(st[j, i - 1], st[j + (1 << (i - 1)), i - 1]);
            }
        }

        int[] res = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            int l = queries[i][0], r = queries[i][1];
            if (l > r)
            {
                int temp = l;
                l = r;
                r = temp;
            }

            if (l == r)
            {
                res[i] = l;
                continue;
            }

            if (heights[r] > heights[l])
            {
                res[i] = r;
                continue;
            }

            int maxHeight = Math.Max(heights[l], heights[r]);
            int left = r + 1, right = n, mid;

            while (left < right)
            {
                mid = (left + right) / 2;
                int k = log[mid - r + 1];
                int maxInRange = Math.Max(st[r, k], st[mid - (1 << k) + 1, k]);

                if (maxInRange > maxHeight)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            res[i] = (left == n) ? -1 : left;
        }

        return res;
    }
}