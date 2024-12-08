namespace Day_8_Resonant_Collinearity
{
    public static class HelperClass
    {
        public static (HashSet<(int, int)> grid, Dictionary<char, List<(int, int)>> antennas) ParseData(string input)
        {
            var grid = new HashSet<(int, int)>();
            var antennas = new Dictionary<char, List<(int, int)>>();

            var lines = input.Split("\n");
            for (int row = 0; row < lines.Length; row++)
            {
                for (int col = 0; col < lines[row].Length; col++)
                {
                    char ch = lines[row][col];
                    if (ch != '.')
                    {
                        if (!antennas.ContainsKey(ch))
                            antennas[ch] = new List<(int, int)>();
                        antennas[ch].Add((row, col));
                    }
                    grid.Add((row, col));
                }
            }
            return (grid, antennas);
        }

        public static HashSet<(int, int)> FindAntinodes(List<(int, int)> antennas)
        {
            var antinodes = new HashSet<(int, int)>();

            foreach (var pair in GetCombinations(antennas, 2))
            {
                var (row1, col1) = pair[0];
                var (row2, col2) = pair[1];

                var antinode1 = (2 * row1 - row2, 2 * col1 - col2);
                var antinode2 = (2 * row2 - row1, 2 * col2 - col1);

                antinodes.Add(antinode1);
                antinodes.Add(antinode2);
            }

            return antinodes;
        }

        public static HashSet<(int, int)> FindAllAntinodes(HashSet<(int, int)> grid, List<(int, int)> antennas)
        {
            var sortedAntennas = antennas.OrderBy(a => a).ToList();
            var antinodes = new HashSet<(int, int)>();

            foreach (var pair in GetCombinations(sortedAntennas, 2))
            {
                var (row1, col1) = pair[0];
                var (row2, col2) = pair[1];

                int dr = row2 - row1;
                int dc = col2 - col1;

                for (int n = -row1 / dr; n <= (grid.Max(p => p.Item1) - row1) / dr; n++)
                {
                    var candidate = (row1 + n * dr, col1 + n * dc);
                    if (grid.Contains(candidate))
                        antinodes.Add(candidate);
                }
            }

            return antinodes;
        }

        public static List<List<(int, int)>> GetCombinations(List<(int, int)> list, int r)
        {
            var result = new List<List<(int, int)>>();

            void Combine(int start, List<(int, int)> current)
            {
                if (current.Count == r)
                {
                    result.Add(new List<(int, int)>(current));
                    return;
                }

                for (int i = start; i < list.Count; i++)
                {
                    current.Add(list[i]);
                    Combine(i + 1, current);
                    current.RemoveAt(current.Count - 1);
                }
            }

            Combine(0, new List<(int, int)>());
            return result;
        }
    }
}