public class DeleteNodeInABST_450 {
    public static TreeNode DeleteNode(TreeNode root, int key) {
      TreeNode? target = root, parent = new();
      parent.Left = root;
      while (target != null && target.Val != key)
      {
        if (target.Val < key)
        {
          parent = target;
          target = target.Right;
        }
        else
        {
          parent = target;
          target = target.Left;
        }
      }
      // target node not found
      if (target == null)
      {
        return root;
      }

      TreeNode? left = target.Left, right = target.Right;
      // removed children of target
      target.Left = null;
      target.Right = null;

      if (right == null)
      {
        // target does not have right child
        // replace target with its left child
        if (parent.Left == target)
        {
          parent.Left = left;
        }
        if (parent.Right == target)
        {
          parent.Right = left;
        }
        // set left child as root if we remove root
        if (target == root)
        {
          root = left;
        }
      }
      else
      {
        // replace target with right child
        if (parent.Left == target)
        {
          parent.Left = right;
        }
        if (parent.Right == target)
        {
          parent.Right = right;
        }
        if (target == root)
        {
          root = right;
        }
        // append left to the left most child of right subtree
        var par = right;
        while (par.Left != null)
        {
          par = par.Left;
        }
        par.Left = left;
      }

      return root;
    }
}