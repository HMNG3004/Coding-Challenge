namespace Day_9_Disk_Fragmenter
{
    public static class Part2
    {
        public static void ProcessString(List<Block> blocksList)
        {
            int fileID = blocksList[^1].ID;
            for (int j = blocksList.Count - 1; j > 0; j--)
            {
                Block block = blocksList[j];
                if (block.ID != fileID) { continue; }
                fileID--;

                for (int i = 0; i < j; i++)
                {
                    Block freeBlock = blocksList[i];
                    if (freeBlock.ID != 0 || block.Size > freeBlock.Size) { continue; }

                    blocksList[i] = block;
                    blocksList[j] = freeBlock;
                    if (block.Size != freeBlock.Size)
                    {
                        blocksList.Insert(i + 1, new Block() { Size = freeBlock.Size - block.Size });
                        freeBlock.Size = block.Size;
                        j++;
                    }
                    if (j + 1 < blocksList.Count && blocksList[j + 1].ID == 0)
                    {
                        freeBlock.Size += blocksList[j + 1].Size;
                        blocksList.RemoveAt(j + 1);
                    }
                    if (blocksList[j - 1].ID == 0)
                    {
                        blocksList[j - 1].Size += freeBlock.Size;
                        blocksList.RemoveAt(j);
                    }
                    break;
                }
            }

            long total = 0;
            int index = 0;
            for (int i = 0; i < blocksList.Count; i++)
            {
                Block block = blocksList[i];
                if (block.ID != 0)
                {
                    total += (block.ID - 1) * ((long)index * block.Size + (long)block.Size * (block.Size - 1) / 2);
                }
                index += block.Size;
            }


            Console.WriteLine($"Part 1: {total}");
        }
    }
}
