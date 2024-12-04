using Day3_Mull_It_Over;

namespace Day_4_Ceres_Search
{
    public static class Part1
    {
        public static void ProcessString(string[] input)
        {
            int total = 0;
            foreach (var line in input)
            {
                total += CountAppearanceSearchWordInHorizontal(line);
            }
            string[] vertical = ChangeDirection(input);
            foreach (var line in vertical)
            {
                total += CountAppearanceSearchWordInHorizontal(line);
            }

            // Convert string[] to char[,]
            char[,] grid = HelperClass.ConvertToCharArray(input);

            total += CountWordInDiagonals(grid, "XMAS");
            total += CountWordInDiagonals(grid, "SAMX");

            Console.WriteLine(total);
        }

        public static int CountAppearanceSearchWordInHorizontal(string input)
        {
            string searchWord = "XMAS";
            string searchWord2 = "SAMX";
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (i + 4 <= input.Length && (input.Substring(i, 4) == searchWord || input.Substring(i, 4) == searchWord2))
                {
                    count++;
                }
            }

            return count;
        }

        

        static int CountWordInDiagonals(char[,] grid, string word)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            int count = 0;

            // Top-left to bottom-right diagonals
            for (int startRow = 0; startRow < rows; startRow++)
            {
                count += CountInDiagonal(grid, word, startRow, 0, 1, 1);
            }
            for (int startCol = 1; startCol < cols; startCol++)
            {
                count += CountInDiagonal(grid, word, 0, startCol, 1, 1);
            }

            // Top-right to bottom-left diagonals
            for (int startCol = 0; startCol < cols; startCol++)
            {
                count += CountInDiagonal(grid, word, 0, startCol, 1, -1);
            }
            for (int startRow = 1; startRow < rows; startRow++)
            {
                count += CountInDiagonal(grid, word, startRow, cols - 1, 1, -1);
            }

            return count;
        }

        static int CountInDiagonal(char[,] grid, string word, int startRow, int startCol, int rowIncrement, int colIncrement)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            int wordLength = word.Length;
            int count = 0;

            List<char> diagonal = new List<char>();
            int row = startRow, col = startCol;

            // Extract the diagonal
            while (row >= 0 && row < rows && col >= 0 && col < cols)
            {
                diagonal.Add(grid[row, col]);
                row += rowIncrement;
                col += colIncrement;
            }

            // Check for the word in the diagonal
            for (int i = 0; i <= diagonal.Count - wordLength; i++)
            {
                bool matches = true;
                for (int j = 0; j < wordLength; j++)
                {
                    if (diagonal[i + j] != word[j])
                    {
                        matches = false;
                        break;
                    }
                }
                if (matches) count++;
            }

            return count;
        }

        public static string[] ChangeDirection(string[] input)
        {
            int maxLength = 0;
            foreach (string line in input)
            {
                maxLength = Math.Max(maxLength, line.Length);
            }

            List<string> vertical = new List<string>();

            for (int col = 0; col < maxLength; col++)
            {
                string verticalLine = "";

                foreach (string line in input)
                {
                    if (col < line.Length)
                    {
                        verticalLine += line[col];
                    }
                    else
                    {
                        verticalLine += " ";
                    }
                }

                vertical.Add(verticalLine);
            }
            return vertical.ToArray();
        }
    }
}
