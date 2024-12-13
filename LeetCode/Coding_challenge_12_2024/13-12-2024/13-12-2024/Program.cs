public class Program
{
    public static void Main()
    {
        TestCase([10, 44, 10, 8, 48, 30, 17, 38, 41, 27, 16, 33, 45, 45, 34, 30, 22, 3, 42, 42], 212, "Test Case");
    }

    public static void TestCase(int[] nums, int expectation, string description)
    {
        var result = FindScore(nums);
        Console.WriteLine($"{description} {(result == expectation ? "Passed" : "Failed")}");
    }

    public static long FindScore(int[] nums)
    {
        Stack<int> stack = new Stack<int>();
        long result = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (stack.Count == 0 || nums[i] < stack.Peek())
            {
                stack.Push(nums[i]);
            }
            else
            {
                while (stack.Count > 0)
                {
                    result += stack.Pop();
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
            }
        }

        while (stack.Count > 0)
        {
            result += stack.Pop();
            if (stack.Count > 0)
            {
                stack.Pop();
            }
        }

        return result;
    }
}