using System.Text;

public class Program
{
    public static void Main()
    {
        RunTestCase();
    }

    public static void RunTestCase()
    {
        Console.WriteLine("Running Test Cases...");
        TestCase("LeetcodeHelpsMeLearn", new int[] { 8, 13, 15 }, "Leetcode Helps Me Learn", "Test case 1:");
        TestCase("spacing", new int[] { 0, 1, 2, 3, 4, 5, 6 }, " s p a c i n g", "Test case 2:");
        TestCase("icodeinpython", new int[] { 1, 5, 7, 9 }, "i code in py thon", "Test case 3:");
    }

    public static void TestCase(string sentence, int[] spaces, string expected, string description)
    {
        var result = AddSpaces(sentence, spaces);
        Console.WriteLine($"{description}: {(result == expected ? "Passed" : "Failed")}");
    }


    public static string AddSpaces(string s, int[] spaces)
    {
        var result = new StringBuilder();
        int spaceIndex = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (spaceIndex < spaces.Length && i == spaces[spaceIndex])
            {
                result.Append(' ');
                spaceIndex++;
            }
            result.Append(s[i]);
        }

        return result.ToString();
    }
}