namespace Day_7_Bridge_Repair
{
    public static class Part2_SolutionOne
    {
        public static void ProcessString(string[] lines)
        {
            Console.WriteLine("Processing Part 2 Solution One");

            long totalCalibrationResult = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                // Parse the target and numbers
                var parts = line.Split(": ");
                long target = long.Parse(parts[0]);
                var numbers = parts[1].Trim().Split(' ').Select(long.Parse).ToList();

                if (CanGenerateTarget(numbers, target))
                {
                    totalCalibrationResult += target;
                }
            }

            Console.WriteLine($"Total Calibration Result: {totalCalibrationResult}");
        }

        public static bool CanGenerateTarget(List<long> numbers, long target)
        {
            int operatorSlots = numbers.Count - 1;
            if (operatorSlots == 0) return numbers[0] == target;

            // Generate all combinations of `+`, `*`, and `||`
            var operatorCombinations = GenerateOperatorCombinations(operatorSlots);

            // Evaluate each combination
            foreach (var ops in operatorCombinations)
            {
                if (EvaluateExpression(numbers, ops) == target)
                {
                    return true;
                }
            }

            return false;
        }

        private static List<string> GenerateOperatorCombinations(int slots)
        {
            // Generate all combinations of `+`, `*`, and `||` for the given number of slots
            var result = new List<string>();
            int totalCombinations = (int)Math.Pow(3, slots); // 3^slots combinations

            for (int i = 0; i < totalCombinations; i++)
            {
                char[] combination = new char[slots];
                for (int j = 0; j < slots; j++)
                {
                    // Assign operators based on the current combination
                    int operatorIndex = (i / (int)Math.Pow(3, j)) % 3;
                    combination[j] = operatorIndex switch
                    {
                        0 => '+',
                        1 => '*',
                        2 => '|', // This represents "||"
                        _ => throw new InvalidOperationException("Invalid operator index.")
                    };
                }
                result.Add(new string(combination));
            }

            return result;
        }

        private static long EvaluateExpression(List<long> numbers, string operators)
        {
            long result = numbers[0];

            for (int i = 0; i < operators.Length; i++)
            {
                long nextNumber = numbers[i + 1];

                // Apply the corresponding operator between current result and next number
                switch (operators[i])
                {
                    case '+':
                        result += nextNumber;
                        break;
                    case '*':
                        result *= nextNumber;
                        break;
                    case '|':
                        result = long.Parse(result.ToString() + nextNumber.ToString()); // Concatenate as string and then parse back to long
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operator.");
                }
            }

            return result;
        }
    }
}
