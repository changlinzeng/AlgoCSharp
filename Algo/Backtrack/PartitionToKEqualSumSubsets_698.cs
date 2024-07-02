public class PartitionToKEqualSumSubsets_698 {
    /// <summary>
    /// This is a generic form of MatchSticksToSquare_473
    /// </summary>
    public bool CanPartitionKSubsets(int[] nums, int k) {
        var total = nums.Sum();
        if (total % k != 0)
        {
          return false;
        }
        var setSum = total / k;
        return TryPartition(nums, setSum, setSum, k, 0, new int[k + 1, 1 << (nums.Length + 1)]) == 1;
    }

    /// <param name="nums"></param>
    /// <param name="setSum"></param>
    /// <param name="sum">consume the sum for each set. total / num of sets</param>
    /// <param name="k">how many sets are left</param>
    /// <param name="bitmask">bits representing which number is used</param>
    /// <param name="memo"></param>
    /// <returns></returns>
    private int TryPartition(in int[] nums, in int setSum, int sum, int k, int visited, int[,] memo)
    {
      if (k == 1 && sum == 0)
      {
        return 1;
      }
      if (memo[k, visited] != 0)
      {
        return memo[k, visited];
      }
      // consume one set and restore sum
      if (sum == 0)
      {
        k--;
        sum = setSum;
      }
      for (var i = 0; i < nums.Length; i++)
      {
        if (nums[i] > sum)
        {
          continue;
        }
        var pos = 1 << (nums.Length - i);
        if ((visited & pos) != 0)
        {
          continue;
        }
        var res = TryPartition(nums, setSum, sum - nums[i], k, visited ^ pos, memo);
        memo[k, visited] = res;
        if (res == 1)
        {
          return 1;
        }
      }
      return -1;
    }
}