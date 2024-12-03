public class MyCircularDeque
{
    private int[] deque;
    private int front;
    private int rear;
    private int size;
    private int count;

    // Constructor to initialize the deque with a max size of k
    public MyCircularDeque(int k)
    {
        size = k;
        deque = new int[k];
        front = 0;
        rear = k - 1;
        count = 0;
    }

    // Inserts an item at the front of the deque.
    public bool InsertFront(int value)
    {
        if (IsFull()) return false; // Check if the deque is full
        front = (front - 1 + size) % size; // Move the front pointer backward
        deque[front] = value; // Insert the value at the new front
        count++; // Increase the element count
        return true;
    }

    // Inserts an item at the rear of the deque.
    public bool InsertLast(int value)
    {
        if (IsFull()) return false; // Check if the deque is full
        rear = (rear + 1) % size; // Move the rear pointer forward
        deque[rear] = value; // Insert the value at the new rear
        count++; // Increase the element count
        return true;
    }

    // Deletes an item from the front of the deque.
    public bool DeleteFront()
    {
        if (IsEmpty()) return false; // Check if the deque is empty
        front = (front + 1) % size; // Move the front pointer forward
        count--; // Decrease the element count
        return true;
    }

    // Deletes an item from the rear of the deque.
    public bool DeleteLast()
    {
        if (IsEmpty()) return false; // Check if the deque is empty
        rear = (rear - 1 + size) % size; // Move the rear pointer backward
        count--; // Decrease the element count
        return true;
    }

    // Get the front item from the deque.
    public int GetFront()
    {
        if (IsEmpty()) return -1; // Check if the deque is empty
        return deque[front]; // Return the value at the front
    }

    // Get the rear item from the deque.
    public int GetRear()
    {
        if (IsEmpty()) return -1; // Check if the deque is empty
        return deque[rear]; // Return the value at the rear
    }

    // Checks whether the deque is empty or not.
    public bool IsEmpty()
    {
        return count == 0; // If count is 0, deque is empty
    }

    // Checks whether the deque is full or not.
    public bool IsFull()
    {
        return count == size; // If count equals the size, deque is full
    }
}

public class Program
{
    public static void Main()
    {
        // Input simulation
        string[] operations = {
            "MyCircularDeque", "insertLast", "insertLast", "insertFront",
            "insertFront", "getRear", "isFull", "deleteLast", "insertFront", "getFront"
        };
        int[][] parameters = {
            new int[] { 3 }, new int[] { 1 }, new int[] { 2 },
            new int[] { 3 }, new int[] { 4 }, new int[0], new int[0],
            new int[0], new int[] { 4 }, new int[0]
        };

        // Initialize variables
        MyCircularDeque deque = null;
        List<object> output = new List<object>();

        // Process each operation
        for (int i = 0; i < operations.Length; i++)
        {
            switch (operations[i])
            {
                case "MyCircularDeque":
                    deque = new MyCircularDeque(parameters[i][0]);
                    output.Add(null);
                    break;
                case "insertLast":
                    output.Add(deque.InsertLast(parameters[i][0]));
                    break;
                case "insertFront":
                    output.Add(deque.InsertFront(parameters[i][0]));
                    break;
                case "getRear":
                    output.Add(deque.GetRear());
                    break;
                case "getFront":
                    output.Add(deque.GetFront());
                    break;
                case "isFull":
                    output.Add(deque.IsFull());
                    break;
                case "isEmpty":
                    output.Add(deque.IsEmpty());
                    break;
                case "deleteFront":
                    output.Add(deque.DeleteFront());
                    break;
                case "deleteLast":
                    output.Add(deque.DeleteLast());
                    break;
                default:
                    throw new InvalidOperationException("Unknown operation: " + operations[i]);
            }
        }

        // Print output
        Console.WriteLine("Output: " + string.Join(", ", output));
    }
}