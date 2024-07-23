public class MergeIntervals_56 {
    public int[][] Merge(int[][] intervals) {
        IList<int[]> merged = [];
        // sort intervals by start then by end
        Array.Sort(intervals, Comparer<int[]>.Create((a, b) =>
        {
          if (a[0] == b[0])
          {
            return a[1] - b[1];
          }
          return a[0] - b[0];
        }));
        var prev = intervals[0];
        for (var i = 0; i < intervals.Length; i++)
        {
          var current = intervals[i];
          if (current[0] <= prev[1])
          {
            // merge
            prev[1] = Math.Max(current[1], prev[1]);
          }
          else
          {
            merged.Add(prev);
            prev = current;
          }
        }
        if (merged.Count == 0 || merged.Count > 0 && prev[0] > merged.Last()[1])
        {
          merged.Add(prev);
        }
        return [.. merged];
    }
}