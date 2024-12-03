using System.Xml.Linq;

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
public class DeleteNodesFromLinkedListPresentInArray
{
    public static void Main()
    {
        TestCase2();
    }



    public static void TestCase1()
    {
        int[] nums = new int[] { 1, 3, 5 };
        int[] node = new int[] { 1, 2, 3, 4, 5 };
        ListNode head = new ListNode(node[0]);
        ListNode curr = head;
        for (int i = 1; i < node.Length; i++)
        {
            curr.next = new ListNode(node[i]);
            if(curr.next != null)
            {
                curr = curr.next;
            }
        }

        head = ModifiedList(nums, head);
    }

    public static void TestCase2()
    {
        int[] nums = new int[] { 1 };
        int[] node = new int[] { 1, 2, 1, 2, 1, 2 };
        ListNode head = new ListNode(node[0]);
        ListNode curr = head;
        for (int i = 1; i < node.Length; i++)
        {
            curr.next = new ListNode(node[i]);
            if (curr.next != null)
            {
                curr = curr.next;
            }
        }

        head = ModifiedList(nums, head);

        ListNode current = head;

        if (current == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        while (current != null)
        {
            Console.Write(current.val + " -> ");
            current = current.next;
        }
        Console.WriteLine("null");
    }

    public static ListNode ModifiedList(int[] nums, ListNode head)
    {
        if (nums.Length == 0)
            return head;

        HashSet<int> numSet = new HashSet<int>(nums);
        ListNode temp = new ListNode(0);
        temp.next = head;

        ListNode curr = temp;
        while (curr != null && curr.next != null)
        {
            if (numSet.Contains(curr.next.val))
                curr.next = curr.next.next;
            else
                curr = curr.next;
        }

        return temp.next;
    }
}