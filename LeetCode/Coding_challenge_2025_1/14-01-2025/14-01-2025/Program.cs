public class Program
{
    public static void Main()
    {

    }

    public static void TestCase()
    {

    }

    public static int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        var state = new int[A.Length];
        var result = new List<int>();

        var count = 0;

        for (int i = 0; i < A.Length; i++)
        {
            var ai = A[i] - 1;
            var bi = B[i] - 1;

            state[ai]++;
            state[bi]++;

            if (ai == bi)
            {
                if (state[ai] == 2)
                    count++;
            }
            else
            {
                if (state[ai] == 2)
                    count++;
                if (state[bi] == 2)
                    count++;
            }

            result.Add(count);
        }

        return result.ToArray();
    }
}