public class PathSumII_113 {
    public static IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        var paths = new List<IList<int>>();
        Dfs(root, targetSum, [], paths);
        return paths;
    }

    private static void Dfs(TreeNode? node, int target, IList<int> path, IList<IList<int>> paths)
    {
      if (node == null)
      {
        return;
      }
      if (target == node.Val && node.Left == null && node.Right == null)
      {
        path.Add(node.Val);
        paths.Add([.. path]);
        return;
      }
      path.Add(node.Val);
      Dfs(node.Left, target - node.Val, [.. path], paths);
      Dfs(node.Right, target - node.Val, [.. path], paths);
    }
}