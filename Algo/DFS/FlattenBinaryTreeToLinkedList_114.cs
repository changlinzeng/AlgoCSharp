public class FlattenBinaryTreeToLinkedList_114 {
    public void Flatten(TreeNode root) {
        Dfs(root);
    }

    /// <summary>
    /// Flatten left subtree and right subtree and the link left subtree between node and right subtree
    /// </summary>
    /// <returns>the tail of the flattened list</returns>
    private TreeNode? Dfs(TreeNode? node)
    {
      if (node == null)
      {
        return null;
      }

      TreeNode? left = node.Left, right = node.Right;
      TreeNode? leftEnd = null, rightEnd = null;
      if (left != null)
      {
        leftEnd = Dfs(left);
      }
      if (right != null)
      {
        rightEnd = Dfs(right);
      }

      if (leftEnd != null)
      {
        node.Right = left;
        leftEnd.Right = right;
        node.Left = null;
      }

      if (rightEnd != null)
      {
        return rightEnd;
      }
      else if (leftEnd != null)
      {
        return leftEnd;
      }
      else
      {
        return node;
      }
    }
}