public class MyCircularQueue {

    private readonly int capacity;
    private int[] data;
    private int size;
    private int head;
    private int tail;

    public MyCircularQueue(int k) {
        capacity = k;
        size = 0;
        data = new int[k];
        head = -1;
        tail = -1;
    }
    
    public bool EnQueue(int value) {
        if (size == capacity)
        {
          return false;
        }
        if (head == -1)
        {
          data[0] = value;
          head = 0;
          tail = 0;
        }
        else
        {
          tail = (tail + 1) % capacity;
          data[tail] = value;
        }
        size++;
        return true;
    }
    
    public bool DeQueue() {
        if (size == 0)
        {
          return false;
        }
        head = (head + 1) % capacity;
        size--;
        return true;
    }
    
    public int Front() {
        return size == 0 ? -1 : data[head];
    }
    
    public int Rear() {
        return size == 0 ? -1 : data[tail];
    }
    
    public bool IsEmpty() {
        return size == 0;
    }
    
    public bool IsFull() {
        return size == capacity;
    }
}