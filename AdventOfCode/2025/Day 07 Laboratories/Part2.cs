namespace Day_07_Laboratories
{
    public static class Part2
    {
        public static long CountTimelines(string[] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int startRow = -1, startCol = -1;

            // Find S
            for (int r = 0; r < rows; r++)
            {
                int c = grid[r].IndexOf('S');
                if (c != -1)
                {
                    startRow = r;
                    startCol = c;
                    break;
                }
            }

            if (startRow == -1)
                throw new Exception("No S found");

            // DP array: only need 2 rows at a time
            long[] prev = new long[cols];
            long[] curr = new long[cols];

            // Starting beam is right below S
            prev[startCol] = 1;

            long total = 0;

            // Process row by row
            for (int r = startRow + 1; r < rows; r++)
            {
                Array.Clear(curr, 0, cols);

                for (int c = 0; c < cols; c++)
                {
                    long ways = prev[c];
                    if (ways == 0) continue;

                    char ch = grid[r][c];

                    if (ch == '.')
                    {
                        curr[c] += ways;
                    }
                    else if (ch == '^')
                    {
                        if (c - 1 >= 0) curr[c - 1] += ways;
                        if (c + 1 < cols) curr[c + 1] += ways;
                    }
                    else
                    {
                        // Not '.' or '^' → unreachable (S only once)
                    }
                }

                var temp = prev;
                prev = curr;
                curr = temp;
            }

            // Sum all ways after last row
            long result = 0;
            for (int c = 0; c < cols; c++)
                result += prev[c];

            return result;
        }

    }
}
