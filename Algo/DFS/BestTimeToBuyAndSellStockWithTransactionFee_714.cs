public class BestTimeToBuyAndSellStockWithTransactionFee_714 {
    /// <summary>
    /// Similar to BestTimeToBuyAndSellStock_III_123
    /// </summary>
    public int MaxProfit(int[] prices, int fee) {
        var memo = new int[prices.Length, 2];
        for (var i = 0; i < memo.GetLength(0); i++)
        {
            for (var j = 0; j < memo.GetLength(1); j++)
            {
                memo[i, j] = -1;
            }
        }
        return Dfs(prices, fee, 0, 1, memo);
    }

    private int Dfs(in int[] prices, in int fee, int start, int buy, int[,] memo)
    {
        if (start == prices.Length)
        {
            return 0;
        }
        if (memo[start, buy] != -1)
        {
            return memo[start, buy];
        }

        int maxProfit;
        if (buy == 1)
        {
            // buy stock or not buy
            maxProfit = Math.Max(-1 * prices[start] + Dfs(prices, fee, start + 1, 0, memo), Dfs(prices, fee, start + 1, 1, memo));
        }
        else
        {
            // sell stock or not sell
            maxProfit = Math.Max(prices[start] + Dfs(prices, fee, start + 1, 1, memo) - fee, Dfs(prices, fee, start + 1, 0, memo));
        }
        memo[start, buy] = maxProfit;
        return maxProfit;
    }
}