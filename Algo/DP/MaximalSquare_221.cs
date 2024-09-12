public class MaximalSquare_221 {
    public static int MaximalSquare(char[][] matrix) {
        int maxLen = 0, rows = matrix.Length, cols = matrix[0].Length;
        var dp = new int[rows, cols];
        for (var i = 0; i < rows; i++)
        {
          for (var j = 0; j < cols; j++)
          {
            if (matrix[i][j] == '1')
            {
              dp[i, j] = 1;
              if (i > 0 && j > 0)
              {
                int m = 0, n = 0;
                while (m <= dp[i - 1, j - 1] && matrix[i - m][j] == '1')
                {
                  m++;
                }
                while (n <= dp[i - 1, j - 1] && matrix[i][j - n] == '1')
                {
                  n++;
                }
                dp[i, j] = Math.Min(m, n);
              }
              maxLen = Math.Max(maxLen, dp[i, j]);
            }
          }
        }
        return maxLen * maxLen;
    }
}