public class Program
{
    public static void Main()
    {
        TestCase([1, 8, 6, 2, 5, 4, 8, 3, 7], 49, "Test Case 1");
        TestCase([1, 1], 1, "Test Case 2");
    }

    public static void TestCase(int[] height, int expectation, string description)
    {
        var result = MaxArea(height);
        Console.WriteLine($"{description} : {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int maxArea = 0; int minHeight = 0;
        while (left < right)
        {
            minHeight = Math.Min(height[left], height[right]);
            maxArea = Math.Max(maxArea, minHeight * (right - left));
            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return maxArea;
    }
}