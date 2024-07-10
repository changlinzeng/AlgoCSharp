public class NonOverlappingIntervals_435 {
    public int EraseOverlapIntervals(int[][] intervals) {
      // sort by end
      Array.Sort(intervals, Comparer<int[]>.Create((a, b) => a[1] - b[1]));

      var erase = 0;
      int[] prev = intervals[0];
      for (var i = 1; i < intervals.Length; i++)
      {
        if (intervals[i][0] >= prev[1])
        {
          // current interval does not overlap with prev
          prev = intervals[i];
        }
        else
        {
          erase++;
        }
      }
      return erase;
    }
}