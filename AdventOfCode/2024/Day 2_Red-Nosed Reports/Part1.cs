using LibraryHelper;

namespace Day_2_Red_Nosed_Reports
{
    public static class Part1
    {
        public static void ProcessList(List<List<int>> rows)
        {
            int count = 0;
            foreach (var row in rows)
            {
                if (HelperClass.CheckIfAllIncreasingOrDecreasing(row))
                {
                    count++;
                }
            }
            Console.WriteLine($"Total reports are safe: {count}");
        }
    }
}
