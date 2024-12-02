namespace Day_2_Red_Nosed_Reports
{
    public static class HelperClass
    {
        public static bool CanFixByRemovingOne(List<int> row)
        {
            for (int i = 0; i < row.Count; i++)
            {
                List<int> modifiedRow = new List<int>(row);
                modifiedRow.RemoveAt(i);

                if (CheckIfAllIncreasingOrDecreasing(modifiedRow))
                    return true;
            }
            return false;
        }

        public static bool CheckIfAllIncreasingOrDecreasing(List<int> row)
        {

            if (row.Count < 2)
                return true;

            bool isIncreasing = true;
            bool isDecreasing = true;

            for (int i = 0; i < row.Count - 1; i++)
            {
                int difference = row[i + 1] - row[i];

                // Check if it satisfies the "increasing" condition.
                if (difference < 1 || difference > 3)
                    isIncreasing = false;

                // Check if it satisfies the "decreasing" condition.
                if (-difference < 1 || -difference > 3)
                    isDecreasing = false;

                // If neither increasing nor decreasing, break early.
                if (!isIncreasing && !isDecreasing)
                    return false;
            }

            return isIncreasing || isDecreasing;
        }
    }
}
