public class Solution
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    public static void TestCase1()
    {
        int[] arr1 = [1, 10, 100];
        int[] arr2 = [1000];
        int result = LongestCommonPrefix(arr1, arr2);
        Console.WriteLine(result);
    }

    public static void TestCase2()
    {
        int[] arr1 = [1, 2, 3];
        int[] arr2 = [4, 4, 4];
        int result = LongestCommonPrefix(arr1, arr2);
        Console.WriteLine(result);
    }

    public static int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        
        HashSet<int> set = new HashSet<int>();

        //Step 1: Build all possible prefixes from arr1
        for (int i = 0; i < arr1.Length; i++)
        {
            int num = arr1[i];
            while (!set.Contains(num) && num > 0)
            {
                set.Add(num);
                num /= 10;
            }
        }

        int longestLength = 0;

        // Step 2: Check each number in arr2 for the longest matching prefix
        for (int i = 0; i < arr2.Length; i++)
        {
            int num = arr2[i];
            while(!set.Contains(num) && num > 0)
            {
                num /= 10;
            }
            if(num > 0)
            {
                longestLength = Math.Max(longestLength, (int)Math.Log10(num) + 1);
            }
        }

        return longestLength;
    }
}