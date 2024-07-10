using System.Data;

public class ValidTicTacToeState_794 {
    public static bool ValidTicTacToe(string[] board) {
        int countX = 0, countO = 0;
        foreach (var row in board)
        {
          foreach (var c in row)
          {
            switch (c)
            {
              case 'X': countX++; break;
              case 'O': countO++; break;
            }
          }
        }
        if (countX - countO > 1 || countX < countO)
        {
          return false;
        }

        if (Win(board, 'X') && Win(board, 'O'))
        {
          return false;
        }
        if (Win(board, 'X') && countX - countO != 1)
        {
          return false;
        }
        if (Win(board, 'O') && countX != countO)
        {
          return false;
        }

        return true;
    }

    private static bool Win(in string[] board, char player)
    {
      var win = new string(player, board.Length);
      foreach (var row in board)
      {
        if (row == win)
        {
          return true;
        }
      }
      for (var i = 0; i < board[0].Length; i++)
      {
        var col = "";
        for (var j = 0; j < board.Length; j++)
        {
          col += board[j][i];
        }
        if (col == win)
        {
          return true;
        }
      }

      var cross = "";
      for (var i = 0; i < board.Length; i++)
      {
        cross += board[i][i];
      }
      if (cross == win)
      {
        return true;
      }

      cross = "";
      for (var i = 0; i < board.Length; i++)
      {
        cross += board[i][2 - i];
      }
      if (cross == win)
      {
        return true;
      }

      return false;
    }
}