using System.Numerics;

public class Program
{
    public static void Main()
    {
        TestCase(3, 5, 3, "Test case 1");
        TestCase(1, 12, 3, "Test case 2");
    }

    public static void TestCase(int num1, int num2, int expectation, string description)
    {
        var result = MinimizeXor(num1, num2);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int MinimizeXor(int num1, int num2)
    {
        int a = BitOperations.PopCount((uint)num1);
        int b = BitOperations.PopCount((uint)num2);
        int result = num1;
        for (int i = 0; i < 32; i++)
        {
            if (a > b && ((1 << i) & num1) != 0)
            {
                result ^= 1 << i;
                a--;
            }
            if (a < b && ((1 << i) & num1) == 0)
            {
                result ^= 1 << i;
                a++;
            }
        }
        return result;
    }
}