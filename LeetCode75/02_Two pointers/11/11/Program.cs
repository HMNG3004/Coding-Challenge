public class Program
{
    public static void Main()
    {
        TestCase("abc", "ahbgdc", true, "Test case 1");
        TestCase("axc", "ahbgdc", false, "Test case 1");
    }

    public static void TestCase(string s, string t, bool expectation, string description)
    {
        var result = IsSubsequence(s, t);
        Console.WriteLine($"{description} : {(result == expectation ? "Passed" : "Failed")}");
    }

    public static bool IsSubsequence(string s, string t)
    {
        return IsSubsequence(s, t, s.Length, t.Length);
    }

    public static bool IsSubsequence(string s1, string s2, int m, int n)
    {
        if (m == 0)
            return true;
        if (n == 0)
            return false;

        // If last characters of two strings are matching
        if (s1[m - 1] == s2[n - 1])
            return IsSubsequence(s1, s2, m - 1, n - 1);

        return IsSubsequence(s1, s2, m, n - 1);
    }
}