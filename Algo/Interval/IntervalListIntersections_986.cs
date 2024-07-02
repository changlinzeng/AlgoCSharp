public class IntervalListIntersections_986 {
    public static int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
        int i = 0, j = 0;
        var intersections = new List<int[]>();
        while (i < firstList.Length && j < secondList.Length)
        {
          int start1 = firstList[i][0], end1 = firstList[i][1];
          int start2 = secondList[j][0], end2 = secondList[j][1];
          var start = Math.Max(start1, start2);
          var end = Math.Min(end1, end2);
          if (start <= end)
          {
            intersections.Add([start, end]);
          }
          if (end1 <= end2)
          {
            i++;
          }
          else
          {
            j++;
          }
        }

        return [.. intersections];
    }
}