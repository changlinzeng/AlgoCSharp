public class IsGraphBipartite_785 {
    public bool IsBipartite(int[][] graph) {
      var len = graph.Length;
      var color = new int[len];
      for (var i = 0; i < len; i++)
      {
        if (color[i] == 0 && !Bfs(graph, i, color))
        {
          return false;
        }
      }
      return true;
    }

    private bool Bfs(in int[][] graph, int node, in int[] color)
    {
      var q = new Queue<int>();
      q.Enqueue(node);
      color[node] = 1;
      while (q.Count > 0)
      {
        var size = q.Count;
        foreach (var _ in Enumerable.Range(0, size))
        {
          var n = q.Dequeue();
          foreach (var child in graph[n])
          {
            if (color[child] == color[n])
            {
              return false;
            }
            else if (color[child] == 0)
            {
              color[child] = -1 * color[n];
              q.Enqueue(child);
            }
          }
        }
      }
      return true;
    }
}