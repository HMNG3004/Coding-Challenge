public class Solution
{
    public static void Main()
    {
        //TestCase();
        TeseCase2();
    }

    public static void TestCase()
    {
        string s = "leetscode";
        string[] dictionary = ["leet", "code", "leetcode"];
        int result = MinExtraCharacters(s, dictionary);
        Console.WriteLine(result);
    }

    public static void TeseCase2()
    {
        string s = "ecolloycollotkvzqpdaumuqgs";
        string[] dictionary = ["flbri", "uaaz", "numy", "laper", "ioqyt", "tkvz", "ndjb", "gmg", "gdpbo", "x", "collo", "vuh", "qhozp", "iwk", "paqgn", "m", "mhx", "jgren", "qqshd", "qr", "qpdau", "oeeuq", "c", "qkot", "uxqvx", "lhgid", "vchsk", "drqx", "keaua", "yaru", "mla", "shz", "lby", "vdxlv", "xyai", "lxtgl", "inz", "brhi", "iukt", "f", "lbjou", "vb", "sz", "ilkra", "izwk", "muqgs", "gom", "je"];
        int result = MinExtraCharacters(s, dictionary);
        Console.WriteLine(result);
    }

    public static int MinExtraCharacters(string s, string[] dictionary)
    {
        int n = s.Length;
        var dictSet = new HashSet<string>(dictionary); // Use a HashSet for faster lookups
        int[] dp = new int[n + 1]; // dp[i] will hold the minimum extra chars for substring s[i:]

        // Initialize dp array. dp[n] = 0, because no extra chars after the string ends.
        for (int i = 0; i <= n; i++)
        {
            dp[i] = n - i; // Start with worst case (all characters are extra).
        }

        // Fill the dp array backwards
        for (int i = n - 1; i >= 0; i--)
        {
            // Try all substrings starting at index i
            for (int j = i + 1; j <= n; j++)
            {
                string substr = s.Substring(i, j - i);
                if (dictSet.Contains(substr))
                {
                    // If the substring s[i:j] is in the dictionary, update dp[i]
                    dp[i] = Math.Min(dp[i], dp[j]);
                }
            }
            // Also, consider the case of skipping the current character
            dp[i] = Math.Min(dp[i], dp[i + 1] + 1);
        }

        // The result is dp[0], the minimum extra characters for the whole string.
        return dp[0];
    }
}