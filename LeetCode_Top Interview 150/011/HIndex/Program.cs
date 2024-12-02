using System.Diagnostics;

public class Program
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    public static void TestCase1()
    {
        int[] citations = [3, 0, 6, 1, 5];
        Console.WriteLine("TestCase 1");
        RunTestCase(citations);
    }

    public static void TestCase2()
    {
        int[] citations = [1, 3, 1];
        Console.WriteLine("TestCase 2");
        RunTestCase(citations);
    }
    public static void RunTestCase(int[] citations)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        long memoryBefore = GC.GetTotalMemory(false);
        int hIndex = HIndex2(citations);
        long memoryAfter = GC.GetTotalMemory(false);
        
        stopwatch.Stop();
        Console.WriteLine("Sorted citations: [" + string.Join(", ", citations) + "]");
        Console.WriteLine("H-Index: " + hIndex);
        Console.WriteLine("Memory used: " + (memoryAfter - memoryBefore) + " bytes");
        Console.WriteLine("Time elapsed: " + stopwatch.ElapsedMilliseconds + " ms");
    }

    public static int HIndex(int[] citations)
    {
        int n = citations.Length;
        int[] buckets = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            if (citations[i] >= n)
            {
                buckets[n]++;
            }
            else
            {
                buckets[citations[i]]++;
            }
        }

        int count = 0;
        for (int i = n; i >= 0; i--)
        {
            count += buckets[i];
            if (count >= i)
            {
                return i;
            }
        }

        return 0;
    }

    public static int HIndex2(int[] citations)
    {
        Array.Sort(citations, (a, b) => b.CompareTo(a));

        int hIndex = 0;
        for (int i = 0; i < citations.Length; i++)
        {
            if (citations[i] >= i + 1)
            {
                hIndex = i + 1;
            }
            else
            {
                break;
            }
        }

        return hIndex;
    }
}