namespace WalkingRobotSimulation
{
    public class WalkingRobotSimulation
    {
        public static void Main()
        {
            TestCase1();
        }

        public static void TestCase1()
        {
            int[] commands = new int[] { 4, -1, 3 };
            int[][] obstacles = new int[][] { };
            int result = RobotSim(commands, obstacles);
            Console.WriteLine(result);
        }

        public static int RobotSim(int[] commands, int[][] obstacles)
        {
            // Direction vectors: North, East, South, West
            int[] dx = new int[] { 0, 1, 0, -1 };
            int[] dy = new int[] { 1, 0, -1, 0 };

            int x = 0, y = 0, di = 0;
            int maxDistanceSq = 0;

            HashSet<string> obstacleSet = new HashSet<string>();
            foreach (var obstacle in obstacles)
            {
                obstacleSet.Add(obstacle[0] + "," + obstacle[1]);
            }

            foreach (var cmd in commands)
            {
                if (cmd == -2)
                {
                    di = (di + 3) % 4;
                }
                else if (cmd == -1)
                {
                    di = (di + 1) % 4;
                }
                else
                {
                    for (int i = 0; i < cmd; i++)
                    {
                        int nx = x + dx[di];
                        int ny = y + dy[di];
                        if (obstacleSet.Contains(nx + "," + ny))
                        {
                            break;
                        }
                        x = nx;
                        y = ny;
                        maxDistanceSq = Math.Max(maxDistanceSq, x * x + y * y);
                    }
                }
            }

            return maxDistanceSq;
        }
    }
}