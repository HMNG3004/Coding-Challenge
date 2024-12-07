namespace Day_7_Bridge_Repair
{
    public static class Part2_SolutionTwo
    {
        public static void ProcessString(string[] lines)
        {
            Console.WriteLine("Processing Part 2 Solution Two");

            long totalCalibrationResult = 0;


            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                // Parse the target and numbers
                var parts = line.Split(": ");
                long target = long.Parse(parts[0]);
                var numbers = parts[1].Trim().Split(' ').Select(long.Parse).ToList();

                if (Combination(target, numbers) != 0)
                {
                    totalCalibrationResult += target;
                }
            }
            Console.WriteLine($"Total Calibration Result: {totalCalibrationResult}");
        }
        private static long Concat(long a, long b)
        {
            return long.Parse(a.ToString() + b.ToString());
        }

        private static long Combination(long result, List<long> numbers, long combined = 0)
        {
            long count = 0;

            if (numbers.Count == 0)
            {
                return combined == result ? 1 : 0;
            }

            var numbersCopy = new List<long>(numbers);
            var current = numbersCopy[0];
            numbersCopy.RemoveAt(0);

            count += Combination(result, numbersCopy, combined + current);
            if (count != 0) return count;

            count += Combination(result, numbersCopy, Concat(combined, current));
            if (count != 0) return count;

            if (combined == 0) combined = 1;
            count += Combination(result, numbersCopy, combined * current);

            return count;
        }
    }
}
