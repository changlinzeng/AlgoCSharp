class Tree
{
  public static TreeNode? FromPreorderAndInorder(int[] preorder, int[] inorder)
  {
    // Parameters:
    //   parentIndex: index of parent node in preorder
    //   start: start in inorder
    //   end: end in inorder
    static TreeNode? Dfs(int[] preorder, int[] inorder, Dictionary<int, int> inorderIndex, int parentIndex, int start, int end)
    {
      if (start > end) return null;
      var parentVal = preorder[parentIndex];
      var parent = new TreeNode(parentVal);
      var rightParent = parentIndex + inorderIndex[parentVal] - start + 1;
      parent.Left = Dfs(preorder, inorder, inorderIndex, parentIndex + 1, start, inorderIndex[parentVal] - 1);
      parent.Right = Dfs(preorder, inorder, inorderIndex, rightParent, inorderIndex[parentVal] + 1, end);
      return parent;
    }

    var inorderIndex = new Dictionary<int, int>();
    for (var i = 0; i < inorder.Length; i++) {
      inorderIndex[inorder[i]] = i;
    }
    return Dfs(preorder, inorder, inorderIndex, 0, 0, inorder.Length - 1);
  }

  // Deserialize from level order traversal
  public static TreeNode? DeserializeFromLevelOrder(string data)
  {
    var nodes = data.Split(",");
    if (nodes.Length == 0 || nodes[0] == "null") return null;
    var q = new Queue<TreeNode>();
    var root = new TreeNode(int.Parse(nodes[0]));
    q.Enqueue(root);
    var index = 1;
    while (q.Count > 0 && index < nodes.Length)
    {
      var n = q.Dequeue();
      if (nodes[index] != "null")
      {
        var left = new TreeNode(int.Parse(nodes[index]));
        n.Left = left;
        q.Enqueue(left);
      }
      index++;
      if (index < nodes.Length) {
        if (nodes[index] != "null")
        {
          var right = new TreeNode(int.Parse(nodes[index]));
          n.Right = right;
          q.Enqueue(right);
        }
        index++;
      }
    }
    return root;
  }

  public static string SerializeInLevelOrder(TreeNode? root)
  {
    if (root == null) return "";
    var data = new List<string>();
    var q = new Queue<TreeNode?>();
    q.Enqueue(root);
    while (q.Count > 0)
    {
      var node = q.Dequeue();
      if (node == null)
      {
        data.Add("null");
        continue;
      }
      data.Add(node.Val.ToString());
      q.Enqueue(node.Left);
      q.Enqueue(node.Right);
    }

    var i = data.Count - 1;
    while (i >= 0 && data[i] == "null")
    {
      i--; 
    }
    return string.Join(",", data.GetRange(0, i + 1));
  }

  public static string Preorder(TreeNode? root)
  {
    if (root == null) return "";
    string data = root.Val.ToString();
    var left = Preorder(root.Left);
    var right = Preorder(root.Right);
    if (!string.IsNullOrEmpty(left)) {
      data = data + "," + left;
    }
    if (!string.IsNullOrEmpty(right)) {
      data = data + "," + right;
    }
    return data;
  }

  public static string Inorder(TreeNode? root)
  {
    if (root == null) return "";
    string data = root.Val.ToString();
    var left = Inorder(root.Left);
    var right = Inorder(root.Right);
    if (!string.IsNullOrEmpty(left))
    {
      data = left + "," + data;
    }
    if (!string.IsNullOrEmpty(right))
    {
      data = data + "," + right;
    }
    return data;
  }
}

public class TreeNode(int val)
{
  public int Val { get; } = val;
  public TreeNode? Left { get; set; }
  public TreeNode? Right { get; set; }
}
