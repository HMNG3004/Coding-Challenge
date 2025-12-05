namespace Day_04_Printing_Department
{
    public static class Part2
    {
        public static long SolvePart2(List<string> lines)
        {
            int rows = lines.Count;
            int cols = lines[0].Length;

            char[,] grid = new char[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    grid[r, c] = lines[r][c];

            int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };

            // 1. Tính degree ban đầu
            int[,] deg = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r, c] != '@') continue;

                    int count = 0;
                    for (int k = 0; k < 8; k++)
                    {
                        int nr = r + dr[k];
                        int nc = c + dc[k];
                        if (nr >= 0 && nr < rows && nc >= 0 && nc < cols &&
                            grid[nr, nc] == '@')
                        {
                            count++;
                        }
                    }
                    deg[r, c] = count;
                }
            }

            // 2. Queue các roll có degree < 4
            Queue<(int r, int c)> q = new Queue<(int r, int c)>();
            bool[,] inQueue = new bool[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r, c] == '@' && deg[r, c] < 4)
                    {
                        q.Enqueue((r, c));
                        inQueue[r, c] = true;
                    }
                }
            }

            long removed = 0;

            // 3. BFS-like peeling
            while (q.Count > 0)
            {
                var (r, c) = q.Dequeue();

                if (grid[r, c] != '@') continue; // already removed

                // remove
                grid[r, c] = '.';
                removed++;

                // neighbors update
                for (int k = 0; k < 8; k++)
                {
                    int nr = r + dr[k];
                    int nc = c + dc[k];
                    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;

                    if (grid[nr, nc] == '@')
                    {
                        deg[nr, nc]--;

                        if (deg[nr, nc] < 4 && !inQueue[nr, nc])
                        {
                            q.Enqueue((nr, nc));
                            inQueue[nr, nc] = true;
                        }
                    }
                }
            }

            return removed;
        }

    }
}
