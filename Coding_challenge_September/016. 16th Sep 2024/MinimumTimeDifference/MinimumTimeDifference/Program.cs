public class Solution
{

    public int FindMinDifference(IList<string> timePoints)
    {
        List<int> minutesList = new List<int>();

        // Convert all time points to minutes
        foreach (var time in timePoints)
        {
            minutesList.Add(ConvertToMinutes(time));
        }

        // Sort the list of time points (in minutes)
        minutesList.Sort();

        // Initialize the minimum difference as a large number
        int minDiff = int.MaxValue;

        // Compare adjacent time points to find the smallest difference
        for (int i = 1; i < minutesList.Count; i++)
        {
            minDiff = Math.Min(minDiff, minutesList[i] - minutesList[i - 1]);
        }

        // Also check the difference between the first and last time points considering the circular nature
        minDiff = Math.Min(minDiff, 1440 - (minutesList[minutesList.Count - 1] - minutesList[0]));

        return minDiff;
    }

    public static int ConvertToMinutes(string time)
    {
        string[] parts = time.Split(':');
        int hours = int.Parse(parts[0]);
        int minutes = int.Parse(parts[1]);
        return hours * 60 + minutes;
    }
}