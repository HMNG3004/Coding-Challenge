public class Program
{
    public static void Main()
    {
        TestCase(["amazon", "apple", "facebook", "google", "leetcode"], ["e", "o"], ["facebook", "google", "leetcode"], "Test case 1");
        TestCase(["amazon", "apple", "facebook", "google", "leetcode"], ["lo", "eo"], ["google", "leetcode"], "Test case 2");
    }

    public static void TestCase(string[] words1, string[] words2, IList<String> expectation, string description)
    {
        var result = WordSubsets(words1, words2);
        var resultString = string.Join(", ", result);
        var expectationString = string.Join(", ", expectation);
        Console.WriteLine($"{description}: {(resultString == expectationString ? "Passed" : "Failed")}");
    }

    public static IList<string> WordSubsets(string[] words1, string[] words2)
    {
        int[] maxFrequencies = new int[26];
        HashSet<int> lettersNeeded = new HashSet<int>();

        

        foreach (string word in words2)
        {
            int[] wordFrequencies = CountFrequencies(word);
            for (int i = 0; i < 26; i++)
            {
                if (wordFrequencies[i] > maxFrequencies[i])
                {
                    maxFrequencies[i] = wordFrequencies[i];
                    lettersNeeded.Add(i);
                }
            }
        }

        List<int> lettersNeededList = new List<int>(lettersNeeded);

        List<string> universalWords = new List<string>();

        foreach (string word in words1)
        {
            int[] wordFrequencies = CountFrequencies(word);
            bool isUniversal = true;
            foreach (int i in lettersNeededList)
            {
                if (wordFrequencies[i] < maxFrequencies[i])
                {
                    isUniversal = false;
                    break;
                }
            }
            if (isUniversal)
            {
                universalWords.Add(word);
            }
        }

        return universalWords;
    }

    public static int[] CountFrequencies(string word)
    {
        int[] frequencies = new int[26];
        foreach (char c in word)
        {
            int idx = c - 'a';
            frequencies[idx]++;
        }
        return frequencies;
    }
}