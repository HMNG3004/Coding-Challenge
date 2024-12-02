//Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element appears at most twice. The relative order of the elements should be kept the same.

//Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.

//Return k after placing the final result in the first k slots of nums.

//Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.

public class Program
{
    private static void Main()
    {
        TestCase1();
        TestCase2();
    }

    private static int RemoveDuplicates(int[] nums)
    {
        int k = 0;
        int j = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[k] == nums[i] && j == 0)
            {
                k++;
                j++;
                nums[k] = nums[i];
            }
            if (nums[k] != nums[i])
            {
                k++;
                j = 0;
                nums[k] = nums[i];
            }
        }
        return k + 1;
    }

    private static int RemoveDuplicates2(int[] nums)
    {
        int count = 0;
        bool isPrevTwice = false;
        for (int i = 1; i < nums.Length; i++)
        {
            bool isCurrentTwice = nums[count] == nums[i];
            if (!isCurrentTwice || !isPrevTwice)
                nums[++count] = nums[i];
            isPrevTwice = isCurrentTwice;
        }
        return count + 1;
    }

    private static void TestCase1()
    {
        int[] nums = { 1, 1, 1, 2, 2, 3 };
        int result = RemoveDuplicates(nums);
        Console.WriteLine("k = " +result);
        for (int i = 0; i < result; i++)
        {
            Console.Write(nums[i] + " ");
        }
        Console.Write("\n");
    }

    private static void TestCase2()
    {
        int[] nums = { 0, 0, 1, 1, 1, 1, 2, 3, 3 };
        int result = RemoveDuplicates2(nums);
        Console.WriteLine("k = " + result);
        for (int i = 0; i < result; i++)
        {
            Console.Write(nums[i] + " ");
        }
        Console.Write("\n");
    }
}