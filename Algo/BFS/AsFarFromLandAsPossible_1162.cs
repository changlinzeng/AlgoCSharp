public class AsFarFromLandAsPossible_1162 {
    /// <summary>
    /// this is similar to RottingOranges_994
    /// expand from 1 to the outside
    /// </summary>
    public static int MaxDistance(int[][] grid) {
      int rows = grid.Length, cols = grid[0].Length;
      var directions = new List<Tuple<int, int>>
      {
          Tuple.Create(-1, 0),
          Tuple.Create(1, 0),
          Tuple.Create(0, 1),
          Tuple.Create(0, -1)
      };
      var q = new Queue<Tuple<int, int, int>>();  // tuple of {row, col, dist}
      for (var i = 0; i < grid.Length; i++)
      {
        for (var j = 0; j < grid[0].Length; j++)
        {
          if (grid[i][j] == 1)
          {
            q.Enqueue(Tuple.Create(i, j, 0));
          }
        }
      }

      var visited = new bool[rows, cols];
      var maxDist = -1;
      while (q.Count > 0)
      {
        var (r, l, dist) = q.Dequeue();
        if (visited[r, l])
        {
          continue;
        }
        visited[r, l] = true;
        if (grid[r][l] == 0)
        {
          maxDist = Math.Max(maxDist, dist);
        }
        for (var i = 0; i < directions.Count; i++)
        {
          int nextRow = r + directions[i].Item1, nextCol = l + directions[i].Item2;
          if (nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols)
          {
            if (grid[nextRow][nextCol] == 0)
            {
              q.Enqueue(Tuple.Create(nextRow, nextCol, dist + 1));
            }
          }
        }
      }

      return maxDist;
    }

}