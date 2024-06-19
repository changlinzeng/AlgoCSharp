public class KthSmallestElementInABST_230 {
    public int KthSmallest(TreeNode root, int k) {
        IList<int> vals = [];
        Inorder(root, vals);
        return vals[k - 1];

        void Inorder(TreeNode? node, IList<int> vals)
        {
          if (node == null)
          {
            return;
          }
          if (vals.Count >= k)
          {
            return;
          }
          Inorder(node.Left, vals);
          vals.Add(node.Val);
          Inorder(node.Right, vals);
        }
    }

}