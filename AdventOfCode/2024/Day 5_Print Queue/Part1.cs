using System;

namespace Day_5_Print_Queue
{
    public static class Part1
    {
        public static void ProceesString(Dictionary<int, HashSet<int>> orderRules, string[] commaSeparated)
        {
            List<int> middleNumbers = new List<int>();
            foreach (var updateStr in commaSeparated)
            {
                var update = updateStr.Split(',').Select(int.Parse).ToList();
                if (HelperClass.IsInOrder(update, orderRules))
                {
                    middleNumbers.Add(update[update.Count / 2]);
                }
            }

            int sum = middleNumbers.Sum();
            Console.WriteLine($"Sum of middle numbers: {sum}");
        }
    }
}