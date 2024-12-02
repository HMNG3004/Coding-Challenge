//You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].

//Each element nums[i] represents the maximum length of a forward jump from index i. In other words, if you are at nums[i], you can jump to any nums[i + j] where:

//0 <= j <= nums[i] and
//i + j < n
//Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].

//Each element nums[i] represents the maximum length of a forward jump from index i. In other words, if you are at nums[i], you can jump to any nums[i + j] where:

//0 <= j <= nums[i] and
//i + j < n
//Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].

public class Program
{
    public static void Main()
    {
        TestCase1();
    }

    public static void TestCase1()
    {
        int[] nums = [2, 3, 1, 1, 4];
        Console.WriteLine(Jump(nums));
    }

    public static int Jump(int[] nums)
    {
        int highJump = 0;
        int jump = 0;
        int currentPosition = 0;

        int lenght = nums.Length;
        if(lenght == 1)
        {
            return 0;
        }

        for(int i = 0; i < lenght; i++)
        {
            if(i > highJump)
            {
                highJump = currentPosition;
                jump++;
            }

            currentPosition = Math.Max(currentPosition, i + nums[i]);
        }
        return jump;
    }
}

// Complexity Analysis
// Time Complexity: O(n)
// Space Complexity: O(1)


//Analysis of the Question
//Objective: To find the minimum number of jumps to reach the last element of the array.
//Constraints: The test cases are generated such that you can reach the last element of the array.
//Approach: The greedy approach works well because at each step, we make the locally optimal choice (maximizing the reach),
//which leads us reach the global optimum (minimum number of jumps to reach the last element).