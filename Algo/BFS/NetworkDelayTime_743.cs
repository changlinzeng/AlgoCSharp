public class NetworkDelayTime_743 {
    /// <summary>
    /// Use Dijkstra algorithm to find the shortest path to each node and then
    /// find the max among all the shortest distance
    /// </summary>
    public static int NetworkDelayTime(int[][] times, int n, int k) {
        var adjMap = new Dictionary<int, IList<int[]>>();
        foreach (var t in times)
        {
          if (!adjMap.TryAdd(t[0], [[t[1], t[2]]]))
          {
            adjMap[t[0]].Add([t[1], t[2]]);
          }
        }

        var visited = new bool[n + 1];
        var pq = new PriorityQueue<int, int>();
        var delay = new int[n + 1];
        Array.Fill(delay, int.MaxValue);
        delay[0] = 0;
        delay[k] = 0;
        pq.Enqueue(k, 0);
        while (pq.Count > 0)
        {
          var node = pq.Dequeue();
          if (visited[node])
          {
            continue;
          }
          visited[node] = true;
          if (!adjMap.ContainsKey(node))
          {
            continue;
          }
          foreach (var child in adjMap[node])
          {
            var dist = delay[node] + child[1];
            delay[child[0]] = Math.Min(delay[child[0]], dist);
            pq.Enqueue(child[0], delay[child[0]]);
          }
        }

        var minDelay = 0;
        foreach (var t in delay)
        {
          if (t == int.MaxValue)
          {
            return -1;
          }
          minDelay = Math.Max(minDelay, t);
        }
        return minDelay;
    }
}