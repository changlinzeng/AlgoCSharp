public class SurroundedRegions_130 {
    public static void Solve(char[][] board) {
      int rows = board.Length, cols = board[0].Length;
      var visited = new bool[rows, cols];
      foreach (var row in new int[2]{0, rows - 1})
      {
        for (var j = 0; j < cols; j++)
        {
          if (board[row][j] == 'O')
          {
            EdgeDfs(board, row, j, visited);
          }
        }
      }
      foreach (var col in new int[2]{0, cols - 1})
      {
        for (var i = 0; i < rows; i++)
        {
          if (board[i][col] == 'O')
          {
            EdgeDfs(board, i, col, visited);
          }
        }
      }

      // count the cells whose value is 'O' and not visited
      for (var i = 0; i < rows; i++)
      {
        for (var j = 0; j < cols; j++)
        {
          if (!visited[i, j] && board[i][j] == 'O')
          {
            board[i][j] = 'X';
          }
        }
      }
    }

    /// <summary>
    /// Start dfs from edges and find the cells that can be reached from edge.
    /// The rest cells are the ones that isolated from edges
    /// </summary>
    private static void EdgeDfs(in char[][] board, in int row, in int col, bool[,] visited)
    {
      int rows = board.Length, cols = board[0].Length;
      int[][] directions = [[0, 1], [0, -1], [1, 0], [-1, 0]];
      if (visited[row, col])
      {
        return;
      }
      if (board[row][col] == 'X')
      {
        return;
      }
      visited[row, col] = true;
      foreach (var direction in directions)
      {
        int nextRow = row + direction[0], nextCol = col + direction[1];
        if (nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols)
        {
          EdgeDfs(board, nextRow, nextCol, visited);
        }
      }
    }
}