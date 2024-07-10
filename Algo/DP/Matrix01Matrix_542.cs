public class Matrix01Matrix_542 {
    public int[][] UpdateMatrix(int[][] mat) {
        int rows = mat.Length, cols = mat[0].Length;
        int[][] dist = new int[rows][];
        for (var i = 0; i < dist.Length; i++)
        {
          dist[i] = new int[cols];
          Array.Fill(dist[i], 1_000_000);
        }

        for (var i = 0; i < rows; i++)
        {
          for (var j = 0; j < cols; j++)
          {
            if (mat[i][j] == 0)
            {
              dist[i][j] = 0;
            }
            else
            {
              if (i > 0)
              {
                dist[i][j] = Math.Min(dist[i][j], dist[i - 1][j] + 1);
              }
              if (j > 0)
              {
                dist[i][j] = Math.Min(dist[i][j], dist[i][j - 1] + 1);
              }
            }
          }
        }

        for (var i = rows - 1; i >= 0; i--)
        {
          for (var j = cols - 1; j >= 0; j--)
          {
            if (mat[i][j] == 0)
            {
              dist[i][j] = 0;
            }
            else
            {
              if (i < rows - 1)
              {
                dist[i][j] = Math.Min(dist[i][j], dist[i + 1][j] + 1);
              }
              if (j < cols - 1)
              {
                dist[i][j] = Math.Min(dist[i][j], dist[i][j + 1] + 1);
              }
            }
          }
        }

        return dist;
    }
}