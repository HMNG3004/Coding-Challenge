namespace Day_9_Disk_Fragmenter
{
    public static class Part1
    {
        public static void ProcessString(int[] blocks)
        {
            int minIndex = 0;
            int maxIndex = blocks.Length - 1;

            while (minIndex < maxIndex)
            {
                while (minIndex < maxIndex)
                {
                    if (blocks[minIndex] == 0) { break; }
                    minIndex++;
                }
                while (maxIndex > minIndex)
                {
                    if (blocks[maxIndex] != 0) { break; }
                    maxIndex--;
                }
                if (minIndex < maxIndex)
                {
                    blocks[minIndex] = blocks[maxIndex];
                    blocks[maxIndex] = 0;
                }
            }

            long total = 0;
            for (int i = 0; i < blocks.Length; i++)
            {
                int id = blocks[i];
                if (id == 0) { break; }
                total += (id - 1) * i;
            }

            Console.WriteLine($"Part 1: {total}");
        }
    }
}
