public class CoinChange_322 {
    public static int CoinChange(int[] coins, int amount) {
      return Backtrack(coins, amount, new int[amount + 1]);
    }

    private static int Backtrack(int[] coins, int amount, int[] memo)
    {
      if (amount == 0)
      {
        return 0;
      }
      if (amount < 0)
      {
        return -1;
      }
      if (memo[amount] != 0)
      {
        return memo[amount];
      }
      var min = int.MaxValue;
      foreach (var coin in coins)
      {
        var res = Backtrack(coins, amount - coin, memo);
        if (res != -1)
        {
          min = Math.Min(min, res);
        }
      }
      memo[amount] = min == int.MaxValue ? -1 : min + 1;
      return memo[amount];
    }
}