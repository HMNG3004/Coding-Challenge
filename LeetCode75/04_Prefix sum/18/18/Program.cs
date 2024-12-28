public class Program
{
    public static void Main()
    {
        TestCase([-5, 1, 5, 0, -7], 1, "Test case 1");
        TestCase([-4, -3, -2, -1, 4, 3, 2], 0, "Test case 2");
    }

    public static void TestCase(int[] gain, int expectation, string description)
    {
        var result = LargestAltitude(gain);
        System.Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int LargestAltitude(int[] gain)
    {
        int highest = 0;
        int[] altitude = new int[gain.Length + 1];
        altitude[0] = 0;
        for(int i = 0; i < gain.Length; i++)
        {
            altitude[i + 1] = altitude[i] + gain[i];
            highest = Math.Max(highest, altitude[i + 1]);
        }

        return highest;
    }
}