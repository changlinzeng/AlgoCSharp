public class DeleteNodesAndReturnForest_1110 {
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        var forest = new List<TreeNode>();
        var toDelete = new HashSet<int>(to_delete);
        if (!toDelete.Contains(root.Val))
        {
          forest.Add(root);
        }
        dfs(root, toDelete, forest, null);
        return forest;
    }

    private void dfs(TreeNode? node, ISet<int> toDelete, IList<TreeNode> forest, TreeNode? parent)
    {
      if (node == null)
      {
        return;
      }
      if (!toDelete.Contains(node.Val))
      {
        dfs(node.Left, toDelete, forest, node);
        dfs(node.Right, toDelete, forest, node);
      }
      else
      {
        TreeNode? left = node.Left, right = node.Right;
        toDelete.Remove(node.Val);
        node.Left = null;
        node.Right = null;
        if (parent?.Left == node)
        {
          parent.Left = null;
        }
        if (parent?.Right == node)
        {
          parent.Right = null;
        }
        if (left != null && !toDelete.Contains(left.Val))
        {
          forest.Add(left);
        }
        if (right != null && !toDelete.Contains(right.Val))
        {
          forest.Add(right);
        }
        dfs(left, toDelete, forest, null);
        dfs(right, toDelete, forest, null);
      }
    }
}