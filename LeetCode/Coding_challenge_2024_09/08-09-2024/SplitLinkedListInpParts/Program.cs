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

public class SplitLinkedListInParts
{
    public static void Main(string[] args)
    {
        
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



    public static void TestCase1()
    {
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        ListNode head = AddElementsFromArray(arr);
        int k = 3;
        ListNode[] result = SplitListToParts(head, k);
        // Expected output: [[1, 2, 3, 4], [5, 6, 7], [8, 9, 10]]
    }

    public static ListNode[] SplitListToParts(ListNode head, int k)
    {
        ListNode[] result = new ListNode[k];
        int length = 0;
        ListNode current = head;

        while (current != null)
        {
            length++;
            current = current.next;
        }

        int width = length / k;
        int remainder = length % k;
        current = head;

        for (int i = 0; i < k; i++)
        {
            ListNode dummy = new ListNode(0);
            ListNode write = dummy;

            for (int j = 0; j < width + (i < remainder ? 1 : 0); j++)
            {
                write = write.next = new ListNode(current.val);
                if (current != null)
                {
                    current = current.next;
                }
            }

            result[i] = dummy.next;
        }

        return result;
    }
}