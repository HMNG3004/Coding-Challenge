using Day_9_Disk_Fragmenter;
using LibraryHelper;

public class Program
{
    public static void Main()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(currentDirectory, "input.txt");
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: Could not find file '{filePath}'. Ensure the file exists in the output directory.");
            return;
        }
        ProcessParts(filePath);
    }

    public static void ProcessParts(string filePath)
    {
        string input = ReadFile.Instance.ReadFileAsString(filePath);
        int[] blocks;
        List<Block> blocksList = new();

        int total = 0;
        input = input.Replace("\r", "").Replace("\n", "");
        for (int i = 0; i < input.Length; i++)
        {
            int num = input[i] - 0x30;
            total += num;
        }

        blocks = new int[total];
        int id = 1;
        int index = 0;
        for (int i = 0; i < input.Length; i++)
        {
            int num = input[i] - 0x30;
            if ((i & 1) == 0)
            {
                for (int j = 0; j < num; j++)
                {
                    blocks[index++] = id;
                }
                blocksList.Add(new Block() { ID = id, Size = num });
                id++;
            }
            else if (num > 0)
            {
                blocksList.Add(new Block() { Size = num });
                index += num;
            }
        }
        Part1.ProcessString(blocks);
        Part2.ProcessString(blocksList);
    }
}