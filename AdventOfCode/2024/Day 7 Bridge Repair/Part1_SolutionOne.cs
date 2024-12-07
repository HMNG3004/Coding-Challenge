using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_7_Bridge_Repair
{
    public static class Part1_SolutionOne
    {
        public static void ProcessString(string[] lines)
        {
            Console.WriteLine("Processing Part 1 Solution One");

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

            var operatorCombinations = GenerateOperatorCombinations(operatorSlots);

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
            var result = new List<string>();
            int totalCombinations = (int)Math.Pow(2, slots);

            for (int i = 0; i < totalCombinations; i++)
            {
                char[] combination = new char[slots];
                for (int j = 0; j < slots; j++)
                {
                    combination[j] = ((i >> j) & 1) == 0 ? '+' : '*';
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
                if (operators[i] == '+')
                {
                    result += numbers[i + 1];
                }
                else if (operators[i] == '*')
                {
                    result *= numbers[i + 1];
                }
            }

            return result;
        }
    }
}
