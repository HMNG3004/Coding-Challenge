public class Program
{
    public static void Main()
    {
        TeseCase("abc", [[0, 1, 0], [1, 2, 1], [0, 2, 1]], "ace", "Test Case 1");
    }

    public static void TeseCase(string s, int[][] shifts, string expectation, string description)
    {
        var result = ShiftingLetters(s, shifts);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static string ShiftingLetters(string s, int[][] shifts)
    {
        int n = s.Length;
        int[] shiftArray = new int[n + 1];

        foreach (var shift in shifts)
        {
            int start = shift[0];
            int end = shift[1];
            int direction = shift[2];

            int shiftValue = direction == 1 ? 1 : -1;

            shiftArray[start] += shiftValue;
            shiftArray[end + 1] -= shiftValue;
        }

        int cumulativeShift = 0;
        char[] result = s.ToCharArray();
        for (int i = 0; i < n; i++)
        {
            cumulativeShift += shiftArray[i];
            int effectiveShift = (cumulativeShift % 26 + 26) % 26;
            result[i] = (char)((result[i] - 'a' + effectiveShift) % 26 + 'a');
        }

        return new string(result);
    }
}