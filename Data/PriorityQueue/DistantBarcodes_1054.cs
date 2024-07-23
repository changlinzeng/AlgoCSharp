public class DistantBarcodes_1054 {
    public int[] RearrangeBarcodes(int[] barcodes) {
        var count = new Dictionary<int, int>();
        var pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        foreach (var code in barcodes)
        {
          count.TryAdd(code, 0);
          count[code]++;
        }

        foreach (var k in count.Keys)
        {
          pq.Enqueue(k, count[k]);
        }

        IList<int> rearranged = [];
        while (pq.Count > 0)
        {
          var first = pq.Dequeue();
          var second = -1;
          rearranged.Add(first);
          count[first]--;
          if (pq.Count > 0)
          {
            second = pq.Dequeue();
            rearranged.Add(second);
            count[second]--;
          }
          if (count[first] > 0)
          {
            pq.Enqueue(first, count[first]);
          }
          if (second != -1 && count[second] > 0)
          {
            pq.Enqueue(second, count[second]);
          }
        }
        return [.. rearranged];
    }
}