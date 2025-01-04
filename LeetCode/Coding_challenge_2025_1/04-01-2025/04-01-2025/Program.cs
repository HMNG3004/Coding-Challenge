public class Program
{
    public static void Main()
    {
        TestCase("aabca", 3, "Test Case 1");
        TestCase("adc", 0, "Test Case 2");
        TestCase("bbcbaba", 4, "Test Case 3");
    }

    public static void TestCase(string s, int expectation, string description)
    {
        var result = CountPalindromicSubsequence(s);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int CountPalindromicSubsequence(string s)
    {
        var c2pos = new Dictionary<char, List<int>>();

        for (int i = 0; i < s.Length; i++)
        {
            if (!c2pos.ContainsKey(s[i]))
                c2pos[s[i]] = new List<int>();
            c2pos[s[i]].Add(i);
        }

        int res = 0;

        foreach (var centerEntry in c2pos)
        {
            char center = centerEntry.Key;
            var centerPositions = centerEntry.Value;

            foreach (var candidateEntry in c2pos)
            {
                char candidate = candidateEntry.Key;
                var candidatePositions = candidateEntry.Value;

                if (candidate == center)
                {
                    if (centerPositions.Count >= 3)
                        res++;
                    continue;
                }

                int leftPos = candidatePositions.First();
                int rightPos = candidatePositions.Last();

                int index = centerPositions.BinarySearch(leftPos);

                if (index < 0) index = ~index;
                if (index < centerPositions.Count && leftPos < centerPositions[index] && centerPositions[index] < rightPos)
                {
                    res++;
                }
            }
        }

        return res;
    }
}