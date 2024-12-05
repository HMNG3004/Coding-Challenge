public class Program
{
    public static void Main()
    {
        Console.WriteLine("Running Test Cases...");
        TestCase("_L__R__R_", "L______RR", true, "Test case 1:");
        TestCase("R_L_", "__LR", false, "Test case 2:");
        TestCase("_R", "R_", false, "Test case 3:");
    }

    public static void TestCase(string str1, string str2, bool expected, string description)
    {
        var result = CanMovePiecesToObtainAString(str1, str2);
        Console.WriteLine($"{description} {(result == expected ? "Passed" : "Failed")}");
    }

    public static bool CanMovePiecesToObtainAString(string start, string target)
    {
        string startPieces = new string(start.Where(c => c != '_').ToArray());
        string targetPieces = new string(target.Where(c => c != '_').ToArray());
        if (startPieces != targetPieces)
        {
            return false;
        }

        int startIndex = 0, targetIndex = 0;
        int n = start.Length;
        while (startIndex < n && targetIndex < n)
        {
            while (startIndex < n && start[startIndex] == '_') startIndex++;
            while (targetIndex < n && target[targetIndex] == '_') targetIndex++;

            if (startIndex < n && targetIndex < n)
            {
                if (start[startIndex] != target[targetIndex])
                {
                    return false;
                }

                if (start[startIndex] == 'L' && startIndex < targetIndex)
                {
                    return false;
                }
                if (start[startIndex] == 'R' && startIndex > targetIndex)
                {
                    return false;
                }

                startIndex++;
                targetIndex++;
            }
        }

        return true;
    }
}