public class Solution {
    public int LengthOfLIS(int[] nums) {
      var len = nums.Length;
      var dp = new int[len];
      dp[0] = 1;

      var maxLen = dp[0];
      for (var i = 1; i < len; i++)
      {
        dp[i] = 1;
        for (var j = i - 1; j >= 0; j--)
        {
          if (nums[j] < nums[i])
          {
            dp[i] = Math.Max(dp[i], dp[j] + 1);
          }
        }

        maxLen = Math.Max(maxLen, dp[i]);
      }

      return maxLen;
    }
}