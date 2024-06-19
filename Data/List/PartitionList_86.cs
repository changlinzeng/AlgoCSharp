public class PartitionList_86 {
    public static ListNode Partition(ListNode head, int x) {
        var small = new ListNode(0);
        var smallTail = small;
        var large = new ListNode(0);
        var largeTail = large;
        var cur = head;
        while (cur != null)
        {
          if (cur.Val < x)
          {
            smallTail.Next = cur;
            smallTail = cur;
            cur = cur.Next;
            smallTail.Next = null;
          }
          else
          {
            largeTail.Next = cur;
            largeTail = cur;
            cur = cur.Next;
            largeTail.Next = null;
          }
        }

        smallTail.Next = large.Next;
        return small.Next!;
    }
}