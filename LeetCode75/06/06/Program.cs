public class Program
{
    public static void Main()
    {
        TestCase("the sky is blue", "blue is sky the", "Test Case 1");
        TestCase("  hello world  ", "world hello", "Test Case 2");
    }

    public static void TestCase(string s, string expectation, string description)
    {
        var result = ReverseWords(s);
        Console.WriteLine(result);
        System.Console.WriteLine($"{description} {(result == expectation ? "Passed" : "Failed")}");
    }

    public static string ReverseWords(string s)
    {
        string[] words = s.Split(' ');
        Array.Reverse(words);
        return string.Join(" ", words.Where(x => x.Trim().Length > 0));
    }
}