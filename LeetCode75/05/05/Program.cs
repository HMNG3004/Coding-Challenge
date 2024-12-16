public class Program
{
    public static void Main()
    {
        TestCase("IceCreAm", "AceCreIm", "Test Case 1");
        TestCase("leetcode", "leotcede", "Test Case 2");
    }

    public static void TestCase(string s, string expectation, string description)
    {
        var result = ReverseVowels(s);
        System.Console.WriteLine($"{description} {(result == expectation ? "Passed" : "Failed")}");
    }

    public static string ReverseVowels(string s)
    {
        char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        char[] chars = s.ToCharArray();
        int left = 0;
        int right = s.Length - 1;
        while (left < right)
        {
            if (vowels.Contains(char.ToLower(chars[left])) && vowels.Contains(char.ToLower(chars[right])))
            {
                char temp = chars[left];
                chars[left] = chars[right];
                chars[right] = temp;
                left++;
                right--;
            }
            else if (vowels.Contains(char.ToLower(chars[left])))
            {
                right--;
            }
            else
            {
                left++;
            }
        }
        return new string(chars);
    }
}