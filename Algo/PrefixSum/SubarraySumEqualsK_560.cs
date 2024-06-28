public class SubarraySumEqualsK_560 {
    public int SubarraySum(int[] nums, int k) {
      var len = nums.Length;
      // prefix sum and the ocurrence of this sum becuase there are negative numbers so the sum can be duplicate in different index
      var prefixSum = new Dictionary<int, int>();
      prefixSum.Add(0, 1);

      var count = 0;
      var sum = 0;
      for (var i = 0; i < len; i++)
      {
        sum += nums[i];
        if (prefixSum.ContainsKey(sum - k))
        {
          count += prefixSum[sum - k];
        }
        if (!prefixSum.TryAdd(sum, 1))
        {
          prefixSum[sum]++;
        }
      }
      return count;
    }
}