public class BestTimeToBuyAndSellStock_III_123 {
    public int MaxProfit(int[] prices) {
      var memo = new int[prices.Length, 5];
      for (var i = 0; i < memo.GetLength(0); i++)
      {
        for (var j = 0; j < memo.GetLength(1); j++)
        {
          memo[i, j] = -1;
        }
      }
      return Dfs(prices, 0, 4, memo);
    }

    /// <summary>
    /// For each day, there are two choices, make transation or not make transation
    /// So we can do DFS on the two paths and then pick the max value
    /// </summary>
    private int Dfs(in int[] prices, int day, int todo, int[,] memo)
    {
      if (day == prices.Length || todo == 0)
      {
        return 0;
      }

      if (memo[day, todo] != -1)
      {
        return memo[day, todo];
      }

      // do not make transation this day
      var profit1 = Dfs(prices, day + 1, todo, memo);

      // make transation today
      // if there are even number of todo transations, then buy stock. otherwise, sell stock
      var buy = todo % 2 == 0;
      var profit2 = 0;
      if (buy)
      {
        profit2 = -1 * prices[day] + Dfs(prices, day + 1, todo - 1, memo);
      }
      else
      {
        profit2 = prices[day] + Dfs(prices, day + 1, todo - 1, memo);
      }

      memo[day, todo] = Math.Max(profit1, profit2);
      return memo[day, todo];
    }
}