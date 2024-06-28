using System.Xml;

public class MinimumHeightTrees_310 {
    /// <summary>
    /// The root nodes with minimum height are the nodes that in the middle of the longest path
    /// So we remove the nodes from two ends (nodes with degree 1) and the nodes that are left
    /// are the expected result
    /// </summary>
    public static IList<int> FindMinHeightTrees(int n, int[][] edges) {
        if (n == 1)
        {
          return [0];
        }
        var adjMap = new Dictionary<int, IList<int>>();
        var degree = new int[n];
        foreach (var edge in edges)
        {
          adjMap.TryAdd(edge[0], []);
          adjMap[edge[0]].Add(edge[1]);
          adjMap.TryAdd(edge[1], []);
          adjMap[edge[1]].Add(edge[0]);
          degree[edge[0]]++;
          degree[edge[1]]++;
        }

        var q = new Queue<int>();
        for (var i = 0; i < n; i++)
        {
          if (degree[i] == 1)
          {
            q.Enqueue(i);
          }
        }

        var roots = new List<int>();
        while (q.Count > 0)
        {
          roots.Clear();
          int size = q.Count;
          foreach (var _ in Enumerable.Range(0, size))
          {
            var node = q.Dequeue();
            roots.Add(node);
            foreach (var child in adjMap[node])
            {
              degree[child]--;
              if (degree[child] == 1)
              {
                q.Enqueue(child);
              }
            }
          }
        }

        return roots;
    }
}