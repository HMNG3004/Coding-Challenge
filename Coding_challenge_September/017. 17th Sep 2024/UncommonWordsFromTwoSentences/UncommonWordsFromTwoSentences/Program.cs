public class Solution
{
    public static void Main()
    {
        TestCase();
    }

    public static void TestCase()
    {
        string s1 = "this apple is sweet";
        string s2 = "this apple is sour";
        string[] result = UncommonFromSentences(s1, s2);
        Console.WriteLine(String.Join(", ", result));
    }

    public static string[] UncommonFromSentences(string s1, string s2)
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        void AddWords(string sentence)
        {
            string[] words = sentence.Split(' ');

            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }
        }

        AddWords(s1);
        AddWords(s2);

        // Find uncommon words that appear exactly once
        List<string> result = new List<string>();
        foreach (var word in wordCount)
        {
            if (word.Value == 1)
            {
                result.Add(word.Key);
            }
        }

        return result.ToArray();
    }
}