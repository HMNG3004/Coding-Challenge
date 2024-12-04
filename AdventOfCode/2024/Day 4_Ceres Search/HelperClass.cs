namespace Day3_Mull_It_Over
{
    public static class HelperClass
    {
        public static char[,] ConvertToCharArray(string[] gridLines)
        {
            int rows = gridLines.Length;
            int cols = gridLines.Max(line => line.Length); // Find the longest string length

            char[,] grid = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // Use a placeholder if the column index exceeds the string length
                    grid[row, col] = col < gridLines[row].Length ? gridLines[row][col] : ' ';
                }
            }
            return grid;
        }
    }
}
