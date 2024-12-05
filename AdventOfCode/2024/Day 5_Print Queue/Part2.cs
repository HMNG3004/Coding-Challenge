namespace Day_5_Print_Queue
{
    public class Part2
    {
        public static void ProceesString(Dictionary<int, HashSet<int>> orderRules, string[] commaSeparated)
        {
            List<int> middleNumbers = new List<int>();
            foreach (var updateStr in commaSeparated)
            {
                var update = updateStr.Split(',').Select(int.Parse).ToList();
                if (!HelperClass.IsInOrder(update, orderRules))
                {
                    var reordered = HelperClass.Reorder(update, orderRules);
                    middleNumbers.Add(reordered[reordered.Count / 2]);
                }
            }

            // Sum of middle numbers
            int sum = middleNumbers.Sum();
            Console.WriteLine($"Sum of middle numbers: {sum}");
        }
    }
}
