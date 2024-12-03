public class Program
{
    public static void Main()
    {
        RunTestCases();
    }

    public static void RunTestCases()
    {
        Console.WriteLine("Running Test Cases...");
        TestCase("i love eating burger", "burg", 4, "Test Case 1: \"burg\" is prefix of \"burger\" which is the 4th word in the sentence.");
        TestCase("this problem is an easy problem", "pro", 2, "Test Case 2: \"pro\" is prefix of \"problem\" which is the 2nd and the 6th word in the sentence, but we return 2 as it's the minimal index.");
        TestCase("i am tired", "you", -1, "Test Case 3: \"you\" is not a prefix of any word in the sentence.");
        TestCase("hello hello hello", "hel", 1, "Test Case 4: \"hel\" is prefix of \"hello\", minimal index is 1.");
        TestCase("empty words here", "space", -1, "Test Case 5: \"space\" is not a prefix of any word.");
        TestCase("", "any", -1, "Test Case 6: Empty sentence, no prefix possible.");
    }

    public static void TestCase(string sentence, string searchWord, int expected, string description)
    {
        var result = IsPrefixOfWord(sentence, searchWord);
        Console.WriteLine($"{description}: {(result == expected ? "Passed" : "Failed")}");
    }


    public static int IsPrefixOfWord(string sentence, string searchWord)
    {
        var words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].StartsWith(searchWord))
            {
                return i + 1;
            }
        }
        return -1;
    }
}