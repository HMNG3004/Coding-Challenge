public class Program
{
    public static void Main()
    {
        TestCase("annabelle", 2, true, "Test case 1");
        TestCase("leetcode", 3, false, "Test case 2");
        TestCase("true", 4, true, "Test case 3");
    }

    public static void TestCase(string s, int k, bool expectation, string description)
    {
        var result = CanConstruct(s, k);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static bool CanConstruct(string s, int k)
    {
        if (s.Length < k) return false;

        char[] chars = s.ToCharArray();
        Array.Sort(chars);
        int oddCount = 0;

        for (int i = 0; i < chars.Length;)
        {
            char current = chars[i];
            int count = 0;
            while (i < chars.Length && chars[i] == current)
            {
                count++;
                i++;
            }
            if (count % 2 != 0) oddCount++;
        }

        return oddCount <= k;
    }
}