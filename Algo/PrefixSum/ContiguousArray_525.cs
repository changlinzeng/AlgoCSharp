public class ContiguousArray_525 {
    public int FindMaxLength(int[] nums) {
        var diffs = new Dictionary<int, int>();  // diffs between 1 and 0 -> position
        var maxLen = 0;
        var diff = 0;
        for (var i = 0; i < nums.Length; i++)
        {
          if (nums[i] == 1)
          {
            diff++;
          }
          else
          {
            diff--;
          }

          if (diff == 0)
          {
            // subarray [0, i] has the same count of 1 and 0
            maxLen = Math.Max(maxLen, i + 1);
          }
          else
          {
            // check if there is qualified subarray
            if (!diffs.TryAdd(diff, i))
            {
              maxLen = Math.Max(maxLen, i - diffs[diff]);
            }
          }
        }
        return maxLen;
    }
}