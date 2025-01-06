public class Program
{
    public static void Main()
    {
        TestCase("110", [1, 1, 3], "Test case 1");
        TestCase("001011", [11, 8, 5, 4, 3, 4], "Test case 2");
    }

    public static void TestCase(string boxes, int[] expectation, string description)
    {
        var result = MinOperations(boxes);
        var resultString = string.Join(", ", result);
        var expectationString = string.Join(", ", expectation);
        Console.WriteLine($"{description}: {(resultString == expectationString ? "Passed" : "Failed")}");
    }

    public static int[] MinOperations(string boxes)
    {
        int n = boxes.Length;
        int[] answers = new int[n];
        int count = 0;
        int steps = 0;

        for(int i = 0; i < n; i++)
        {
            answers[i] = steps;
            count += boxes[i] == '1' ? 1 : 0;
            steps += count;
        }

        count = 0;
        steps = 0;

        for(int i = n - 1; i >= 0; i--)
        {
            answers[i] += steps;
            count += boxes[i] == '1' ? 1 : 0;
            steps += count;
        }

        return answers;
    }
}