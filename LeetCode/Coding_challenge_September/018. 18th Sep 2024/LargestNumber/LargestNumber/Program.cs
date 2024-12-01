public class Solution
{
    public static void Main()
    {
        TestCase1();
    }

    public static void TestCase1()
    {
        int[] nums = { 3, 30, 34, 5, 9 };
        Console.WriteLine(LargestNumber(nums));
    }

    public static string LargestNumber(int[] nums)
    {
        List<string> temp = nums.Select(x => x.ToString()).ToList();
        temp.Sort((String x, String y) =>
        {
            var s1 = x + y;
            var s2 = y + x;

            return s2.CompareTo(s1);
        });

        if (temp[0] == "0")
        {
            return "0";
        }

        return String.Join("", temp);
    }
}