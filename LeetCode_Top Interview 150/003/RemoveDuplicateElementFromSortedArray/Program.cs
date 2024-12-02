public class Program
{
    private static void Main()
    {
        int[] nums = { 1, 1, 2 };
        int result = RemoveDuplicates(nums);
        Console.WriteLine(result);
    }

    private static int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        int i = 0;
        for (int j = 1; j < nums.Length; j++)
        {
            if (nums[j] != nums[i])
            {
                i++;
                nums[i] = nums[j];
            }
        }

        return i + 1;
    }
}