public class Program
{
    public static void Main()
    {
        TestCase(3, 3, 1, 1, 8, "Test case 1");
        TestCase(2, 3, 1, 2, 5, "Test case 2");
    }

    public static void TestCase(int low, int high, int zero, int one, int expectation, string description)
    {
        var result = CountGoodStrings(low, high, zero, one);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int CountGoodStrings(int low, int high, int zero, int one)
    {
        const int Mod = 1_000_000_007;
        var dp = new int[high + 1];
        dp[0] = 1;

        var result = 0;

        for (var i = 1; i <= high; ++i)
        {
            if (i >= zero)
            {
                dp[i] = (dp[i] + dp[i - zero]) % Mod;
            }

            if (i >= one)
            {
                dp[i] = (dp[i] + dp[i - one]) % Mod;
            }

            if (i >= low)
            {
                result = (result + dp[i]) % Mod;
            }
        }

        return result;
    }
}