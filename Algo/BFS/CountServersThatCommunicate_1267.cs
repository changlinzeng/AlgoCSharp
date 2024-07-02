public class CountServersThatCommunicate_1267 {
    public static int CountServers(int[][] grid) {
        var total = 0;
        for (var i = 0; i < grid.Length; i++)
        {
          for (var j = 0; j < grid[0].Length; j++)
          {
            if (grid[i][j] == 1)
            {
              var count = Count(grid, i, j);
              if (count > 1)
              {
                total += count;
              }
            }
          }
        }
        return total;
    }

    private static int Count(int[][] grid, int row, int col)
    {
      var cnt = 0;
      var q = new Queue<Tuple<int, int>>();
      q.Enqueue(Tuple.Create(row, col));
      grid[row][col] = -1;
      while (q.Count > 0)
      {
        var (srow, scol) = q.Dequeue();
        cnt++;
        // add cells on the same column to the q
        for (var i = 0; i < grid.Length; i++)
        {
          if (grid[i][scol] == 1)
          {
            q.Enqueue(Tuple.Create(i, scol));
            grid[i][scol] = -1;
          }
        }
        // add cells on the same row to the q
        for (var i = 0; i < grid[0].Length; i++)
        {
          if (grid[srow][i] == 1)
          {
            q.Enqueue(Tuple.Create(srow, i));
            grid[srow][i] = -1;
          }
        }
      }
      return cnt;
    }
}