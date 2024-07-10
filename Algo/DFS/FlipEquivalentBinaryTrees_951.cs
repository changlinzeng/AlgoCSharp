public class FlipEquivalentBinaryTrees_951 {
    public bool FlipEquiv(TreeNode root1, TreeNode root2) {
        return TryFlip(root1, root2);
    }

    private bool TryFlip(TreeNode? node1, TreeNode? node2)
    {
      if (node1 == null && node2 == null)
      {
        return true;
      }
      if (node1?.Val != node2?.Val) {
        return false;
      }
      int? left1 = node1?.Left?.Val;
      int? right1 = node1?.Right?.Val;
      int? left2 = node2?.Left?.Val;
      int? right2 = node2?.Right?.Val;
      if (left1 == left2 && right1 == right2)
      {
        return TryFlip(node1?.Left, node2?.Left) && TryFlip(node1?.Right, node2?.Right);
      }
      if (left1 == right2 && right1 == left2)
      {
        return TryFlip(node1?.Left, node2?.Right) && TryFlip(node1?.Right, node2?.Left);
      }
      return false;
    }
}