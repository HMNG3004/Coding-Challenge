public class Program
{
    public static void Main()
    {
        TestCase(["a", "aba", "ababa", "aa"], 4, "Test case 1");
        TestCase(["pa", "papa", "ma", "mama"], 2, "Test case 2");
        TestCase(["abab", "ab"], 0, "Test case 3");
    }

    public static void TestCase(string[] words, int expectation, string description)
    {
        var result = CountPrefixSuffixPairs(words);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int CountPrefixSuffixPairs(string[] words)
    {
        int count = 0;
        for(int i = 0; i < words.Length - 1; i++)
        {
            for(int j = i + 1; j < words.Length; j++)
            {
                if (IsPrefixAndSuffix(words[i], words[j]))
                {
                    count++;
                
                }
            }
        }
        return count;
    }

    public static bool IsPrefixAndSuffix(string sentence, string searchWord)
    {
        int n = sentence.Length;
        int m = searchWord.Length;
        if (n < m)
        {
            if(searchWord.Substring(0, n) == sentence && searchWord.Substring(searchWord.Length - n) == sentence)
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsPrefixAndSuffix2(string sentence, string searchWord)
    {
        if (searchWord.StartsWith(sentence) && searchWord.EndsWith(sentence))
            return true;
        return false;
    }
}