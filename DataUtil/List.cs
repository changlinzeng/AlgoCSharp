public class ListNode(int val)
{
  public int Val {get; set;} = val;
  public ListNode? Next {get; set;}
  public ListNode? Prev {get; set;}
}

public class List
{
  public static ListNode? FromArray(int[] arr)
  {
    var head = new ListNode(0);
    var tail = head;
    for (var i = 0; i < arr.Length; i++)
    {
      tail.Next = new ListNode(arr[i]);
      tail = tail.Next;
    }
    return head.Next;
  }
}