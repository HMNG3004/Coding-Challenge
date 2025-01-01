public class Program
{
    public static void Main()
    {
        TestCase([1, 4, 6, 7, 8, 20], [2, 7, 15], 11, "Test case 1");
        TestCase([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31], [2, 7, 15], 17, "Test case 1");
    }

    public static void TestCase(int[] days, int[] costs, int expectation, string description)
    {
        var result = MincostTickets(days, costs);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int MincostTickets(int[] days, int[] costs)
    {
        int n = days.Length;
        int[] dp = new int[366]; // DP array for days 0 to 365

        for (int i = 1; i <= 365; i++)
        {
            // If it's not a travel day, carry forward the previous cost
            if (IsTravelDay(days, n, i))
            {
                // Calculate the cost for each type of ticket
                int cost1 = dp[i - 1] + costs[0]; // 1-day pass
                int cost7 = dp[Math.Max(0, i - 7)] + costs[1]; // 7-day pass
                int cost30 = dp[Math.Max(0, i - 30)] + costs[2]; // 30-day pass

                // Take the minimum of the three options
                dp[i] = Math.Min(cost1, Math.Min(cost7, cost30));
            }
            else
            {
                // If it's not a travel day, just carry forward the previous cost
                dp[i] = dp[i - 1];
            }
        }

        // The answer is the minimum cost to cover all travel days
        return dp[365];
    }

    private static bool IsTravelDay(int[] days, int n, int day)
    {
        for (int i = 0; i < n; i++)
        {
            if (days[i] == day)
            {
                return true;
            }
            if (days[i] > day)
            {
                break; // Since days are strictly increasing
            }
        }
        return false;
    }
}