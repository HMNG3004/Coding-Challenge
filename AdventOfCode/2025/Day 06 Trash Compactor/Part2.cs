namespace Day_06_Trash_Compactor
{
    public static class Part2
    {
        public static long SolvePart2(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            int rows = lines.Length;
            int cols = lines.Max(l => l.Length);

            // Normalize to rectangular grid
            char[,] grid = new char[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                var padded = lines[r].PadRight(cols);
                for (int c = 0; c < cols; c++)
                    grid[r, c] = padded[c];
            }

            // 1) Find problem column-blocks
            List<(int start, int end)> blocks = new();
            int col = 0;

            while (col < cols)
            {
                // Skip empty columns (spaces only)
                while (col < cols && IsEmptyColumn(grid, rows, col))
                    col++;

                if (col >= cols) break;

                int start = col;
                while (col < cols && !IsEmptyColumn(grid, rows, col))
                    col++;

                int end = col - 1;
                blocks.Add((start, end));
            }

            // 2) Solve each block (right-to-left numbers)
            long total = 0;

            foreach (var (startCol, endCol) in blocks)
            {
                List<long> numbers = new();

                // operator is at bottom row, at ANY column inside block
                // we just pick the leftmost column
                char op = grid[rows - 1, startCol];

                // Read columns from right -> left
                for (int c = endCol; c >= startCol; c--)
                {
                    string digits = "";

                    // Read digits top -> bottom
                    for (int r = 0; r < rows - 1; r++) // exclude operator row
                    {
                        if (char.IsDigit(grid[r, c]))
                            digits += grid[r, c];
                    }

                    if (digits.Length > 0)
                    {
                        numbers.Add(long.Parse(digits));
                    }
                }

                if (op == '+')
                {
                    total += numbers.Sum();
                }
                else if (op == '*')
                {
                    long product = 1;
                    foreach (var n in numbers)
                        product *= n;

                    total += product;
                }
                else
                {
                    throw new Exception($"Invalid operator: {op}");
                }
            }

            return total;
        }

        private static bool IsEmptyColumn(char[,] grid, int rows, int col)
        {
            for (int r = 0; r < rows; r++)
                if (grid[r, col] != ' ')
                    return false;
            return true;
        }
    }
}
