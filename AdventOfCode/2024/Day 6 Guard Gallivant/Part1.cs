namespace Day_6_Guard_Gallivant
{
    public static class Part1
    {
        public static void ProcessString(string[] lines, (int, int) location)
        {
            Console.WriteLine("Part 1:");

            // Directions: Up, Right, Down, Left (clockwise)
            (int dx, int dy)[] directions = { (-1, 0), (0, 1), (1, 0), (0, -1) };
            int rows = lines.Length, cols = lines[0].Length;

            (int x, int y) = (location.Item1, location.Item2);
            int dir = 0;

            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            visited.Add((x, y));

            while (true)
            {
                int nx = x + directions[dir].dx;
                int ny = y + directions[dir].dy;

                if (nx < 0 || nx >= rows || ny < 0 || ny >= cols) break;

                if (lines[nx][ny] == '#')
                {
                    dir = (dir + 1) % 4;
                }
                else
                {
                    x = nx;
                    y = ny;
                    visited.Add((x, y));
                }
            }
            Console.WriteLine(visited.Count);
        }
    }
}
