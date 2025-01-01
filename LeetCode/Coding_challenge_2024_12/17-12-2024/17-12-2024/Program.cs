using System.Text;

public class Program
{
    public static void Main()
    {
        TestCase("cczazcc", 3, "zzcccac", "Test case 1");
        TestCase("aababab", 2, "bbabaa", "Test case 2");
    }

    public static void TestCase(string s, int repeatLimit, string expectation, string description)
    {
        var result = RepeatLimitedString(s, repeatLimit);
        Console.WriteLine($"{description} : {(result == expectation ? "Passed" : "Failed")}");
    }

    public static string RepeatLimitedString(string s, int repeatLimit)
    {
        int[] freq = new int[26];
        foreach (char c in s)
            freq[c - 'a']++;

        var result = new StringBuilder();
        int i = 25;
        while (true)
        {
            while (i >= 0 && freq[i] == 0) i--;
            if (i < 0) break;

            int count = Math.Min(freq[i], repeatLimit);
            result.Append((char)(i + 'a'), count);
            freq[i] -= count;

            if (freq[i] > 0)
            {
                int j = i - 1;
                while (j >= 0 && freq[j] == 0) j--;

                if (j < 0) break;

                result.Append((char)(j + 'a'));
                freq[j]--;
            }
        }

        return result.ToString();
    }
}