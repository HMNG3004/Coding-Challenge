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

public class Program
{
    public static void Main()
    {

    }

    public TreeNode ReverseOddLevels(TreeNode root)
    {
        Reverse(root.left, root.right, 0);
        return root;
    }

    private void Reverse(TreeNode leftChild, TreeNode rightChild, int level)
    {
        if (leftChild == null || rightChild == null)
        {
            return;
        }

        if (level % 2 == 0)
        {
            int temp = leftChild.val;
            leftChild.val = rightChild.val;
            rightChild.val = temp;
        }

        Reverse(leftChild.left, rightChild.right, level + 1);
        Reverse(leftChild.right, rightChild.left, level + 1);
    }
}