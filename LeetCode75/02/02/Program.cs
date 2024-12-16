public class Program
{
    public static void Main()
    {
        TestCase("ABCABC", "ABC", "ABC", "Test case 1");
        TestCase("ABABAB", "ABAB", "AB", "Test case 2");
        TestCase("LEET", "CODE", "", "Test case 3");
    }

    public static void TestCase(string str1, string str2, string expectation, string description)
    {
        var result = GcdOfStrings(str1, str2);
        Console.WriteLine($"{description} {(result == expectation ? "Passed" : "Failed")}");
    }

    public static string GcdOfStrings(string str1, string str2)
    {
        if (str1 + str2 == str2 + str1)
        {
            var gcd = Gcd(str1.Length, str2.Length);
            return str1.Substring(0, gcd);
        }
        return "";
    }

    public static int Gcd(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        return Gcd(b, a % b);
    }
}