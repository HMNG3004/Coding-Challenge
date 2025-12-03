namespace Day_3_Lobby
{
    public static class Part1
    {
        public static long Solve(List<string> lines)
        {
            //long total = 0;

            //foreach (var raw in lines)
            //{
            //    var line = raw.Trim();
            //    if (line.Length == 0) continue;

            //    total += MaxJoltageForBank(line);
            //}

            //return total;

            long total = 0;

            foreach (var raw in lines)
            {
                string line = raw.Trim();
                if (line.Length == 0) continue;

                string best = Program.MaxNDigits(line, 2);

                long value = long.Parse(best);
                total += value;
            }

            return total;
        }

        static int MaxJoltageForBank(string line)
        {
            int bestPrefixDigit = -1;
            int bestValue = -1;

            foreach (char c in line)
            {
                if (c < '0' || c > '9') continue;

                int d = c - '0';

                if (bestPrefixDigit != -1)
                {
                    int candidate = bestPrefixDigit * 10 + d;
                    if (candidate > bestValue)
                        bestValue = candidate;
                }

                if (d > bestPrefixDigit)
                {
                    bestPrefixDigit = d;
                }
            }

            return bestValue;
        }
    }
}
