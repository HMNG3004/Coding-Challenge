public class Program
{
    public static void Main()
    {
        TestCase("abciiidef", 3, 3, "Test Case 1");
    }

    public static void TestCase(string s, int k, int expectation, string description)
    {
        var result = MaxVowels(s, k);
        Console.WriteLine($"{description} : {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int MaxVowels(string s, int k)
    {
        int max = 0;
        char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        for(int i = 0; i < k; i++)
        {
            if (vowels.Contains(s[i]))
                max++;
        }
        int count = max;
        for(int i = k; i < s.Length; i++)
        {
            if (vowels.Contains(s[i]))
                count++;

            //Check if the previous character was a vowel
            if (vowels.Contains(s[i - k]))
                count--;
            max = Math.Max(max, count);
        }
        return max;
    }
}