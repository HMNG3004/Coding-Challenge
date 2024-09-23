public class Solution
{
    public static void Main()
    {
        TestCase1();
    }

    public static void TestCase1()
    {
        int n = 804289384;
        int k = 42641503;
        Console.WriteLine(FindKthNumber(n, k));
    }

    public static int FindKthNumber(int n, int k)
    {
        int current = 1;
        k--;

        while (k > 0)
        {
            long step = CountSteps(n, current, current + 1); // count steps from current to next prefix
            if (step <= k)
            {
                current++; // move to the next sibling (next lexicographical number)
                k -= (int)step; // subtract the step count
            }
            else
            {
                current *= 10; // move to the next level (next lexicographical depth)
                k--; // subtract 1 as we're considering this number now
            }
        }

        return current;
    }

    // Count how many numbers are between the prefix 'prefix' and 'nextPrefix' within the range [1, n]
    private static long CountSteps(int n, long prefix, long nextPrefix)
    {
        long steps = 0;
        while (prefix <= n)
        {
            steps += Math.Min(n + 1, nextPrefix) - prefix;
            prefix *= 10;
            nextPrefix *= 10;
        }
        return steps;
    }
}