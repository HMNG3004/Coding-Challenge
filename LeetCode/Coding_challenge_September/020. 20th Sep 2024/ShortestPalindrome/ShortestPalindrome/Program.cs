public class Solution
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    public static void TestCase1()
    {
        string s = "aacecaaa";
        string result = ShortestPalindrome(s);
        Console.WriteLine(result);
    }

    public static void TestCase2()
    {
        string s = "abcd";
        string result = ShortestPalindrome(s);
        Console.WriteLine(result);
    }

    public static string ShortestPalindrome(string s)
    {
        // Get the reverse of the string
        string rev_s = Reverse(s);

        // Create a new string with the pattern: s + "#" + reverse(s)
        string new_s = s + "#" + rev_s;

        // Compute the KMP table for the new string
        int[] kmpTable = KMPTable(new_s);

        // Get the length of the longest prefix which is also a suffix
        int longestPalindromeLength = kmpTable[new_s.Length - 1];

        // Add the remaining characters in reverse to the front of the original string
        string result = rev_s.Substring(0, s.Length - longestPalindromeLength) + s;

        return result;
    }

    // Function to reverse a string
    private static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    // KMP Table (Prefix function) computation
    private static int[] KMPTable(string s)
    {
        int[] table = new int[s.Length];
        int index = 0;

        // KMP table construction
        for (int i = 1; i < s.Length;)
        {
            if (s[i] == s[index])
            {
                table[i] = index + 1;
                index++;
                i++;
            }
            else
            {
                if (index > 0)
                {
                    index = table[index - 1];
                }
                else
                {
                    table[i] = 0;
                    i++;
                }
            }
        }

        return table;
    }
}