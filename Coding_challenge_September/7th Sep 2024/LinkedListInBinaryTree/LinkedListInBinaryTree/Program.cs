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

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public bool IsSubPath(ListNode head, TreeNode root)
    {
        if (head == null) return true;
        if (root == null) return false;
        return IsSubPath(head, root, 0) || IsSubPath(head, root.left) || IsSubPath(head, root.right);
    }

    private bool IsSubPath(ListNode head, TreeNode root, int depth)
    {
        if (head == null) return true;
        if (root == null) return false;
        if (head.val != root.val) return false;
        return IsSubPath(head.next, root.left, depth + 1) || IsSubPath(head.next, root.right, depth + 1);
    }
}