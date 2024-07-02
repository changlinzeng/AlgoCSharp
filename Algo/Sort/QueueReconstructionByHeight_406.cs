public class QueueReconstructionByHeight_406 {
    public int[][] ReconstructQueue(int[][] people) {
      Array.Sort(people, Comparer<int[]>.Create((a, b) =>
      {
        // sort by height descending and then by the number of higher people in front
        if (a[0] == b[0])
        {
          return a[1] - b[1];
        }
        return b[0] - a[0];
      })); 

      var result = new List<int[]>();
      foreach (var p in people)
      {
        // insert into position p[1] so that there are p[1] people before that are not less than p[0]
        result.Insert(p[1], p);
      }
      return [.. result];
    }
}