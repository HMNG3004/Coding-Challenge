public class Program
{
    public static void Main()
    {
        TestCase(["pay", "attention", "practice", "attend"], "at", 2, "Test Case 1");
        TestCase(["leetcode", "win", "loops", "success"], "code", 0, "Test Case 2");
    }

    public static void TestCase(string[] words, string pref, int expectation, string description)
    {
        var result = PrefixCount(words, pref);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int PrefixCount(string[] words, string pref)
    {
        int count = 0;
        foreach (string i in words)
        {
            if (i.Length >= pref.Length && i.Substring(0, pref.Length) == pref)
            {
                count++;
            }
        }
        return count;
    }
}