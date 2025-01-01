public class Program
{
    public static void Main()
    {
        TestCase("aaaa", 2, "Test Case 1");
        TestCase("abcdef", -1, "Test Case 2");
        TestCase("cccerrrecdcdccedecdcccddeeeddcdcddedccdceeedccecde", 2, "Test Case 3");
    }

    public static void TestCase(string s, int expected, string description)
    {
        var result = MaximumLength(s);
        Console.WriteLine($"{description} {(result == expected ? "Passed" : "Failed")}");
    }

    public static int MaximumLength(string s)
    {
        int maxLength = -1;
        int n = s.Length;

        for (int len = 1; len <= n; len++)
        {
            for (int i = 0; i <= n - len; i++)
            {
                string substring = s.Substring(i, len);

                if (IsSpecial(substring))
                {
                    int count = CountOccurrences(s, substring);

                    if (count >= 3)
                    {
                        maxLength = Math.Max(maxLength, len);
                    }
                }
            }
        }

        return maxLength;
    }

    public static bool IsSpecial(string s)
    {
        foreach (char c in s)
        {
            if (c != s[0])
                return false;
        }
        return true;
    }

    public static int CountOccurrences(string text, string pattern)
    {
        int count = 0;
        int index = 0;

        while ((index = text.IndexOf(pattern, index)) != -1)
        {
            count++;
            index += 1;
        }

        return count;
    }
}