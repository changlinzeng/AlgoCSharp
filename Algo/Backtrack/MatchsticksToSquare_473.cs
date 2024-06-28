public class MatchSticksToSquare_473 {
    public static bool Makesquare(int[] matchsticks) {
        var total = matchsticks.Sum();
        if (total % 4 != 0)
        {
          return false;
        }
        var edgeLen = total / 4;
        return Match(matchsticks, edgeLen, 4, edgeLen, 0, new int[5, 1 << (matchsticks.Length + 1)]);
    }

    private static bool Match(in int[] sticks, in int edgeLen, int edgeNum, int leftLen, int bitmask, int[,] memo)
    {
      if (edgeNum == 1 && leftLen == 0)
      {
        return true;
      }
      if (memo[edgeNum, bitmask] != 0)
      {
        return memo[edgeNum, bitmask] == 1;
      }
      // consume one edge
      if (leftLen == 0)
      {
        edgeNum--;
        leftLen = edgeLen;
      }
      for (var i = 0; i < sticks.Length; i++)
      {
        if (leftLen < sticks[i])
        {
          continue;
        }
        // check if the current stick is already used
        var pos = 1 << (sticks.Length - 1);
        if ((pos & bitmask) != 0)
        {
          continue;
        }
        var mask = pos ^ bitmask;
        var res = Match(sticks, edgeLen, edgeNum, leftLen - sticks[i], mask, memo);
        if (res)
        {
          memo[edgeNum, bitmask] = 1;
          return true;
        }
      }
      memo[edgeNum, bitmask] = -1;
      return false;
    }
}