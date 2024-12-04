using System.Text.RegularExpressions;

namespace Day3_Mull_It_Over
{
    public static class Part1
    {
        public static void ProcessString(string input)
        {
            int total = 0;
            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            MatchCollection matches = Regex.Matches(input, pattern);

            if (matches.Count > 0)
            {              
                foreach (Match match in matches)
                {
                    // Extract the two numbers
                    int number1 = int.Parse(match.Groups[1].Value);
                    int number2 = int.Parse(match.Groups[2].Value);

                    total += number1 * number2;
                }
            }
            Console.WriteLine($"Total: {total}");
        }
    }
}
