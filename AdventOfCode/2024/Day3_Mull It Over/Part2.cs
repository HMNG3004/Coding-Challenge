using System.Text.RegularExpressions;

namespace Day3_Mull_It_Over
{
    public static class Part2
    {
        public static void ProcessString(string input)
        {
            string mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            string doPattern = @"do\(\)";
            string dontPattern = @"don't\(\)";

            string combinedPattern = $@"{mulPattern}|{doPattern}|{dontPattern}";

            Regex regex = new Regex(combinedPattern);

            bool isMulEnabled = true; // Default state
            int totalSum = 0;

            foreach (Match match in regex.Matches(input))
            {
                if (match.Value.StartsWith("do()"))
                {
                    isMulEnabled = true;
                }
                else if (match.Value.StartsWith("don't()"))
                {
                    isMulEnabled = false;
                }
                else if (match.Groups[1].Success && match.Groups[2].Success)
                {
                    if (isMulEnabled)
                    {
                        int number1 = int.Parse(match.Groups[1].Value);
                        int number2 = int.Parse(match.Groups[2].Value);
                        int product = number1 * number2;
                        totalSum += product;
                    }
                }
            }

            Console.WriteLine($"Total: {totalSum}");
        }
    }
}
