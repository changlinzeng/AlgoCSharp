public class MaximumWidthOfBinaryTree_662 {
    private int maxWidth = 0;
    public int WidthOfBinaryTree(TreeNode root) {
        dfs(root, 0, 0, []);
        return maxWidth;
    }

    private void dfs(TreeNode? node, int level, int index, Dictionary<int, Tuple<int, int>> levelWidth)
    {
      if (node == null)
      {
        return;
      }
      levelWidth.TryAdd(level, Tuple.Create(int.MaxValue, int.MinValue));
      int low = Math.Min(levelWidth[level].Item1, index);
      int high = Math.Max(levelWidth[level].Item2, index);
      maxWidth = Math.Max(maxWidth, high - low + 1);
      levelWidth[level] = Tuple.Create(low, high);
      dfs(node.Left, level + 1, index * 2 + 1, levelWidth);
      dfs(node.Right, level + 1, index * 2 + 2, levelWidth);
    }
}