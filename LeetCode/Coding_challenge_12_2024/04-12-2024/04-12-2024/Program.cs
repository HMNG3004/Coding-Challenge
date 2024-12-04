public class Program
{
    public static void Main()
    {
        Console.WriteLine("Running Test Cases...");
        TestCase("abc", "ad", true, "Test case 1:");
        TestCase("zc", "ad", true, "Test case 2:");
        TestCase("ab", "d", false, "Test case 3:");
    }

    public static void TestCase(string str1, string str2, bool expected, string description)
    {
        var result = CanMakeSubsequence(str1, str2);
        Console.WriteLine($"{description}: {(result == expected ? "Passed" : "Failed")}");
    }

    public static bool CanMakeSubsequence(string str1, string str2)
    {
        int n = str1.Length, m = str2.Length;

        if (n < m)
            return false;

        int i = 0, j = 0;

        while (i < n && j < m)
        {
            char currentChar = str1[i];
            char targetChar = str2[j];

            // Match either the current character or its cyclic increment
            if (currentChar == targetChar || (char)((currentChar - 'a' + 1) % 26 + 'a') == targetChar)
            {
                j++; // Move to the next character in str2
            }

            i++; // Always move to the next character in str1
        }

        return j == m;
    }
}