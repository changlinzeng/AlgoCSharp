public class CombinationSum_IV_377 {
    public int CombinationSum4(int[] nums, int target) {
        var dp = new int[target + 1];
        dp[0] = 1;
        for (var i = 1; i <= target; i++)
        {
            foreach (var n in nums)
            {
                if (n <= i)
                {
                    dp[i] += dp[i - n];
                }
            }
        }
        return dp[target];
    }
}