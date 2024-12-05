namespace Day_5_Print_Queue
{
    public static class HelperClass
    {
        // Function to check if an update is in the correct order
        public static bool IsInOrder(List<int> update, Dictionary<int, HashSet<int>> orderRules)
        {
            for (int i = 0; i < update.Count; i++)
            {
                for (int j = i + 1; j < update.Count; j++)
                {
                    if (orderRules.ContainsKey(update[j]) && orderRules[update[j]].Contains(update[i]))
                        return false;
                }
            }
            return true;
        }

        // Function to reorder an update according to the rules
        public static List<int> Reorder(List<int> update, Dictionary<int, HashSet<int>> orderRules)
        {
            return update.OrderBy(x => x, Comparer<int>.Create((a, b) =>
            {
                if (a == b) return 0;
                if (orderRules.ContainsKey(a) && orderRules[a].Contains(b)) return -1;
                if (orderRules.ContainsKey(b) && orderRules[b].Contains(a)) return 1;
                return 0;
            })).ToList();
        }
    }
}
