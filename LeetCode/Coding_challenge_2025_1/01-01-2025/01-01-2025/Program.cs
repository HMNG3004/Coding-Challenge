public class Program
{
    public static void Main()
    {
        TestCase("011101", 5, "Test case 1");
        TestCase("00111", 5, "Test case 2");
        TestCase("1111", 3, "Test case 3");
    }

    public static void TestCase(string s, int expectation, string description)
    {
        var result = MaxScore(s);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int MaxScore(string s)
    {
        int max = 0;
        int countOne = 0, countZero = 0;
        foreach (char c in s)
        {
            if (c == '1')
            {
                countOne++;
            }
        }

        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == '0')
            {
                countZero++;
            }
            else
            {
                countOne--;
            }
            max = Math.Max(max, countOne + countZero);
        }

        return max;
    }
}