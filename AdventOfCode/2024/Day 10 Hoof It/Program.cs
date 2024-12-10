public class Program
{
    public static int rows;
    public static int cols;
    public static int[,] map;

    // Directions for movement: up, down, left, right
    static int[] dr = { -1, 1, 0, 0 };
    static int[] dc = { 0, 0, -1, 1 };
    public static void Main()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(currentDirectory, "input.txt");

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: Could not find file '{filePath}'. Ensure the file exists in the output directory.");
            return;
        }

        string[] mapInput = File.ReadAllLines(filePath);

        rows = mapInput.Length;
        cols = mapInput[0].Length;

        // Convert the map to a 2D array of integers
        map = new int[rows, cols];
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                map[r, c] = mapInput[r][c] - '0';
            }
        }

        Part1();
        Part2();
    }

    public static void Part1()
    {
        int totalScore = 0;

        // Find trailheads and calculate their scores
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (map[r, c] == 0) // Trailhead
                {
                    totalScore += GetTrailheadScore(r, c);
                }
            }
        }
        Console.WriteLine($"Total score of all trailheads: {totalScore}");
    }

    public static void Part2()
    {
        int totalRating = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (map[r, c] == 0) // Trailhead
                {
                    totalRating += CountTrails(r, c, 0);
                }
            }
        }

        Console.WriteLine($"Total rating of all trailheads: {totalRating}");
    }

    // Function to check if a position is within bounds
    public static bool IsInBounds(int r, int c) => r >= 0 && r < rows && c >= 0 && c < cols;

    public static int GetTrailheadScore(int startRow, int startCol)
    {
        // BFS to find all reachable height 9s starting from a trailhead
        var visited = new bool[rows, cols];
        var queue = new Queue<(int r, int c, int height)>();
        queue.Enqueue((startRow, startCol, 0));
        visited[startRow, startCol] = true;

        int score = 0;

        while (queue.Count > 0)
        {
            var (currentRow, currentCol, currentHeight) = queue.Dequeue();

            // Check if we reached height 9
            if (map[currentRow, currentCol] == 9)
            {
                score++;
                continue;
            }

            // Explore neighbors
            for (int i = 0; i < 4; i++)
            {
                int newRow = currentRow + dr[i];
                int newCol = currentCol + dc[i];

                if (IsInBounds(newRow, newCol) &&
                    !visited[newRow, newCol] &&
                    map[newRow, newCol] == currentHeight + 1)
                {
                    visited[newRow, newCol] = true;
                    queue.Enqueue((newRow, newCol, currentHeight + 1));
                }
            }
        }

        return score;
    }

    public static int CountTrails(int r, int c, int currentHeight)
    {
        if (!IsInBounds(r, c) || map[r, c] != currentHeight) return 0;

        if (currentHeight == 9) return 1; // Reached height 9, valid trail

        int trails = 0;

        // Explore all 4 possible directions
        for (int i = 0; i < 4; i++)
        {
            int newRow = r + dr[i];
            int newCol = c + dc[i];
            trails += CountTrails(newRow, newCol, currentHeight + 1);
        }

        return trails;
    }
}