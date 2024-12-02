class Program
{
    private static void Main()
    {
        int[] nums = { 3, 2, 2, 3 };
        int val = 3;
        int result = RemoveElement(nums, val);
        Console.WriteLine(result);
    }

    private static int RemoveElement(int[] nums, int val)
    {
        int i = 0;
        for (int j = 0; j < nums.Length; j++)
        {
            if (nums[j] != val)
            {
                nums[i] = nums[j];
                i++;
            }
        }
        return i;
    }
}