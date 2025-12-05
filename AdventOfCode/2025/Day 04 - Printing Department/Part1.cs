namespace Day_04_Printing_Department
{
    public static class Part1
    {
        public static long SolvePart1(List<string> lines)
        {
            int rows = lines.Count;
            int cols = lines[0].Length;

            // 8 hướng: 8 neighbors
            int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };

            long accessibleCount = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (lines[r][c] != '@')
                        continue;

                    int neighborRolls = 0;

                    for (int k = 0; k < 8; k++)
                    {
                        int nr = r + dr[k];
                        int nc = c + dc[k];

                        if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                            continue;

                        if (lines[nr][nc] == '@')
                            neighborRolls++;
                    }

                    if (neighborRolls < 4)
                    {
                        accessibleCount++;
                    }
                }
            }

            return accessibleCount;
        }

    }
}
