public class CheapestFlightsWithinKStops_787 {
    public static int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var adjMap = new Dictionary<int, IList<Tuple<int, int>>>();  // from -> [to, dist]
        foreach (var f in flights)
        {
          adjMap.TryAdd(f[0], []);
          adjMap[f[0]].Add(Tuple.Create(f[1], f[2]));
        }

        int[] dist = new int[n];
        Array.Fill(dist, int.MaxValue);
        // City number, stops and distance to the city. Priority is the distance from src to current city
        var pq = new PriorityQueue<Tuple<int, int, int>, int>();
        pq.Enqueue(Tuple.Create(src, 0, 0), 0);
        while (pq.Count > 0)
        {
          var (city, stops, currentDist) = pq.Dequeue();
          if (!adjMap.ContainsKey(city))
          {
            continue;
          }
          if (stops > k)
          {
            continue;
          }
          foreach (var (nextCity, nextDist) in adjMap[city])
          {
            if (currentDist + nextDist < dist[nextCity])
            {
              dist[nextCity] = Math.Min(dist[nextCity], currentDist + nextDist);
              pq.Enqueue(Tuple.Create(nextCity, stops + 1, dist[nextCity]), stops + 1);
            }
          }
        }

        return dist[dst] == int.MaxValue ? -1 : dist[dst];
    }
}