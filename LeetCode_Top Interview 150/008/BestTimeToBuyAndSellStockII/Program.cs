public class Program
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
        TestCase3();
    }

    public static void TestCase1()
    {
        int[] price = [7, 1, 5, 3, 6, 4];
        int result = MaxProfit(price);
        Console.WriteLine(result);
    }

    public static void TestCase2()
    {
        int[] price = [1, 2, 3, 4, 5];
        int result = MaxProfit(price);
        Console.WriteLine(result);
    }

    public static void TestCase3()
    {
        int[] price = [7, 6, 4, 3, 1];
        int result = MaxProfit(price);
        Console.WriteLine(result);
    }

    public static int MaxProfit(int[] prices)
    {
        int max = 0;
        int start = prices[0];
        int len = prices.Length;
        for (int i = 1; i < len; i++)
        {
            if (start < prices[i])
            {
                max += prices[i] - start;
            }
            start = prices[i];
        }
        return max;
    }
}