public class Solution
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
        TestCase3();
    }

    public static void TestCase1()
    {
        string s = "eleetminicoworoep";
        PrintResult(s);
    }

    public static void TestCase2()
    {
        string s = "leetcodeisgreat";
        PrintResult(s);
    }

    public static void TestCase3()
    {
        string s = "bcbcbc";
        PrintResult(s);
    }

    public static void PrintResult(string s)
    {
        Console.WriteLine(FindTheLongestSubstring(s));
    }

    public static int FindTheLongestSubstring(string s)
    {
        Dictionary<char, int> vowels = new Dictionary<char, int>
        {
            {'a', 0},
            {'e', 1},
            {'i', 2},
            {'o', 3},
            {'u', 4}
        };

        // Current bitmask state (start with all vowels appearing an even number of times)
        int currentMask = 0;
        // Dictionary to store the first occurrence of each mask
        Dictionary<int, int> seen = new Dictionary<int, int> { { 0, -1 } };

        int maxLen = 0;

        // Traverse the string
        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];

            // If the character is a vowel, flip the corresponding bit
            if (vowels.ContainsKey(ch))
            {
                currentMask ^= (1 << vowels[ch]);
            }

            // If this mask has been seen before, calculate the length of the substring
            if (seen.ContainsKey(currentMask))
            {
                maxLen = Math.Max(maxLen, i - seen[currentMask]);
            }
            else
            {
                // Otherwise, store the first occurrence of this mask
                seen[currentMask] = i;
            }
        }

        return maxLen;
    }
}