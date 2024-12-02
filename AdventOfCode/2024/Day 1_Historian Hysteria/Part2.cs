namespace Day_1_Historian_Hysteria
{
    public static class Part2
    {
        public static void CalculateTotalSimilarity(int[] array1, int[] array2)
        {
            var result = array1.Sum(num => CalculateSimilarity(num, array2) * num);
            Console.WriteLine($"Total Similarity Score: {result}");
        }

        public static int CalculateSimilarity(int num, int[] array2)
        {
            return array2.Count(x => x == num);
        }
    }
}
