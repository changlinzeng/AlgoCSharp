public class TaskScheduler_621 {
    public static int LeastInterval(char[] tasks, int n) {
        var count = new int[26];
        foreach (var t in tasks)
        {
          count[t - 'A']++;
        }

        // sort tasks by count descending
        var pq = new PriorityQueue<char, int>(Comparer<int>.Create((a, b) => b - a));
        for (var i = 0; i < count.Length; i++)
        {
          if (count[i] > 0)
          {
            pq.Enqueue((char)('A' + i), count[i]);
          }
        }

        var intervals = 0;
        while (pq.Count > 0)
        {
          var size = Math.Min(n + 1, pq.Count);
          List<char> list = [];
          for (var i = 0; i < size; i++)
          {
            var task = pq.Dequeue();
            count[task - 'A']--;
            if (count[task - 'A'] > 0)
            {
              list.Add(task);
            }
          }
          foreach (var t in list)
          {
            pq.Enqueue(t, count[t - 'A']);
          }
          if (pq.Count == 0)
          {
            // add the rest of tasks
            intervals += size;
          }
          else
          {
            intervals += n + 1;
          }
        }
        return intervals;
    }
}