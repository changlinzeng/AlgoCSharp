using System.Runtime.InteropServices.Marshalling;

public class CoinChange_II_518 {
    public static int Change(int amount, int[] coins) {
      var memo = new int[coins.Length + 1, amount + 1];
      for (var i = 0; i < memo.GetLength(0); i++)
      {
        for (var j = 0; j < memo.GetLength(1); j++)
        {
          memo[i, j] = -1;
        }
      }
      return Backtrack(coins, amount, 0, memo);
    }

    private static int Backtrack(in int[] coins, int amount, int start, int[,] memo)
    {
      if (start >= coins.Length)
      {
        return 0;
      }
      if (amount == 0)
      {
        return 1;
      }
      if (amount < 0)
      {
        return 0;
      }
      if (memo[start, amount] != -1)
      {
        return memo[start, amount];
      }
      // take current coin and not take current coin
      memo[start, amount] = Backtrack(coins, amount - coins[start], start, memo) +
        Backtrack(coins, amount, start + 1, memo);
      return memo[start, amount];
    }
}