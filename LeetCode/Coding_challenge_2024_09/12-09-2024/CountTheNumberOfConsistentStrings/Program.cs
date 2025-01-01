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
        string allowed = "ab";
        string[] words = { "ad", "bd", "aaab", "baa", "badab" };
        int result = CountConsistentStrings(allowed, words);
        Console.WriteLine("Result: " + result);
    }

    public static void TestCase2()
    {
        string allowed = "abc";
        string[] words = { "a", "b", "c", "ab", "ac", "bc", "abc" };
        int result = CountConsistentStrings(allowed, words);
        Console.WriteLine("Result: " + result);
    }

    public static void TestCase3()
    {
        string allowed = "cad";
        string[] words = { "cc", "acd", "b", "ba", "bac", "bad", "ac", "d" };
        int result = CountConsistentStrings(allowed, words);
        Console.WriteLine("Result: " + result);
    }

    public static int CountConsistentStrings(string allowed, string[] words)
    {
        int count = 0;
        char[] character = allowed.ToCharArray();
        int i = 0;
        foreach(var word in words)
        {
            bool isConsistent = true;
            foreach (var c in word)
            {
                if (!character.Contains(c))
                {
                    isConsistent = false;
                    break;
                }
            }
            if (isConsistent) count++;
        }
        return count;
    }

    public static int CountConsistentStringsSolution(string allowed, string[] words)
    {
        var allowedSet = new HashSet<char>(allowed);
        int consistentCount = 0;

        foreach (var word in words)
        {
            bool isConsistent = true;

            foreach (var c in word)
            {
                if (!allowedSet.Contains(c))
                {
                    isConsistent = false;
                    break;
                }
            }

            if (isConsistent)
            {
                consistentCount++;
            }
        }

        return consistentCount;
    }
}