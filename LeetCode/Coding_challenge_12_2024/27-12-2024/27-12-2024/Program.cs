public class Program
{
    public static void Main()
    {
        TestCase([8, 1, 5, 2, 6], 11, "Test case 1");
        TestCase([1, 2], 2, "Test case 2");
    }

    public static void TestCase(int[] values, int expectation, string description)
    {
        var result = MaxScoreSightseeingPair(values);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int MaxScoreSightseeingPair(int[] values)
    {
        int[] maxLeftScore = new int[values.Length];
        maxLeftScore[0] = values[0];

        int maxScore = 0;

        for (int i = 1; i < values.Length; i++)
        {
            int currentRightScore = values[i] - i;
            maxScore = Math.Max(
                maxScore,
                maxLeftScore[i - 1] + currentRightScore
            );

            int currentLeftScore = values[i] + i;
            maxLeftScore[i] = Math.Max(maxLeftScore[i - 1], currentLeftScore);
        }

        return maxScore;
    }
}