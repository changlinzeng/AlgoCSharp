public class NumberOfClosedIslands_1254 {
    public static int ClosedIsland(int[][] grid) {
        var visited = new bool[grid.Length, grid[0].Length];
        var count = 0;
        for (var i = 0; i < grid.Length; i++)
        {
          for (var j = 0; j < grid[0].Length; j++)
          {
            if (!visited[i, j] && grid[i][j] == 0 && Dfs(grid, i, j, visited))
            {
              count++;
            }
          }
        }
        return count;
    }

    private static bool Dfs(in int[][] grid, in int row, in int col, in bool[,] visited)
    {
      int rows = grid.Length, cols = grid[0].Length;
      var border = false;
      // we can not return from here as even we reach border, we need to visit other directions
      // and mark as visited
      if ((row == 0 || row == rows - 1 || col == 0 || col == cols - 1) && grid[row][col] == 0)
      {
        border = true;
      }
      if (visited[row, col] || grid[row][col] == 1)
      {
        return true;
      }
      visited[row, col] = true;
      
      var directions = new int[4][]{[0, 1], [0, -1], [1, 0], [-1, 0]};
      var result = true;
      foreach (var direction in directions)
      {
        int nextRow = row + direction[0], nextCol = col + direction[1];
        if (nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < cols)
        {
          if (!Dfs(grid, nextRow, nextCol, visited))
          {
            // should not return directly from here as we need to visited all the cells
            result = false;
          }
        }
      }
      return !border && result;
    }
}