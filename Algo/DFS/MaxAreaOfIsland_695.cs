public class MaxAreaOfIsland_695 {

    public static int MaxAreaOfIsland(int[][] grid) {
        int rows = grid.Length, cols = grid[0].Length;
        var visited = new Boolean[rows, cols];
        int maxArea = 0, area = 0;
        for (var i = 0; i < grid.Length; i++)
        {
          for (var j = 0; j < grid[0].Length; j++)
          {
            if (grid[i][j] == 1 && !visited[i, j])
            {
              area = 0;
              Dfs(grid, i, j, visited);
              maxArea = Math.Max(maxArea, area);
            }
          }
        }
        
        return maxArea;

        void Dfs(int[][] grid, int row, int col, Boolean[,] visited)
        {
          if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length)
          {
            return;
          }
          if (visited[row, col] || grid[row][col] != 1)
          {
            return;
          }
          visited[row, col] = true;
          area++;
          Dfs(grid, row - 1, col, visited);
          Dfs(grid, row + 1, col, visited);
          Dfs(grid, row, col - 1, visited);
          Dfs(grid, row, col + 1, visited);
        }
    }
}