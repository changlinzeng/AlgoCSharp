public class LRUCache {

    private readonly Dictionary<int, Node> data;
    private readonly Node head;
    private Node tail;
    private readonly int capacity;

    public LRUCache(int capacity) {
      this.data = [];
      this.head = new Node(-1, -1);
      this.tail = this.head;
      this.capacity = capacity;
    }
    
    public int Get(int key) {
        if (!data.ContainsKey(key))
        {
          return -1;
        }
        var node = data[key];
        // move node to head
        if (node.Prev != head)
        {
          Remove(node);
          InsertHead(node);
        }
        return node.Val;
    }
    
    public void Put(int key, int value) {
        Node? node;
        if (data.ContainsKey(key))
        {
          node = data[key];
          node.Val = value;
          Remove(node);
        }
        else
        {
          if (data.Count == capacity)
          {
            // remove tail if size exceeds capacity
            data.Remove(tail.Key);
            Remove(tail);
          }
          node = new Node(key, value);
          data[key] = node;
        }
        InsertHead(node);
    }

    private void Remove(Node node)
    {
      Node prev = node.Prev, next = node.Next;
      if (node == tail)
      {
        tail = prev;
      }
      if (prev != null)
      {
        prev.Next = next;
      }
      if (next != null)
      {
        next.Prev = prev;
      }
      node.Prev = null;
      node.Next = null;
    }

    private void InsertHead(Node node)
    {
      Node? next = head.Next;
      if (next == null)
      {
        head.Next = node;
        node.Prev = head;
        tail = node;
        return;
      }
      head.Next = node;
      node.Next = next;
      node.Prev = head;
      next.Prev = node;
    }

    class Node(int Key, int Val)
    {
      public int Key {get; set;} = Key;
      public int Val {get; set;} = Val;
      public Node? Prev {get; set;}
      public Node? Next {get; set;}
    }
}