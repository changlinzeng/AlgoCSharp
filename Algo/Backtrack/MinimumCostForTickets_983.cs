public class MinimumCostForTickets_983 {
    public static int MincostTickets(int[] days, int[] costs) {
      return Backtrack(days, costs, 0, new int[days.Length]);
    }

    private static int Backtrack(int[] days, int[] costs, int start, int[] memo)
    {
      if (start == days.Length)
      {
        return 0;
      }
      if (memo[start] != 0)
      {
        return memo[start];
      }
      var tickets = new int[]{1, 7, 30};
      var minCost = int.MaxValue;
      // try each ticket and calculate the cost
      for (var i = 0 ;i < tickets.Length; i++)
      {
        // find next start day
        var nextStart = start;
        while (nextStart < days.Length && days[nextStart] < days[start] + tickets[i])
        {
          nextStart++;
        }
        minCost = Math.Min(minCost, costs[i] + Backtrack(days, costs, nextStart, memo));
      }
      memo[start] = minCost;
      return minCost;
    }
}