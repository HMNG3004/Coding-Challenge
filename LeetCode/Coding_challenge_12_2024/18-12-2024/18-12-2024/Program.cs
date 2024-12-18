public class Program
{
    public static void Main()
    {
        TestCase([8, 4, 6, 2, 3], [4, 2, 4, 2, 3], "Test case 1");
        TestCase([1, 2, 3, 4, 5], [1, 2, 3, 4, 5], "Test case 2");
        TestCase([10, 1, 1, 6], [9, 0, 1, 6], "Test case 3");
    }

    public static void TestCase(int[] prices, int[] expectation, string description)
    {
        var result = FinalPrices(prices);
        var resultString = string.Join(",", result);
        var expectationString = string.Join(",", expectation);
        Console.WriteLine($"{description} : {(expectationString == resultString ? "Passed" : "Failed")}");
    }

    public static int[] FinalPrices(int[] prices)
    {
        for (int i = 0; i < prices.Length; i++)
        {
            for(int j = i + 1; j < prices.Length; j++)
            {
                if (prices[j] <= prices[i])
                {
                    prices[i] -= prices[j];
                    break;
                }
            }
        }
        return prices;
    }
}