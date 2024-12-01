public class Solution
{
    public static void Main()
    {
        TestCase();
        TestCase2();
    }

    public static void TestCase()
    {
        int[] arr = { 1, 3, 4, 8 };
        int[][] queries = { [0, 1], [1, 2], [0, 3], [3, 3] };
        int[] result = XorQueries(arr, queries);
        Console.WriteLine(string.Join(", ", result));
    }

    public static void TestCase2()
    {
        int[] arr = { 4, 8, 2, 10 };
        int[][] queries = { [2, 3], [1, 3], [0, 0], [0, 3] };
        int[] result = XorQueries(arr, queries);
        Console.WriteLine(string.Join(", ", result));
    }

    //public static int[] XorQueries(int[] arr, int[][] queries)
    //{
    //    int[] array = new int[queries.Length];
    //    int index = 0;
    //    foreach (int[] nums in queries)
    //    {
    //        int xorResult = 0;
    //        int start = nums[0];
    //        int end = nums[1];
    //        for (int i = start; i <= end; i++)
    //        {
    //            xorResult ^= arr[i];
    //        }
    //        array[index] = xorResult;
    //        index++;
    //    }
    //    return array;
    //}

    public static int[] XorQueries(int[] arr, int[][] queries)
    {
        int[] prefixSum = new int[arr.Length + 1];

        prefixSum[0] = 0;

        for (int i = 1; i <= arr.Length; i++)
        {
            prefixSum[i] = prefixSum[i - 1] ^ arr[i - 1];
        }

        int[] result = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            result[i] = prefixSum[queries[i][0]] ^ prefixSum[queries[i][1] + 1];
        }

        return result;
    }
}