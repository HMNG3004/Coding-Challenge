public class Program
{
    public static void Main()
    {
        TestCase([1, 2, 3, 4], 5, 2, "Test case 1");
        TestCase([4, 4, 1, 3, 1, 3, 2, 2, 5, 5, 1, 5, 2, 1, 2, 3, 5, 4], 2, 2, "Test case 2");
    }

    public static void TestCase(int[] nums, int k, int expectation, string description)
    {
        var result = MaxOperations(nums, k);
        Console.WriteLine($"{description} : {(result == expectation ? "Passed" : "Failed")}");
    }

    // Time complexity: O(n^2) bad code made by me when I'm tired
    public static int MaxOperations(int[] nums, int k)
    {
        int count = 0;
        int i = 0;
        if (nums.Length == 1)
        {
            return 0;
        }
        while (i < nums.Length)
        {
            if (nums[i] >= k)
            {
                i++;
                continue;
            }
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == k && nums[i] < k && nums[j] < k)
                {
                    count++;
                    nums[i] = 0;
                    nums[j] = 0;
                    break;
                }
            }
            i++;
        }
        return count;
    }

    // Time complexity: O(n) better code which uses dictionary
    public static int MaxOperationsDictionary(int[] nums, int k)
    {
        var count = 0;
        var map = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            var diff = k - num;
            if (map.ContainsKey(diff) && map[diff] > 0)
            {
                count++;
                map[diff]--;
            }
            else
            {
                if (map.ContainsKey(num))
                {
                    map[num]++;
                }
                else
                {
                    map[num] = 1;
                }
            }
        }
        return count;
    }

    // Time complexity: O(nlogn) better code which uses two pointer
    public static int MaxOperationsTwoPointer(int[] nums, int k)
    {
        Array.Sort(nums);
        int left = 0;
        int count = 0;
        int right = nums.Length - 1;
        while (left < right)
        {
            if (nums[left] + nums[right] < k) left++;
            else if (nums[left] + nums[right] > k) right--;
            else
            {
                left++;
                right--;
                count++;
            }
        }

        return count;
    }
}