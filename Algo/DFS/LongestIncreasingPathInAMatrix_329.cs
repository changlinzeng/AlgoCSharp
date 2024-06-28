public class  LongestIncreasingPathInAMatrix_329 {
    public static int LongestIncreasingPath(int[][] matrix) {
      int rows = matrix.Length, cols = matrix[0].Length;
      var maxLen = 0;
      var memo = new int[rows, cols];
      var visited = new bool[rows, cols];
      for (var i = 0; i < matrix.Length; i++)
      {
        for (var j = 0; j < matrix[0].Length; j++)
        {
          maxLen = Math.Max(maxLen, Dfs(matrix, i, j, memo, visited));
        }
      }
      return maxLen;
    }

    private static int Dfs(in int[][] matrix, int row, int col, int[,] memo, bool[,] visited)
    {
      int rows = matrix.Length, cols = matrix[0].Length;
      int[][] directions = [[0, 1], [0, -1], [1, 0], [-1, 0]];
      if (visited[row, col])
      {
        return memo[row, col];
      }
      if (memo[row, col] != 0)
      {
        visited[row, col] = true;
        return matrix[row][col];
      }
      var maxLen = 0;
      visited[row, col] = true;
      foreach (var dir in directions)
      {
        int nextRow = row + dir[0], nextCol = col+ dir[1];
        if (nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols
            && matrix[row][col] < matrix[nextRow][nextCol])
        {
          maxLen = Math.Max(maxLen, Dfs(matrix, nextRow, nextCol, memo, visited));
        }
      }
      maxLen++;
      memo[row, col] = maxLen;
      return maxLen;
    }
}