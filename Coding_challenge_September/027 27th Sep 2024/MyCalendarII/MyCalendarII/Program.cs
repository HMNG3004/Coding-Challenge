public class Solution
{
    private List<(int start, int end)> bookings;
    private List<(int start, int end)> overlaps;

    public Solution()
    {
        bookings = new List<(int, int)>();
        overlaps = new List<(int, int)>();
    }

    public bool book(int start, int end)
    {
        // Check if the new booking would cause a triple booking
        foreach (var (oStart, oEnd) in overlaps)
        {
            if (Math.Max(start, oStart) < Math.Min(end, oEnd))
            {
                return false; // Triple booking detected
            }
        }

        // Check for overlaps with existing bookings
        foreach (var (bStart, bEnd) in bookings)
        {
            int overlapStart = Math.Max(start, bStart);
            int overlapEnd = Math.Min(end, bEnd);
            if (overlapStart < overlapEnd)
            {
                // Add the overlapping part to the overlaps list
                overlaps.Add((overlapStart, overlapEnd));
            }
        }

        // Add the new booking
        bookings.Add((start, end));
        return true;
    }
}

public class MyCalendarII
{
    public static void Main(string[] args)
    {
        Solution myCalendarTwo = new Solution();
        Console.WriteLine(myCalendarTwo.book(10, 20)); // return True, The event can be booked.
        Console.WriteLine(myCalendarTwo.book(50, 60)); // return True, The event can be booked. 
        Console.WriteLine(myCalendarTwo.book(10, 40)); // return True, The event can be double booked.;
        Console.WriteLine(myCalendarTwo.book(5, 15));  // return False, The event cannot be booked, because it would result in a triple booking.
        Console.WriteLine(myCalendarTwo.book(5, 10)); // return True, The event can be booked, as it does not use time 10 which is already double booked.
        Console.WriteLine(myCalendarTwo.book(25, 55)); // return True,
    }
}