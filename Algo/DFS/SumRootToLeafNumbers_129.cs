public class SumRootToLeafNumbers_129 {
    public int SumNumbers(TreeNode root) {
        return Dfs(root, 0);
    }

    private int Dfs(TreeNode node, int sum)
    {
      var currSum = sum * 10 + node.Val;
      if (node.Left == null && node.Right == null)
      {
        return currSum;
      }

      var newSum = 0;
      if (node.Left != null)
      {
        newSum += Dfs(node.Left, currSum);
      }
      if (node.Right != null)
      {
        newSum += Dfs(node.Right, currSum);
      }
      return newSum;
    }
}