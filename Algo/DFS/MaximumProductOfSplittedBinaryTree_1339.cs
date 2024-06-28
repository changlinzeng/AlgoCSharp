public class MaximumProductOfSplittedBinaryTree_1339 {
    public int MaxProduct(TreeNode root) {
        long mod = 1_000_000_007;
        long maxProduct = 0;
        var subTreeSum = new Dictionary<TreeNode, long>();
        Dfs(root, subTreeSum);

        long total = subTreeSum[root];
        foreach (var (node, sum) in subTreeSum)
        {
          maxProduct = Math.Max(maxProduct, subTreeSum[node] * (total - subTreeSum[node]));
        }
        return (int)(maxProduct % mod);
    }

    private long Dfs(TreeNode? node, Dictionary<TreeNode, long> subTreeSum)
    {
      if (node == null)
      {
        return 0;
      }
      long sum = node.Val + Dfs(node.Left, subTreeSum) + Dfs(node.Right, subTreeSum);
      subTreeSum.Add(node, sum);
      return sum;
    }
}