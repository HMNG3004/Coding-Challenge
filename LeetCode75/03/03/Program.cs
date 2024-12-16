using System.Linq;

public class Program
{
    public static void Main()
    {
        TestCase([2, 3, 5, 1, 3], 3, [true, true, true, false, true], "Test case 1");
    }

    public static void TestCase(int[] candies, int extraCandies, bool[] expectation, string description)
    {
        var result = KidsWithCandies(candies, extraCandies);
        var hasDuplicates = result.Intersect(expectation).Any();
        Console.WriteLine($"{description} {(hasDuplicates ? "Passed" : "Failed")}");
    }

    public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        List<bool> result = new List<bool>();
        int max = candies.Max();
        for(int i = 0; i < candies.Length; i++)
        {
            result.Add(candies[i] + extraCandies >= max);
        }    
        return result;
    }
}