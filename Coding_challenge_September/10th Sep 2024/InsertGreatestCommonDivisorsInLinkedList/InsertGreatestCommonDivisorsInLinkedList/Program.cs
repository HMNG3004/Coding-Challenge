public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public static void Main()
    {
        int z = FindGCD(18, 6);
        Console.WriteLine(z);
    }

    static int FindGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static ListNode AddElementsFromArray(int[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return null; // Return null if the array is empty
        }

        ListNode head = new ListNode(arr[0]); // Create the head of the linked list
        ListNode current = head;

        for (int i = 1; i < arr.Length; i++)
        {
            current.next = new ListNode(arr[i]); // Create new node and link it
            current = current.next; // Move to the next node
        }

        return head;
    }

    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        ListNode current = head;
        if(current.next == null)
        {
            return head;
        }

        while (current.next != null)
        {
            ListNode temp = current.next;
            int gcd = FindGCD(current.val, temp.val);
            ListNode newNode = new ListNode(gcd);
            newNode.next = current.next;
            current.next = newNode;
            current = newNode.next;
        }
        return head;
    }
}