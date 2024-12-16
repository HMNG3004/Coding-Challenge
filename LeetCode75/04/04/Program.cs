public class Program
{
    public static void Main()
    {
        TestCase([1, 0, 0, 0, 1], 1, true, "Test case 1");
        TestCase([1, 0, 0, 0, 1], 2, false, "Test case 2");
        TestCase([0], 1, true, "Test case 3");
    }

    public static void TestCase(int[] flowerbed, int n, bool expectation, string desciption)
    {
        var result = CanPlaceFlowers(flowerbed, n);
        System.Console.WriteLine($"{desciption} {(result == expectation ? "Passed" : "Failed")}");
    }

    public static bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        for (int i = 0; i < flowerbed.Length; i++)
        {
            int min = i - 1 < 0 ? 0 : i - 1;
            int max = i + 1 >= flowerbed.Length ? flowerbed.Length - 1 : i + 1;

            if (flowerbed[min] == 0 && flowerbed[i] == 0 && flowerbed[max] == 0)
            {
                flowerbed[i] = 1;
                n--;
            }
        }
        return n <= 0;
    }
}