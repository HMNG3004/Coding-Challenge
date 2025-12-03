using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3_Lobby
{
    public static class Part2
    {
        public static long SolvePart2(List<string> lines)
        {
            long total = 0;

            foreach (var raw in lines)
            {
                string line = raw.Trim();
                if (line.Length == 0) continue;

                string best = Program.MaxNDigits(line, 12);

                long value = long.Parse(best);
                total += value;
            }

            return total;
        }
    }
}
