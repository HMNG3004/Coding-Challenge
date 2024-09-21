public class Solution
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    public static void TestCase1()
    {
        IList<int> result = LexicalOrder(13);
        Console.WriteLine(String.Join(", ", result));
    }

    public static void TestCase2()
    {
        IList<int> result = LexicalOrder(2);
        Console.WriteLine(String.Join(", ", result));
    }

    public static IList<int> LexicalOrder(int n)
    {
        List<int> result = new List<int>();
        int current = 1;

        for (int i = 0; i < n; i++)
        {
            result.Add(current);
            if (current * 10 <= n)
            {
                current *= 10;
            }
            else
            {
                while (current % 10 == 9 || current + 1 > n)
                {
                    current /= 10;
                }
                current++;
            }
        }

        return result;
    }
}