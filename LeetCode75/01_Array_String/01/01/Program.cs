public class Program
{
    public static void Main()
    {
        TestCase("abc", "pqr", "apbqcr", "Test Case 1");
        TestCase("ab", "pqrs", "apbqrs", "Test Case 2");
    }

    public static void TestCase(string word1, string word2, string expectation, string description)
    {
        var result = MergeAlternately(word1, word2);
        Console.WriteLine($"{description} {(result == expectation ? "Passed" : "Failed")}");
    }

    public static string MergeAlternately(string word1, string word2)
    {
        string s = "";
        int length1 = word1.Length;
        int length2 = word2.Length;
        int max = Math.Max(length1, length2);
        for (int i = 0; i < max; i++)
        {
            if (i < length1)
            {
                s += word1[i];
            }
            if (i < length2)
            {
                s += word2[i];
            }
        }
        return s;
    }
}