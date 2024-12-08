namespace Day_8_Resonant_Collinearity
{
    public static class Part2
    {
        public static void ProcessString((HashSet<(int, int)> grid, Dictionary<char, List<(int, int)>> antennas) data)
        {
            var (grid, antennas) = data;
            var allAntinodes = new HashSet<(int, int)>();

            foreach (var positions in antennas.Values)
            {
                allAntinodes.UnionWith(HelperClass.FindAllAntinodes(grid, positions));
            }

            Console.WriteLine("Total unique locations: " + allAntinodes.Count);
        }
    }
}
