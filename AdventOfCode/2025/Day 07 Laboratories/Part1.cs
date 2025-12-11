namespace Day_07_Laboratories
{
    public static class Part1
    {
        public static long CountSplits(string[] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int startRow = -1, startCol = -1;

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
                throw new Exception("No S found in the grid.");

            // Tia bắt đầu ngay dưới S
            var beams = new HashSet<int> { startCol };

            long splitCount = 0;

            for (int r = startRow + 1; r < rows && beams.Count > 0; r++)
            {
                var rowBeams = new HashSet<int>(beams);

                while (true)
                {
                    var splitPositions = new List<int>();

                    foreach (var c in rowBeams)
                    {
                        if (grid[r][c] == '^')
                        {
                            splitPositions.Add(c);
                        }
                    }

                    if (splitPositions.Count == 0)
                        break;

                    foreach (var c in splitPositions)
                    {
                        // Một lần split
                        splitCount++;

                        // Tia cũ dừng
                        rowBeams.Remove(c);

                        // Tia mới bên trái
                        if (c - 1 >= 0)
                            rowBeams.Add(c - 1);

                        // Tia mới bên phải
                        if (c + 1 < cols)
                            rowBeams.Add(c + 1);
                    }
                }

                // Sau khi xử lý xong splitter ở hàng này,
                // các tia đi xuống hàng tiếp theo.
                beams = rowBeams;
            }

            return splitCount;
        }
    }
}
