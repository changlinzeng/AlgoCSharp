public class MaxAreaOfIsland_695 {

    public static int MaxAreaOfIsland(int[][] grid) {
        int rows = grid.Length, cols = grid[0].Length;
        int maxArea = 0;
        for (var i = 0; i < rows; i++)
        {
          for (var j = 0; j < cols; j++)
          {
            if (grid[i][j] == 1)
            {
              maxArea = Math.Max(maxArea, Dfs(grid, i, j));
            }
          }
        }
        
        return maxArea;

        int Dfs(int[][] grid, int row, int col)
        {
          if (grid[row][col] == 0)
          {
            return 0;
          }
          var area = 1;
          int[][] directions = [[0, 1], [0, -1], [1, 0], [-1, 0]];
          grid[row][col] = 0;
          foreach (var direction in directions)
          {
            int nextRow = row + direction[0], nextCol = col + direction[1];
            if (nextRow >= 0 && nextRow < grid.Length && nextCol >= 0 && nextCol < grid[0].Length)
            {
              area += Dfs(grid, nextRow, nextCol);
            }
          }
          return area;
        }
    }
}