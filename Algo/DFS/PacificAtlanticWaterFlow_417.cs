public class PacificAtlanticWaterFlow_417 {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
      (int rows, int cols) = (heights.Length, heights[0].Length);
      ISet<string> pacificCandidates = new HashSet<string>();
      ISet<string> atlanticCandidates = new HashSet<string>();
      for (var i = 0; i < rows; i++)
      {
        for (var j = 0; j < cols; j++)
        {
          Dfs(heights, i, j, pacificCandidates, new bool[rows, cols], true);
        }
      }
      for (var i = rows - 1; i >= 0; i--)
      {
        for (var j = cols - 1; j >= 0; j--)
        {
          Dfs(heights, i, j, atlanticCandidates, new bool[rows, cols], false);
        }
      }
      var result = pacificCandidates.Intersect(atlanticCandidates);
      return result.Select(c => new List<int>(){int.Parse(c.Split("-")[0]), int.Parse(c.Split("-")[1])}).ToList<IList<int>>();
    }

    private bool Dfs(int[][] heights, int row, int col, ISet<string> candiates, bool[,] visited, bool pacific)
    {
      (int rows, int cols) = (heights.Length, heights[0].Length);
      (int rowDest, int colDest) = pacific ? (0, 0) : (rows - 1, cols - 1);
      var cell = $"{row}-{col}";
      int[][] directions = [[-1, 0], [0, 1], [1, 0], [0, -1]];
      if (visited[row, col])
      {
        return candiates.Contains(cell);
      }
      visited[row, col] = true;
      if (row == rowDest || col == colDest)
      {
        candiates.Add(cell);
        return true;
      }
      if (candiates.Contains(cell))
      {
        return true;
      }
      foreach (var direction in directions)
      {
        (int nextRow, int nextCol) = (row + direction[0], col + direction[1]);
        if (nextRow >= 0 && nextRow <= rows - 1 && nextCol >= 0 && nextCol <= cols - 1 && heights[row][col] >= heights[nextRow][nextCol])
        {
          if (Dfs(heights, nextRow, nextCol, candiates, visited, pacific))
          {
            candiates.Add(cell);
            return true;
          }
        }
      }
      return false;
    }
}