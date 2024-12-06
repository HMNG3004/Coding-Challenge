namespace Day_6_Guard_Gallivant
{
    public static class Part2
    {
        static readonly (int dx, int dy)[] Directions = { (0, -1), (1, 0), (0, 1), (-1, 0) };
        static readonly Dictionary<char, int> DirectionMap = new() { { '^', 0 }, { '>', 1 }, { 'v', 2 }, { '<', 3 } };
        public static void ProcessString(string[] lines)
        {
            Console.WriteLine("Part 2:");
            var start = FindGuard(lines, out int direction);
            var loopPositions = FindLoopCausingObstacles(lines, start, direction);

            Console.WriteLine(loopPositions.Count);
        }

        static (int x, int y) FindGuard(string[] map, out int direction)
        {
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (DirectionMap.ContainsKey(map[y][x]))
                    {
                        direction = DirectionMap[map[y][x]];
                        return (x, y);
                    }
                }
            }
            throw new Exception("Guard not found on the map.");
        }

        static List<(int x, int y)> FindLoopCausingObstacles(string[] map, (int x, int y) start, int startDirection)
        {
            var validPositions = new List<(int x, int y)>();

            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (map[y][x] == '.' && (x, y) != start)
                    {
                        if (CausesLoop(map, start, startDirection, (x, y)))
                            validPositions.Add((x, y));
                    }
                }
            }

            return validPositions;
        }

        static bool CausesLoop(string[] map, (int x, int y) start, int direction, (int x, int y) obstacle)
        {
            var visited = new HashSet<((int x, int y) position, int direction)>();
            var current = start;

            string[] tempMap = (string[])map.Clone();
            tempMap[obstacle.y] = tempMap[obstacle.y].Remove(obstacle.x, 1).Insert(obstacle.x, "#");

            while (true)
            {
                if (!visited.Add((current, direction))) return true; // Loop detected

                // Cal next position and direction
                var next = (current.x + Directions[direction].dx, current.y + Directions[direction].dy);

                if (next.Item1 < 0 || next.Item2 < 0 || next.Item2 >= tempMap.Length || next.Item1 >= tempMap[next.Item2].Length)
                    break; // Guard left the map

                if (tempMap[next.Item2][next.Item1] == '#')
                    direction = (direction + 1) % 4;
                else
                    current = next; // Move forward
            }

            return false;
        }
    }
}
