using Day3_Mull_It_Over;

namespace Day_4_Ceres_Search
{
    public static class Part2
    {
        public static void ProcessString(string[] input)
        {
            char[,] grid = HelperClass.ConvertToCharArray(input);

            // Count the number of X-MAS patterns
            int totalPatterns = CountXMASPatterns(grid);

            // Output the result
            Console.WriteLine($"Total X-MAS Patterns Found: {totalPatterns}");
        }

        private static int CountXMASPatterns(char[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            int count = 0;

            for (int row = 1; row < rows - 1; row++)
            {
                for (int col = 1; col < cols - 1; col++)
                {
                    // Check if the center is 'A'
                    if (grid[row, col] == 'A')
                    {
                        // Check top-left to bottom-right diagonal for "MAS" or "SAM" and
                        // Check top-right to bottom-left diagonal for "MAS" or "SAM"
                        if (
                            ((grid[row - 1, col - 1] == 'M' && grid[row + 1, col + 1] == 'S') || 
                                (grid[row - 1, col - 1] == 'S' && grid[row + 1, col + 1] == 'M')) && 
                            ((grid[row - 1, col + 1] == 'M' && grid[row + 1, col - 1] == 'S') || 
                                (grid[row - 1, col + 1] == 'S' && grid[row + 1, col - 1] == 'M')))
                            count++;                    
                    }
                }
            }

            return count;
        }
    }
}
