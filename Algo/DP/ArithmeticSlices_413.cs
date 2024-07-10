public class ArithmeticSlices_413 {
    public int NumberOfArithmeticSlices(int[] nums) {
        var len = nums.Length;
        if (len < 3)
        {
          return 0;
        }

        var dp = new int[len];
        for (var i = 2; i < len; i++)
        {
          if (nums[i] - nums[i - 1] == nums[i - 1] - nums[i - 2])
          {
            dp[i] = dp[i - 1] + 1;
          }
        }

        return dp.Sum();
    }
}