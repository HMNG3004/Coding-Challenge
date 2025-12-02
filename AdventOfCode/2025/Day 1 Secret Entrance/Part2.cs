namespace Day_1_Secret_Entrance
{
    public static class Part2
    {
        public static void CountReachZero(List<string> lines)
        {
            int pos = 50;
            long countZero = 0;

            foreach (var line in lines)
            {
                char dir = line[0];
                int dist = int.Parse(line.Substring(1));

                int fullLoops = dist / 100;
                int residual = dist % 100;

                countZero += fullLoops;

                if (dir == 'R')
                {
                    int target = (100 - pos) % 100;
                    if (target == 0) target = 100;
                    if (target <= residual) countZero++;

                    pos = (pos + dist) % 100;
                }
                else
                {
                    int target = pos % 100;
                    if (target == 0) target = 100;
                    if (target <= residual) countZero++;

                    pos = ((pos - dist) % 100 + 100) % 100;
                }
            }

            Console.WriteLine($"Password = {countZero}");
        }
    }
}
