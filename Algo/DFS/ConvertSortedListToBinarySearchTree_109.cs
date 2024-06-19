public class ConvertSortedListToBinarySearchTree_109 {
    public static TreeNode SortedListToBST(ListNode head) {
      var nodes = new List<int>();
      var cur = head;
      while (cur != null)
      {
        nodes.Add(cur.Val);
        cur = cur.Next;
      }
      return BuildTree(nodes, 0, nodes.Count - 1)!;
    }

    private static TreeNode? BuildTree(IList<int> nodes, int start, int end)
    {
      if (start > end)
      {
        return null;
      }
      var mid = start + (end - start) / 2;
      var parent = new TreeNode(nodes[mid])
      {
          Left = BuildTree(nodes, start, mid - 1),
          Right = BuildTree(nodes, mid + 1, end)
      };
      return parent;
    }
}