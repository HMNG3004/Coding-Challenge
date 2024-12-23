public class Program
{
    public static void Main()
    {
        TestCase(['a', 'a', 'b', 'b', 'c', 'c', 'c'], 6, "Test Case 1");
        TestCase(['a'], 1, "Test Case 2");
        TestCase(['a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b'], 4, "Test Case 1");
    }

    public static void TestCase(char[] chars, int expectation, string description)
    {
        var result = Compress(chars);
        Console.WriteLine($"{description} : {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int Compress(char[] chars)
    {
        int i = 0, res = 0;
        while (i < chars.Length)
        {
            int groupLength = 1;
            while (i + groupLength < chars.Length && chars[i + groupLength] == chars[i])
            {
                groupLength++;
            }

            chars[res] = chars[i];
            res++;
            if (groupLength > 1)
            {
                foreach (char c in groupLength.ToString())
                {
                    chars[res] = c;
                    res++;
                }
            }
            i += groupLength;
            
        }

        return res;
    }
}