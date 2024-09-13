public class Program
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    public static void TestCase1()
    {
        int[] numbers = { 1, 2, 3, 4 };
        int m = 2;
        int n = 2;
        int[][] result = Construct2DArray(numbers, m, n);
        for (int i = 0; i < result.Length; i++)
        {
            for (int j = 0; j < result[i].Length; j++)
            {
                Console.Write(result[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void TestCase2()
    {
        int[] numbers = { 1, 2 };
        int m = 1;
        int n = 1;
        int[][] result = Construct2DArray(numbers, m, n);
        for (int i = 0; i < result.Length; i++)
        {
            for (int j = 0; j < result[i].Length; j++)
            {
                Console.Write(result[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static int[][] Construct2DArray(int[] original, int m, int n)
    {
        if (m * n != original.Length)
        {
            return new int[0][];
        }

        int[][] numbers = new int[m][];
        
        for (int i = 0; i < m; i++)
        {
            numbers[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                numbers[i][j] = original[i * n + j];
            }
        }
        return numbers;
    }
}