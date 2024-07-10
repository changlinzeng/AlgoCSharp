public class HouseRobber_III_337 {
    public int Rob(TreeNode root) {
        return dfs(root, []);
    }

    private int dfs(TreeNode? node, Dictionary<TreeNode, int> memo)
    {
      if (node == null)
      {
        return 0;
      }

      if (memo.ContainsKey(node))
      {
        return memo[node];
      }

      // if we rob root, we need to skip the left child and right child of root
      var sum1 = node.Val;
      sum1 += dfs(node.Left?.Left, memo) + dfs(node.Left?.Right, memo);
      sum1 += dfs(node.Right?.Left, memo) + dfs(node.Right?.Right, memo);

      // do not rob root
      var sum2 = dfs(node.Left, memo) + dfs(node.Right, memo);

      memo[node] = Math.Max(sum1, sum2);
      return memo[node];
    }
}