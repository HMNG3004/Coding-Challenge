namespace Day_06_Trash_Compactor
{
    public static class Part1
    {
        public static long SolvePart1(List<List<int>> matrix, List<char> operations)
        {
            int columns = matrix[0].Count;
            int rows = matrix.Count;

            if (operations.Count != columns)
                throw new Exception("Operation count does not match number of columns!");

            long total = 0;

            for (int col = 0; col < columns; col++)
            {
                char op = operations[col];

                long result = (op == '+') ? 0 : 1;

                for (int row = 0; row < rows; row++)
                {
                    if (op == '+')
                        result += matrix[row][col];
                    else if (op == '*')
                        result *= matrix[row][col];
                    else
                        throw new Exception($"Invalid operator {op}");
                }

                total += result;
            }

            return total;

        }
    }
}
