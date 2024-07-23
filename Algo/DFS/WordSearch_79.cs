public class WordSearch_79 {
    public bool Exist(char[][] board, string word) {
        int rows = board.Length, cols = board[0].Length;
        if (rows == 1 && cols == 1 && word.Length == 1)
        {
          return board[0][0] == word[0];
        }
        for (var i = 0; i < rows; i++)
        {
          for (var j = 0; j < cols; j++)
          {
            if (Dfs(board, word, 0, i, j, new bool[rows, cols]))
            {
              return true;
            }
          }
        }
        return false;
    }

    private bool Dfs(char[][] board, string word, int index, int row, int col, bool[,] visited)
    {
      if (index == word.Length)
      {
        return true;
      }
      if (visited[row, col] || word[index] != board[row][col])
      {
        return false;
      }
      int[][] directions = [[0, 1], [0, -1], [1, 0], [-1, 0]];
      visited[row, col] = true;
      foreach (var direction in directions)
      {
        int nextRow = row + direction[0], nextCol = col + direction[1];
        if (nextRow >= 0 && nextRow < board.Length && nextCol >= 0 && nextCol < board[0].Length)
        {
          if (Dfs(board, word, index + 1, nextRow, nextCol, visited))
          {
            return true;
          }
        }
      }
      // revert so that this cell can be used in other search
      visited[row, col] = false;
      return false;
    }
}