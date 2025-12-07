namespace Day_5_Cafeteria
{
    public static class Part2
    {
        public static long SolvePart2(List<(long start, long end)> ranges)
        {
            var merged = Program.MergeRanges(ranges);

            long total = 0;
            foreach (var (s, e) in merged)
                total += (long)e - s + 1;

            return total;
        }

    }
}
