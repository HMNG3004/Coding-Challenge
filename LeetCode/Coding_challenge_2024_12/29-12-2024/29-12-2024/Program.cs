public class Program
{
    public static void Main()
    {
        TestCase(["acca", "bbbb", "caca"], "aba", 6, "Test Case 1");
        TestCase(["abba", "baab"], "bab", 4, "Test Case 2");
    }

    public static void TestCase(string[] words, string target, int expectation, string description)
    {
        var result = NumWays(words, target);
        System.Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int NumWays(string[] words, string target)
    {
        int MOD = (int)1e9 + 7;
        int n = words[0].Length;
        int m = target.Length;

        int[][] freq = new int[n][];
        for (int i = 0; i < n; i++)
        {
            freq[i] = new int[26];
        }

        foreach (var word in words)
        {
            for (int i = 0; i < n; i++)
            {
                freq[i][word[i] - 'a']++;
            }
        }

        int[][] memo = new int[n + 1][];
        for (int i = 0; i < n + 1; i++)
        {
            memo[i] = new int[m + 1];
            for (int j = 0; j < m + 1; j++)
            {
                memo[i][j] = -1;
            }
        }

        return Traverse(0, 0, freq, target, memo, MOD);
    }

    private static int Traverse(int level, int index, int[][] freq, string target, int[][] memo, int MOD)
    {
        if (index == target.Length)
        {
            return 1;
        }
        if (level == freq.Length)
        {
            return 0;
        }
        if (memo[level][index] != -1)
        {
            return memo[level][index];
        }

        int ways = Traverse(level + 1, index, freq, target, memo, MOD);

        if (freq[level][target[index] - 'a'] > 0)
        {
            ways = (int)((ways + (long)freq[level][target[index] - 'a'] * Traverse(level + 1, index + 1, freq, target, memo, MOD)) % MOD);
        }

        memo[level][index] = ways;
        return ways;
    }
}