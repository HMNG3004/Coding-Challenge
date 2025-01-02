public class Program
{
    public static void Main()
    {
        TestCase(["aba", "bcb", "ece", "aa", "e"], [[0, 2], [1, 4], [1, 1]], [2, 3, 0], "Test Case 1");
        TestCase(["a", "e", "i"], [[0, 2], [0, 1], [2, 2]], [3, 2, 1], "Test Case 2");
    }

    public static void TestCase(string[] words, int[][] queries, int[] expectation, string description)
    {
        var result = VowelStrings(words, queries);
        var resultString = string.Join(", ", result);
        var expectationString = string.Join(", ", expectation);
        Console.WriteLine($"{description}: {(resultString == expectationString ? "Passed" : "Failed")}");
    }

    public static int[] VowelStrings(string[] words, int[][] queries)
    {
        int[] prefixSum = new int[words.Length + 1];
        int[] result = new int[queries.Length];
        prefixSum[0] = 0;

        char[] vowel = ['a', 'e', 'i', 'o', 'u'];

        for(int i = 0; i < words.Length; i++)
        {
            if (vowel.Contains(words[i][0]) && vowel.Contains(words[i][words[i].Length - 1]))
            {
                prefixSum[i + 1] = prefixSum[i] + 1;
            }
            else
            {
                prefixSum[i + 1] = prefixSum[i];
            }
        }

        for(int i = 0; i < queries.Length; i++)
        {
            int start = queries[i][0];
            int end = queries[i][1];
            if(start == 0)
            {
                result[i] = prefixSum[end + 1];
            }
            else
            {
                result[i] = prefixSum[end + 1] - prefixSum[start];
            }
            
        }
        
        return result;
    }
}