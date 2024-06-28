public class ValidateBinarySearchTree_98 {
    public static bool IsValidBST(TreeNode root) {
        return validate(root, long.MinValue, long.MaxValue);
    }

    private static bool validate(TreeNode node, long lowVal, long highVal)
    {
      if (node.Val <= lowVal || node.Val >= highVal)
      {
        return false;
      }
      if (node.Left != null && !validate(node.Left, lowVal, node.Val))
      {
        return false;
      }
      if (node.Right != null && !validate(node.Right, node.Val, highVal))
      {
        return false;
      }
      return true;
    }
}