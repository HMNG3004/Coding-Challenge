public class Program
{
    public static void Main()
    {
        TestCase("abaacbcbb", 5, "Test Case 1");
        TestCase("aa", 2, "Test Case 2");
    }

    public static void TestCase(string s, int expectation, string description)
    {
        var result = MinimumLength(s);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int MinimumLength(string s)
    {
        int[] charFrequency = new int[26];
        int totalLength = 0;
        foreach (char c in s)
        {
            charFrequency[c - 'a']++;
        }
        foreach (int frequency in charFrequency)
        {
            if (frequency == 0) continue;
            if (frequency % 2 == 0)
            {
                totalLength += 2;
            }
            else
            {
                totalLength += 1;
            }
        }
        return totalLength;
    }
}