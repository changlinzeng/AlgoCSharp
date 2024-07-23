public class NumberOfIslands_200 {
    public int NumIslands(char[][] grid) {
        var num = 0;
        for (var i = 0; i < grid.Length; i++)
        {
          for (var j = 0; j < grid[0].Length; j++)
          {
            if (grid[i][j] == '1')
            {
              num += Dfs(grid, i, j);
            }
          }
        }
        return num;
    }

    private int Dfs(in char[][] grid, int row, int col)
    {
      int[][] directions = [[0, 1], [0, -1], [1, 0], [-1, 0]];
      if (grid[row][col] == '0')
      {
        return 0;
      }
      grid[row][col] = '0';
      foreach (var direction in directions)
      {
        int nextRow = row + direction[0], nextCol = col + direction[1];
        if (nextRow >= 0 && nextRow < grid.Length && nextCol >= 0 && nextCol < grid[0].Length
              && grid[nextRow][nextCol] == '1')
        {
          Dfs(grid, nextRow, nextCol);
        }
      }
      return 1;
    }
}