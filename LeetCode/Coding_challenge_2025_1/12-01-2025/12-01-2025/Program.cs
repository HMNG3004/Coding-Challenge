public class Program
{
    public static void Main()
    {
        TestCase("))()))", "010100", true, "Test case 1");
        TestCase("()()", "0000", true, "Test case 2");
        TestCase(")", "0", false, "Test case 3");
    }

    public static void TestCase(string s, string locked, bool expectation, string description)
    {
        var result = CanBeValid(s, locked);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static bool CanBeValid(string s, string locked)
    {
        int n = s.Length;
        if (n % 2 != 0)
        {
            return false;
        }

        int openCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '(' || locked[i] == '0')
            {
                openCount++;
            }
            else
            {
                openCount--;
            }
            if (openCount < 0)
            {
                return false;
            }
        }

        int closeCount = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (s[i] == ')' || locked[i] == '0')
            {
                closeCount++;
            }
            else
            {
                closeCount--;
            }
            if (closeCount < 0)
            {
                return false;
            }
        }

        return true;
    }
}