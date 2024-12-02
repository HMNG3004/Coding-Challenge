namespace Day_2_Red_Nosed_Reports
{
    public static class Part2
    {
        public static void ProcessList(List<List<int>> rows)
        {
            int count = 0;
            foreach (var row in rows)
            {
                if (HelperClass.CheckIfAllIncreasingOrDecreasing(row) || HelperClass.CanFixByRemovingOne(row))
                {
                    count++;
                }
            }
            Console.WriteLine($"After fixing, total reports are now safe?: {count}");
            Console.WriteLine(count);
        }
    }
}
