namespace Day_1_Secret_Entrance
{
    public static class Part1
    {
        public static void CountReachZero(List<string> lines)
        {
            int pos = 50;
            int countZero = 0;

            foreach (var line in lines)
            {
                char dir = line[0];
                int dist = int.Parse(line.Substring(1));

                if (dir == 'L')
                {
                    pos = ((pos - (dist % 100)) + 100) % 100;
                }
                else if (dir == 'R')
                {
                    pos = (pos + dist) % 100;
                }

                if (pos == 0)
                    countZero++;
            }

            Console.WriteLine($"Password = {countZero}");
        }
    }
}
