public class MyCalendar
{

    private List<int[]> calendar;
    public MyCalendar()
    {
        calendar = new List<int[]>(); ;
    }

    public bool Book(int start, int end)
    {
        foreach (var e in calendar)
        {
            if (e[0] < end && start < e[1])
            {
                return false;
            }
        }

        calendar.Add(new int[] { start, end });
        return true;
    }
}

public class Solution()
{    
    public static void Main()
    {
        MyCalendar calendar = new MyCalendar();
        Console.WriteLine(calendar.Book(10, 20)); // returns true
        Console.WriteLine(calendar.Book(15, 25)); // returns false
        Console.WriteLine(calendar.Book(20, 30)); // returns true
    }   
}