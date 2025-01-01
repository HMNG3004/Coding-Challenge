using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    static int totalSum;
    public static void Main()
    {
        TestCase([1, 1, 1, 1, 1], 3, 5, "Test Case 1");
    }

    public static void TestCase(int[] nums, int target, int expectation, string description)
    {
        var result1 = FindTargetSumWays(nums, target);
        var result2 = FindTargetSumWays2(nums, target);
        var result3 = FindTargetSumWays3(nums, target);
        Console.WriteLine($"{description} with solution 1: {(result1 == expectation ? "Passed" : "Failed")}");
        Console.WriteLine($"{description} with solution 2: {(result2 == expectation ? "Passed" : "Failed")}");
        Console.WriteLine($"{description} with solution 3: {(result3 == expectation ? "Passed" : "Failed")}");
    }

    public static int FindTargetSumWays(int[] nums, int target)
    {
        return Combination(nums, target, 0, 0);
    }

    public static int FindTargetSumWays2(int[] nums, int target)
    {
        totalSum = nums.Sum();

        int[,] memo = new int[nums.Length, 2 * totalSum + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < 2 * totalSum + 1; j++)
            {
                memo[i, j] = int.MinValue;
            }
        }

        return CalculateWays(nums, 0, 0, target, memo);
    }

    private static int Combination(int[] nums, int target, int index, int currentSum)
    {
        if (index == nums.Length)
        {
            // Base case: Check if the current sum matches the target.
            return currentSum == target ? 1 : 0;
        }

        // Recursive case: Try adding and subtracting the current number.
        int add = Combination(nums, target, index + 1, currentSum + nums[index]);
        int subtract = Combination(nums, target, index + 1, currentSum - nums[index]);

        return add + subtract;
    }

    private static int CalculateWays(int[] nums, int currentIndex, int currentSum, int target, int[,] memo)
    {
        if (currentIndex == nums.Length)
        {
            // Base case: Check if the current sum matches the target
            return currentSum == target ? 1 : 0;
        }

        // Check if the result is already computed
        if (memo[currentIndex, currentSum + totalSum] != int.MinValue)
        {
            return memo[currentIndex, currentSum + totalSum];
        }

        // Calculate ways by adding the current number
        int add = CalculateWays(nums, currentIndex + 1, currentSum + nums[currentIndex], target, memo);

        // Calculate ways by subtracting the current number
        int subtract = CalculateWays(nums, currentIndex + 1, currentSum - nums[currentIndex], target, memo);

        // Store the result in the memoization table
        memo[currentIndex, currentSum + totalSum] = add + subtract;

        return memo[currentIndex, currentSum + totalSum];
    }

    public static int FindTargetSumWays3(int[] nums, int target)
    {
        int totalSum = nums.Sum();

        if (target > totalSum || (totalSum - target) % 2 != 0)
        {
            return 0;
        }

        int s = (totalSum - target) / 2;

        int[] dp = new int[s + 1];
        dp[0] = 1;

        foreach (int num in nums)
        {
            for (int j = s; j >= num; j--)
            {
                dp[j] += dp[j - num];
            }
        }

        return dp[s];
    }
}