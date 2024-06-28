using System.ComponentModel;

public class MinimumSizeSubarraySum_209 {
    public int MinSubArrayLen(int target, int[] nums) {
        int left = 0, right = 0;
        int minLen = int.MaxValue;
        int sum = 0;
        while (right < nums.Length)
        {
          sum += nums[right];
          // move left boundary of the window
          if (sum >= target)
          {
            while (left < right && sum - nums[left] >= target)
            {
              sum -= nums[left];
              left++;
            }
            minLen = Math.Min(minLen, right - left + 1);
          }
          right++;
        }
        return minLen == int.MaxValue ? 0 : minLen;
    }
}