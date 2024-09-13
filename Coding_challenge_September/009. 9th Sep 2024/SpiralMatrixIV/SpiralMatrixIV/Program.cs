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
        //TestCase1();
        //TestCase2();
        TestCase3();
    }

    public static void TestCase1()
    {
        int[] arr = { 3, 0, 2, 6, 8, 1, 7, 9, 4, 2, 5, 5, 0 };
        ListNode head = AddElementsFromArray(arr);
        int m = 3;
        int n = 5;
        int[][] result = SpiralMatrix(m, n, head);
    }

    public static void TestCase2()
    {
        int[] arr = { 0, 1, 2 };
        ListNode head = AddElementsFromArray(arr);
        int m = 1;
        int n = 4;
        int[][] result = SpiralMatrix(m, n, head);
    }

    public static void TestCase3()
    {
        int[] arr = { 995, 348, 36, 516, 333, 627, 248, 422, 13, 225, 764, 311, 405, 695, 698, 83, 145, 783, 478 };
        ListNode head = AddElementsFromArray(arr);
        int m = 9;
        int n = 6;
        int[][] result = SpiralMatrix(m, n, head);
    }
    public static int[][] SpiralMatrix(int m, int n, ListNode head)
    {
        // Initialize the matrix with -1
        int[][] matrix = new int[m][];
        for (int i = 0; i < m; i++)
        {
            matrix[i] = new int[n];
            Array.Fill(matrix[i], -1);
        }

        // Directions for spiral traversal: right, down, left, up
        int[] dr = new int[] { 0, 1, 0, -1 }; // row changes
        int[] dc = new int[] { 1, 0, -1, 0 }; // column changes

        int r = 0, c = 0, dir = 0; // start at top-left, direction is right
        ListNode current = head;

        // Traverse the matrix and fill it with linked list values in spiral order
        for (int i = 0; i < m * n && current != null; i++)
        {
            matrix[r][c] = current.val;
            current = current.next;

            // Calculate the next position
            int nr = r + dr[dir];
            int nc = c + dc[dir];

            // Check if the next position is out of bounds or already visited
            if (nr < 0 || nr >= m || nc < 0 || nc >= n || matrix[nr][nc] != -1)
            {
                // Change direction
                dir = (dir + 1) % 4;
                nr = r + dr[dir];
                nc = c + dc[dir];
            }

            r = nr;
            c = nc;
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            Console.WriteLine(string.Join(", ", matrix[i]));
        }
        return matrix;
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
}