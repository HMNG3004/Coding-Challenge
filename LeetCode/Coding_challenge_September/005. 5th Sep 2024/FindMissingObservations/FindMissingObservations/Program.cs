public class FindMissObservations
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    public static void TestCase1()
    {
        int[] rolls = { 1, 5, 6 };
        int mean = 3;
        int n = 4;
        int[] result = MissingRolls(rolls, mean, n);
        foreach(int i in result)
        {
            Console.Write(i + " ");
        }
    }

    public static void TestCase2()
    {
        int[] rolls = { 3, 2, 4, 3 };
        int mean = 4;
        int n = 2;
        int[] result = MissingRolls(rolls, mean, n);
        foreach(int i in result)
        {
            Console.Write(i + " ");
        }
    }

    public static int[] MissingRolls(int[] rolls, int mean, int n)
    {        
        int totalLength = rolls.Length + n;
        int totalSum = mean * totalLength;
        foreach(int roll in rolls)
        {
            totalSum -= roll;
        }
        
        if(totalSum > 0)
        {
            int[] arr = new int[n];
            if (totalSum > 6 * n || totalSum < n)
            {
                return new int[0];
            }
            else
            {
                
                if (totalSum % n > 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        arr[i] = totalSum / n + (i < totalSum % n ? 1 : 0);
                    }
                }
                else if (totalSum % n == 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        arr[i] = totalSum / n;
                    }
                }
                return arr;
            }            
        }

        return new int[0];
    }
}