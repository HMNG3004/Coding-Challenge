public class Program
{
    public static void Main()
    {

    }

    public static void MoveZeroes(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (left < right)
        {
            if (nums[left] == 0)
            {
                for (int i = left; i < right; i++)
                {
                    nums[i] = nums[i + 1];
                }
                nums[right] = 0;
                right--;
            }
            else
            {
                left++;
            }
        }
    }

    public static void MoveZeroes2(int[] nums)
    {
        int i = 0;
        int j = 0;
        while (i < nums.Length)
        {
            if (nums[i] == 0)
            {
                i++;
            }
            else
            {
                nums[j] = nums[i];
                i++;
                j++;
            }
        }
        while (j < nums.Length)
        {
            nums[j] = 0;
            j++;
        }
    }
}