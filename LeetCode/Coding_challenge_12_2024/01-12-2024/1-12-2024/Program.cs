public class Program
{
    public static void Main()
    {
        RunTestCases();
    }

    public static void RunTestCases()
    {
        Console.WriteLine("Running Test Cases...");
        TestCase(new int[] { 10, 2, 5, 3 }, true, "Test Case 1: Positive numbers with valid double.");
        TestCase(new int[] { 7, 1, 14, 11 }, true, "Test Case 2: Positive numbers, valid double exists.");
        TestCase(new int[] { 3, 1, 7, 11 }, false, "Test Case 3: Positive numbers, no valid double.");
        TestCase(new int[] { 0, 0 }, true, "Test Case 4: Contains zeros.");
        TestCase(new int[] { -2, 0, 10, -19, 4, 6, -8 }, false, "Test Case 5: Mixed positive and negative numbers, no valid double.");
        TestCase(new int[] { -10, -5, 2, 3 }, true, "Test Case 6: Mixed numbers, valid double exists.");
        TestCase(new int[] { 1 }, false, "Test Case 7: Single element.");
        TestCase(new int[] { }, false, "Test Case 8: Empty array.");
        TestCase(new int[] { 16, 8, 4, 2, 1 }, true, "Test Case 9: Power of 2 sequence.");
        TestCase(new int[] { -20, -10, -5, 0, 5, 10, 20 }, true, "Test Case 10: Symmetrical range with zero.");
    }

    public static void TestCase(int[] arr, bool expected, string description)
    {
        var result = CheckIfNAndItsDoubleExist(arr);
        Console.WriteLine($"{description}: {(result == expected ? "Passed" : "Failed")}");
    }

    public static bool CheckIfNAndItsDoubleExist(int[] arr)
    {
        var set = new HashSet<int>();
        foreach (var num in arr)
        {
            if (set.Contains(num * 2) || (num % 2 == 0 && set.Contains(num / 2)))
            {
                return true;
            }
            set.Add(num);
        }
        return false;
    }
}