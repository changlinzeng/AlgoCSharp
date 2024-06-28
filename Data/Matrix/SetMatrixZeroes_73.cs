public class SetMatrixZeroes_73 {
    public static void SetZeroes(int[][] matrix) {
      int rows = matrix.Length, cols = matrix[0].Length;
      var zero = new List<int[]>();
      for (var i = 0; i < rows; i++)
      {
        for (var j = 0; j < cols; j++)
        {
          if (matrix[i][j] == 0)
          {
            zero.Add([i, j]);
          }
        }
      }

      foreach (int[] z in zero)
      {
        for (var i = 0; i < rows; i++)
        {
          matrix[i][z[1]] = 0;
        }
        for (var j = 0; j < cols; j++)
        {
          matrix[z[0]][j] = 0;
        }
      }
    }
}