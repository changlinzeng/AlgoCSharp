public class UniquePaths_II_63 {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
      int rows = obstacleGrid.Length, cols = obstacleGrid[0].Length;
      var dp = new int[rows, cols];
      
      // init first row
      for (var i = 0; i < cols; i++)
      {
        if (obstacleGrid[0][i] == 1)
        {
          break;
        }
        dp[0, i] = 1;
      }
      // init first column
      for (var i = 0; i < rows; i++)
      {
        if (obstacleGrid[i][0] == 1)
        {
          break;
        }
        dp[i, 0] = 1;
      }

      for (var i = 1; i < rows; i++)
      {
        for (var j = 1; j < cols; j++)
        {
          if (obstacleGrid[i][j] == 0)
          {
            dp[i, j] += dp[i - 1, j] + dp[i, j -1];
          }
        }
      }

      return dp[rows - 1, cols - 1];
    }
}