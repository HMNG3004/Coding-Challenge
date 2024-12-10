namespace Day_9_Disk_Fragmenter
{
    public class Block
    {
        public int ID, Size;
        public override string ToString()
        {
            if (ID == 0)
            {
                return $"Free Size: {Size}";
            }
            return $"ID: {ID - 1} Size: {Size}";
        }
    }
}
