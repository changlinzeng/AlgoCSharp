public class GameOfLife_289 {
    public void GameOfLife(int[][] board) {
      int rows = board.Length, cols = board[0].Length;
      var snapshot = new int[rows][];
      for (var i = 0; i < rows; i++)
      {
        var r = new int[cols];
        Array.Copy(board[i], r, cols);
        snapshot[i] = r;
      }

      var neighbour = new int[8][]{[0, 1], [0, -1], [1, 0], [-1 ,0], [-1 ,-1], [-1 ,1], [1, -1, ], [1, 1]};
      for (var i = 0; i < rows; i++)
      {
        for (var j = 0; j < cols; j++)
        {
          // check neighbourhood
          int countLive = 0, countDead = 0;
          foreach (var n in neighbour)
          {
            int nrow = i + n[0], ncol = j + n[1];
            if (nrow >= 0 && nrow < rows && ncol >= 0 && ncol < cols)
            {
              switch (snapshot[nrow][ncol])
              {
                case 1: countLive++; break;
                case 0: countDead++; break;
              }
            }
          }
          if (snapshot[i][j] == 0 && countLive == 3)
          {
            board[i][j] = 1;
          }
          if (snapshot[i][j] == 1 && (countLive < 2 || countLive > 3))
          {
            board[i][j] = 0;
          }
        }
      }
    }
}