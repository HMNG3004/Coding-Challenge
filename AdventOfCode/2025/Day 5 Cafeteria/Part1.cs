namespace Day_5_Cafeteria
{
    public static class Part1
    {
        public static int SolvePart1(List<(long start, long end)> ranges, List<long> ids)
        {
            var merged = Program.MergeRanges(ranges);

            int count = 0;
            foreach (var id in ids)
                if (IsFresh(merged, id))
                    count++;

            return count;
        }

        static bool IsFresh(List<(long start, long end)> ranges, long id)
        {
            int left = 0, right = ranges.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                var (s, e) = ranges[mid];

                if (id < s) right = mid - 1;
                else if (id > e) left = mid + 1;
                else return true;
            }

            return false;
        }
    }
}
