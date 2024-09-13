public class Solution
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    public static void TestCase1()
    {
        int z = MinBitFlips(10, 7);
        Console.WriteLine(z);
    }

    public static void TestCase2()
    {
        int z = MinBitFlips(3, 4);
        Console.WriteLine(z);
    }

    public static int MinBitFlips(int start, int goal)
    {
        int count = 0;

        while (start > 0 || goal > 0)
        {
            int remainStart = start % 2;
            int reaminGoal = goal % 2;
            if (remainStart != reaminGoal)
                count++;
            start = start / 2;
            goal = goal / 2;
        }
        return count;
    }
}