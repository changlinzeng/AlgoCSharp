public class BestTimeToBuyAndSellStockWithCooldown_309 {
    public int MaxProfit(int[] prices) {
        var memo = new int[prices.Length, 2];
        for (var i = 0; i < prices.Length; i++)
        {
          for (var j = 0; j < 2; j++)
          {
            memo[i, j] = -1;
          }
        }
        return Dfs(prices, 1, 0, memo);
    }

    private int Dfs(in int[] prices, int buy, int start, int[,] memo)
    {
      if (start >= prices.Length)
      {
        return 0;
      }
      if (memo[start, buy] != -1)
      {
        return memo[start, buy];
      }
      var maxProfit = 0;
      if (buy == 1)
      {
        // buy stock or not buy
        maxProfit = Math.Max(maxProfit, -1 * prices[start] + Dfs(prices, 0, start + 1, memo));
        maxProfit = Math.Max(maxProfit, Dfs(prices, 1, start + 1, memo));
      }
      else
      {
        // sell stock or not sell
        maxProfit = Math.Max(maxProfit, prices[start] + Dfs(prices, 1, start + 2, memo));
        maxProfit = Math.Max(maxProfit, Dfs(prices, 0, start + 1, memo));
      }
      memo[start, buy] = maxProfit;
      return maxProfit;
    }
}