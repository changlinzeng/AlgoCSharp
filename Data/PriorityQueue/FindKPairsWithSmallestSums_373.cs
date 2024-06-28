class FindKPairsWithSmallestSums_373 {
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k) {
        var pairs = new List<IList<int>>();
        var pq = new PriorityQueue<int[], int>();

        foreach (var n1 in nums1)
        {
          foreach (var n2 in nums2)
          {
            if (pq.Count < k)
            {
              pq.Enqueue([n1, n2], -1 * (n1 + n2));
            }
            else
            {
              if (n1 + n2 < pq.Peek()[0] + pq.Peek()[1])
              {
                pq.Dequeue();
                pq.Enqueue([n1, n2], -1 * (n1 + n2));
              }
              else
              {
                break;
              }
            }
          }
        }

        while (pq.Count > 0)
        {
          pairs.Add(pq.Dequeue());
        }
        return pairs;
    }
}