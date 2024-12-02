//You are given an array prices where prices[i] is the price of a given stock on the ith day.

//You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

//Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.You are given an array prices where prices[i] is the price of a given stock on the ith day.

//You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

//Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

public class Program
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    public static void TestCase1()
    {
        int[] prices = { 7, 1, 5, 3, 6, 4 };
        Console.WriteLine(MaxProfit(prices));
    }

    public static void TestCase2()
    {
        int[] prices = { 1, 2, 4 };
        Console.WriteLine(MaxProfit(prices));
    }
    public static int MaxProfit(int[] prices)
    {
        if (prices.Length < 2)
        {
            return 0;
        }

        int minPrice = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            int currentProfit = prices[i] - minPrice;

            maxProfit = Math.Max(maxProfit, currentProfit);

            minPrice = Math.Min(minPrice, prices[i]);
        }

        return maxProfit;
    }
}