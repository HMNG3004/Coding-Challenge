namespace Day_1_Historian_Hysteria
{
    public static class Part1
    {
        public static void CalculateDistance(int[] array1, int[] array2)
        {
            var sortedArray1 = array1.OrderBy(x => x).ToArray();
            var sortedArray2 = array2.OrderBy(x => x).ToArray();

            var result = sortedArray1.Zip(sortedArray2, (a, b) => Math.Abs(a - b)).Sum();
            Console.WriteLine($"Total Distance: {result}");
        }
    }
}
