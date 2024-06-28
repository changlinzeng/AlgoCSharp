using System.Security.Cryptography;

public class LargestDivisibleSubset_368 {
    public static IList<int> LargestDivisibleSubset(int[] nums) {
        var dp = new List<IList<int>>();  // largest subset ends at i
        foreach (var _ in Enumerable.Range(0, nums.Length))
        {
          dp.Add([]);
        }

        Array.Sort(nums);
        dp[0].Add(nums[0]);

        var maxSubsetIndex = 0;
        for (var i = 1; i < nums.Length; i++)
        {
          // find the largest subset backward
          var currentMaxSubsetIndex = -1;
          for (var j = i - 1; j >= 0; j--)
          {
            if (nums[i] % dp[j].Last() == 0 &&
                (currentMaxSubsetIndex == -1 || dp[j].Count > dp[currentMaxSubsetIndex].Count))
            {
              currentMaxSubsetIndex = j;
            }   
          }

          if (currentMaxSubsetIndex != -1)
          {
            foreach (var n in dp[currentMaxSubsetIndex])
            {
              dp[i].Add(n);
            }
          }
          dp[i].Add(nums[i]);

          if (dp[i].Count > dp[maxSubsetIndex].Count)
          {
            maxSubsetIndex = i;
          }
        }

        return dp[maxSubsetIndex];
    }
}