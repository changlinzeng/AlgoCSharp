public class PartitionEqualSubsetSum_416 {
    public static bool CanPartition(int[] nums) {
        var total = nums.Sum();
        if (total % 2 != 0)
        {
          return false;
        }
        return TryPartition(nums, total / 2, 0, new int[total / 2 + 1, nums.Length]);
    }

    private static bool TryPartition(in int[] nums, int sum, int start, int[,] memo)
    {
      if (sum == 0)
      {
        return true;
      }
      if (start == nums.Length)
      {
        return false;
      }
      if (memo[sum, start] != 0)
      {
        return memo[sum, start] == 1;
      }
      for (var i = start; i < nums.Length; i++)
      {
        if (nums[i] <= sum)
        {
          if (TryPartition(nums, sum - nums[i], i + 1, memo))
          {
            memo[sum, start] = 1;
            break;
          }
          else
          {
            memo[sum, start] = -1;
          }
        }
      }
      return memo[sum, start] == 1;
    }
}