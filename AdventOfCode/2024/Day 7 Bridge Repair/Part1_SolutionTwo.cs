namespace Day_7_Bridge_Repair
{
    public static class Part1_SolutionTwo
    {
        public static void ProcessString(string[] lines)
        {
            Console.WriteLine("Processing Part 1 Solution Two");

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

        private static long Combination(long result, List<long> numbers, long combined = 0)
        {
            if (numbers.Count == 0)
            {
                return combined == result ? 1 : 0;
            }

            var current = numbers[0];
            numbers.RemoveAt(0);

            long count = 0;

            // Addition: combined + current
            count += Combination(result, new List<long>(numbers), combined + current);

            count += Combination(result, new List<long>(numbers), combined * current);

            return count;
        }
    }
}
