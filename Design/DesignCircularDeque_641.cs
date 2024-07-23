using System.Security.Claims;

public class MyCircularDeque {

    private readonly int[] queue;
    private int head;
    private int tail;

    public MyCircularDeque(int k) {
      queue = new int[k];        
      head = -1;
      tail = -1;
    }
    
    public bool InsertFront(int value) {
        if (IsFull())
        {
          return false;
        }
        if (IsEmpty())
        {
          queue[0] = value;
          head = 0;
          tail = 0;
          return true;
        }
        head = (head - 1 + queue.Length) % queue.Length;
        queue[head] = value;
        return true;
    }
    
    public bool InsertLast(int value) {
        if (IsFull())
        {
          return false;
        }
        if (IsEmpty())
        {
          queue[0] = value;
          head = 0;
          tail = 0;
          return true;
        }
        tail = (tail + 1) % queue.Length;
        queue[tail] = value;
        return true;
    }
    
    public bool DeleteFront() {
        if (IsEmpty())
        {
          return false;
        }
        if (head == tail)
        {
          head = -1;
          tail = -1;
          return true;
        }
        head = (head + 1) % queue.Length;
        return true;
    }
    
    public bool DeleteLast() {
        if (IsEmpty())
        {
          return false;
        }
        if (head == tail)
        {
          head = -1;
          tail = -1;
          return true;
        }
        tail = (tail - 1 + queue.Length) % queue.Length;
        return true;
    }
    
    public int GetFront() {
        return IsEmpty() ? -1 : queue[head];
    }
    
    public int GetRear() {
        return IsEmpty() ? -1 : queue[tail];
    }
    
    public bool IsEmpty() {
        return head == -1 && tail == -1;
    }
    
    public bool IsFull() {
        return head == (tail + 1) % queue.Length;
    }
}